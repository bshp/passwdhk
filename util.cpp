/********************************************************************
** This file is part of 'AcctSync' package.
**
**  AcctSync is free software; you can redistribute it and/or modify
**  it under the terms of the Lesser GNU General Public License as 
**  published by the Free Software Foundation; either version 2 
**  of the License, or (at your option) any later version.
**
**  AcctSync is distributed in the hope that it will be useful,
**  but WITHOUT ANY WARRANTY; without even the implied warranty of
**  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
**  Lesser GNU General Public License for more details.
**
**  You should have received a copy of the Lesser GNU General Public
**  License along with AcctSync; if not, write to the 
**	Free Software Foundation, Inc.,
**	59 Temple Place, Suite 330, 
**	Boston, MA  02111-1307  
**	USA
**
** +AcctSync was originally Written by.
**  Kervin Pierre
**  Information Technology Department
**  Florida Tech
**  MAR, 2002
**
** +Modified by.
**  Brian Clayton
**  Information Technology Services
**  Clark University
**  MAR, 2008
**  OCT, 2010 - added alloc_copy function
**  JAN, 2011 - removed non-Unicode code, fixed memory leaks introduced by Unicode support code, handled NULL pointers
**  MAR, 2011 - fixed careless typos, added memory wiping to rawurlencode and doublequote functions
**  SEP, 2017 - fixed minor naming inconsistencies
** Redistributed under the terms of the LGPL
** license.  See LICENSE.txt file included in
** this package for details.
**
********************************************************************/


#include "passwdhk.h"

extern pshkConfigStruct pshk_config;
extern HANDLE hExecProgMutex;

LPWSTR bool_to_string(BOOL b)
{
	return (b ? L"true" : L"false");
}

LPWSTR null_to_string(LPWSTR s)
{
	return (s == NULL ? L"NULL" : s);
}

// Dynamically allocated, needs to be freed
LPWSTR alloc_copy(LPWSTR src, size_t length)
{
	WCHAR *ret = (WCHAR *)calloc(1, length + sizeof(wchar_t));
	if (ret != NULL) memcpy(ret, src, length);
	return ret;
}

// Dynamically allocated, needs to be freed
LPWSTR pshk_struct2str()
{
	wchar_t *tmp, *ret;
	
	tmp = (wchar_t *)calloc(1, 10 * PSHK_REG_VALUE_MAX_LEN_BYTES);
	if (tmp != NULL) {
		swprintf_s(tmp, 10 * PSHK_REG_VALUE_MAX_LEN, L"\r\nvalid: %d\r\npreChangeProg: '%s'\r\npreChangeProgArgs: '%s'\r\npreChangeProgWait: %d\r\npostChangeProg: '%s'\r\npostChangeProgArgs: '%s'\r\npostChangeProgWait: %d\r\nlogFile: '%s'\r\nmaxLogSize: %d\r\nlogLevel: %d\r\nurlencode: %s\r\ndoublequote: %s\r\nenvironmentStr: '%s'\r\nworkingdirectory: '%s'\r\npriority: %d\r\ninheritParentHandles: %s\r\n", pshk_config.valid, null_to_string(pshk_config.preChangeProg), null_to_string(pshk_config.preChangeProgArgs), pshk_config.preChangeProgWait, null_to_string(pshk_config.postChangeProg), null_to_string(pshk_config.postChangeProgArgs), pshk_config.postChangeProgWait, null_to_string(pshk_config.logFile), pshk_config.maxLogSize, pshk_config.logLevel, bool_to_string(pshk_config.urlencode), bool_to_string(pshk_config.doublequote), null_to_string(pshk_config.environmentStr), null_to_string(pshk_config.workingDir), pshk_config.priority, bool_to_string(pshk_config.inheritParentHandles));
		ret = _wcsdup(tmp);
		free(tmp);
	}
	else
		ret = _wcsdup(L"pshk_struct2str: cannot allocate memory!"); // _wcsdup needed for consistency so it can be freed

	return ret;
}

// Converts a Unicode string (UTF-16) to UTF-8, URL encodes it, and converts it back
//
// urlencodes a string according to the PHP function rawurlencode
//
// From the PHP manual...
//      Returns a string in which all non-alphanumeric characters
//      except -_. have been replaced with a percent (%) sign 
//      followed by two hex digits.
//
// Dynamically allocated, needs to be freed
LPWSTR rawurlencode(LPWSTR src)
{
	int size;
	char *utf8Copy;
	LPSTR encodedCopy;
	WCHAR *ret = NULL;
	unsigned int i, j = 0;
	UINT_PTR utf8Len;
	unsigned char c;

	// Get buffer size needed for UTF-8 string
	size = WideCharToMultiByte(CP_UTF8, 0, src, -1, NULL, 0, NULL, NULL);
	if (size != 0) {
		// Allocate and convert
		utf8Copy = (char *)calloc(size, 1);
		if (utf8Copy != NULL) {
			size = WideCharToMultiByte(CP_UTF8, 0, src, -1, utf8Copy, size, NULL, NULL);
			if (size != 0) {
				// URL encode
				utf8Len = strlen(utf8Copy);
				encodedCopy = (LPSTR)calloc(utf8Len + 1, 3);
				if (encodedCopy != NULL) {
					for (i = 0; i < utf8Len; i++) {
						c = (unsigned char)utf8Copy[i]; // Needs to be treated as unsigned for UTF-8
						if (isalnum(c) || c == '-' || c == '_' || c == '.')
							encodedCopy[j++] = c;
						else {
							_snprintf_s(&encodedCopy[j], 4, 3, "%%%2x", c);
							j += 3;
						}
					}

					// Get required buffer size
					size = MultiByteToWideChar(CP_UTF8, 0, encodedCopy, -1, NULL, 0);
					if (size != 0) {
						// Allocate and convert
						ret = (WCHAR *)calloc(size, sizeof(WCHAR));
						if (ret != NULL) size = MultiByteToWideChar(CP_UTF8, 0, encodedCopy, -1, ret, size);
					}
					SecureZeroMemory(encodedCopy, utf8Len * 3);
					free(encodedCopy);
				}
			}
			SecureZeroMemory(utf8Copy, utf8Len);
			free(utf8Copy);
		}
	}
	return ret;
}

// Encloses string in double quotes, escaping any double quotes and backslashes with backslashes
// Dynamically allocated, must be freed
LPWSTR doublequote(LPWSTR src)
{
	size_t srcLen = wcslen(src);
	size_t quotedLen = srcLen * 2 + 3; // Room for escaping, beginning/end quotes, and terminating NULL
	wchar_t *quotedCopy = (wchar_t *)calloc(quotedLen, sizeof(wchar_t));
	LPWSTR ret;
	unsigned i, j, k;
	j = 0;
	if (quotedCopy != NULL) {
		quotedCopy[j++] = L'"';
		for (i = 0; i < srcLen; i++) {
			if (src[i] == L'"') {
				k = i;
				while (k > 0 && src[--k] == '\\') // Any backslash or sequence of backslashes immediately preceding the quote must be escaped too
					quotedCopy[j++] = '\\';
				quotedCopy[j++] = '\\';
			}
			quotedCopy[j++] = src[i];
		}
		k = i;
		while (k > 0 && src[--k] == '\\') // Any backslash or sequence of backslashes immediately preceding the closing quote must be escaped too
			quotedCopy[j++] = '\\';
		quotedCopy[j] = L'"';
		ret = _wcsdup(quotedCopy); // Duplicate to eliminate unneeded space
		SecureZeroMemory(quotedCopy, quotedLen * sizeof(wchar_t));
		free(quotedCopy);
	}
	else
		ret = NULL;
	return ret;
}

// Calls the needed program with supplied user.
//
int pshk_exec_prog(int option, PUNICODE_STRING username, PUNICODE_STRING password)
{
	wchar_t *buffer, *prog, *args;
	wchar_t *usernameCopy;
#ifndef RAW_USERNAME
	wchar_t *usernameCopy2;
#endif
	wchar_t *passwordCopy, *passwordCopy2;
	wchar_t *bufferFormat = L"\"%s\" %s %s %s";
	int wait;
	int ret = PSHK_SUCCESS;
	DWORD_PTR bufferChars, bufferBytes;
	DWORD exitCode = 0;
	DWORD progRet;
	STARTUPINFO si;
    PROCESS_INFORMATION pi;
	SECURITY_ATTRIBUTES sa;
	HANDLE h;

	if (option == PSHK_PRE_CHANGE) {
		prog = pshk_config.preChangeProg;
		args = pshk_config.preChangeProgArgs;
		wait = pshk_config.preChangeProgWait;
	} else if (option == PSHK_POST_CHANGE) {
		prog = pshk_config.postChangeProg;
		args = pshk_config.postChangeProgArgs;
		wait = pshk_config.postChangeProgWait;
	} else // Unknown option
		return PSHK_FAILURE;

	// If no command is specified, say that we succeeded
	if (wcslen(prog) == 0 && wcslen(args) == 0)
		return PSHK_SUCCESS;

	// Get mutex - unfortunately, this whole section must be mutually exclusive so that the log doesn't get garbled by overlapping writes from multiple threads
	// ** Must be released before return!
	WaitForSingleObject(hExecProgMutex, INFINITE);

	// Open log
	h = pshk_log_open();
	
	// Copy buffers to ensure null-termination
	usernameCopy = alloc_copy(username->Buffer, username->Length);
	passwordCopy = alloc_copy(password->Buffer, password->Length);
	if (usernameCopy != NULL && passwordCopy != NULL) {
		// URL encode username and password
		if (pshk_config.urlencode == TRUE) {
#ifndef RAW_USERNAME
			usernameCopy2 = rawurlencode(usernameCopy);
			if (usernameCopy2 != NULL) {
				free(usernameCopy);
				usernameCopy = usernameCopy2;
			}
			else if (pshk_config.logLevel >= PSHK_LOG_ERROR)
				pshk_log_write_a(h, "Error URL encoding username");
#endif
			passwordCopy2 = rawurlencode(passwordCopy);
			if (passwordCopy2 != NULL) {
				SecureZeroMemory(passwordCopy, wcslen(passwordCopy) * sizeof(wchar_t));
				free(passwordCopy);
				passwordCopy = passwordCopy2;
			}
			else if (pshk_config.logLevel >= PSHK_LOG_ERROR)
				pshk_log_write_a(h, "Error URL encoding password");
		}
		// Double-quote username and password
		if (pshk_config.doublequote == TRUE) {
#ifndef RAW_USERNAME
			usernameCopy2 = doublequote(usernameCopy);
			if (usernameCopy2 != NULL) {
				free(usernameCopy);
				usernameCopy = usernameCopy2;
			}
			else if (pshk_config.logLevel >= PSHK_LOG_ERROR)
				pshk_log_write_a(h, "Error double-quoting username");
#endif
			passwordCopy2 = doublequote(passwordCopy);
			if (passwordCopy2 != NULL) {
				SecureZeroMemory(passwordCopy, wcslen(passwordCopy) * sizeof(wchar_t));
				free(passwordCopy);
				passwordCopy = passwordCopy2;
			}
			else if (pshk_config.logLevel >= PSHK_LOG_ERROR)
				pshk_log_write_a(h, "Error double-quoting password");
		}

		// Calculate needed buffer size
		bufferChars = wcslen(usernameCopy) + wcslen(passwordCopy) + wcslen(prog) + wcslen(args) + 32;
		bufferBytes = bufferChars * sizeof(wchar_t);
		buffer = (wchar_t *)calloc(1, bufferBytes);

		if (buffer != NULL) {
			// Memset is fine here since this is just initializing (not wiping)
			memset(&si, 0, sizeof(si));
			memset(&pi, 0, sizeof(pi));
			memset(&sa, 0, sizeof(sa));

			si.cb = sizeof(si);

			if (pshk_config.inheritParentHandles) {
				si.dwFlags |= STARTF_USESTDHANDLES;
				DuplicateHandle(GetCurrentProcess(), h, GetCurrentProcess(), (LPHANDLE)&(si.hStdOutput), 0, TRUE, DUPLICATE_SAME_ACCESS);
				DuplicateHandle(GetCurrentProcess(), h, GetCurrentProcess(), (LPHANDLE)&(si.hStdError), 0, TRUE, DUPLICATE_SAME_ACCESS);
				sa.nLength = sizeof(SECURITY_ATTRIBUTES);
				sa.bInheritHandle = TRUE;
			}
	
			// Log the commandline if we at DEBUG loglevel or higher
			if (pshk_config.logLevel >= PSHK_LOG_DEBUG) {
				_snwprintf_s(buffer, bufferChars, bufferChars - 1, bufferFormat, prog, args, usernameCopy, pshk_config.logLevel >= PSHK_LOG_ALL ? passwordCopy : L"<hidden>");
				pshk_log_write_w(h, buffer);
				SecureZeroMemory(buffer, bufferBytes);
			}
	
			_snwprintf_s(buffer, bufferChars, bufferChars - 1, bufferFormat, prog, args, usernameCopy, passwordCopy);

			// Wipe password and free copies
			SecureZeroMemory(passwordCopy, wcslen(passwordCopy) * sizeof(wchar_t));
			free(usernameCopy);
			free(passwordCopy);

			// Launch external program
			progRet = CreateProcess(prog, buffer, pshk_config.inheritParentHandles ? &sa : NULL, NULL, pshk_config.inheritParentHandles ? TRUE : FALSE, pshk_config.processCreateFlags, pshk_config.environment, pshk_config.workingDir, &si, &pi);

			// Wipe and free buffer
			SecureZeroMemory(buffer, bufferBytes);
			free(buffer);

			// If we fail and we care about printing errors then do it
			if (!progRet) {
				if (pshk_config.logLevel >= PSHK_LOG_ERROR) {
					wchar_t *fm_buf;
					FormatMessage(FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS, NULL, GetLastError(), MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPWSTR)&fm_buf, 0, NULL);
					pshk_log_write_w(h, fm_buf);
					LocalFree(fm_buf);
				}
				ret = PSHK_FAILURE;
			} else {
				// Wait for the process the alotted time
				progRet = WaitForSingleObject(pi.hProcess, wait);
				if (progRet == WAIT_FAILED && pshk_config.logLevel >= PSHK_LOG_ERROR) {
					pshk_log_write_a(h, "Wait failed for the last process");
				} else if (progRet == WAIT_TIMEOUT) {
					if ((option == PSHK_PRE_CHANGE && pshk_config.logLevel >= PSHK_LOG_ERROR) || (option == PSHK_POST_CHANGE && pshk_config.logLevel >= PSHK_LOG_DEBUG))
						pshk_log_write_a(h, "Wait timed out for the last process");
					if (option == PSHK_PRE_CHANGE)
						ret = PSHK_FAILURE;
				}

				if (ret == PSHK_SUCCESS) {
					// If this is a pre-change program, then we care about the 
					// exit code of the process as well.
					if (option == PSHK_PRE_CHANGE) {
						// Return fail if we get an exit code other than 0 or GetExitCodeProcess() fails
						if (GetExitCodeProcess(pi.hProcess, &exitCode) == FALSE) {
							if (pshk_config.logLevel >= PSHK_LOG_ERROR)
								pshk_log_write_a(h, "Error while recieving error code from process");
							ret = PSHK_FAILURE;
						} else if (exitCode)
							ret = PSHK_FAILURE;
					}
				}
			}
			CloseHandle(pi.hProcess);
			CloseHandle(pi.hThread);
			if (pshk_config.inheritParentHandles) {
				CloseHandle(si.hStdOutput);
				CloseHandle(si.hStdError);
			}
		}
		else if (pshk_config.logLevel >= PSHK_LOG_ERROR)
			pshk_log_write_a(h, ALLOCATION_ERROR);
	}
	else if (pshk_config.logLevel >= PSHK_LOG_ERROR)
		pshk_log_write_a(h, ALLOCATION_ERROR);

	// Close log
	pshk_log_close(h);

	// Release mutex
	ReleaseMutex(hExecProgMutex);

	return ret;
}
