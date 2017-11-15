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
**  SEP, 2008 - fixed minor naming inconsistencies
**
** Redistributed under the terms of the LGPL
** license.  See LICENSE.txt file included in
** this package for details.
**
********************************************************************/


#include "passwdhk.h"

// convert "$%%$" to 0
wchar_t *parse_env(wchar_t *str)
{
	wchar_t *ret;
	size_t i, j, slen;
	
	if (str == NULL || (slen = wcslen(str)) == 0)
		return NULL;
	
	ret = (wchar_t *)calloc(slen + 2, sizeof(wchar_t)); // Two trailing nulls to terminate
	if (ret != NULL) {
		i = 0;
		for (j = 0; j < slen && i < slen; j++) {
			if (str[j] == L'$' && j < slen - 3 && str[j + 1] == L'%' && str[j + 2] == L'%' && str[j + 3] == L'$') {
				ret[i] = L'\0';
				j += 3;
			} else
				ret[i] = str[j];
			i++;
		}
	}
	return ret;
}

BOOL read_registry_value(HKEY hKey, LPCTSTR lpValueName, LPBYTE lpData, LPDWORD lpcbData)
{
	*lpcbData = PSHK_REG_VALUE_MAX_LEN_BYTES;
	memset(lpData, 0, *lpcbData);
	return (RegQueryValueEx(hKey, lpValueName, NULL, NULL, lpData, lpcbData) == ERROR_SUCCESS);
}

BOOL string_to_bool(LPWSTR str)
{
	return (!_wcsicmp(str, L"true") || !_wcsicmp(str, L"yes") || !_wcsicmp(str, L"on"));
}

pshkConfigStruct pshk_read_registry(void)
{
    HKEY hk;  
    wchar_t szBuf[PSHK_REG_VALUE_MAX_LEN + 1];
	DWORD szBufSize = PSHK_REG_VALUE_MAX_LEN_BYTES;
	pshkConfigStruct ret = {0};
		
	memset(szBuf, 0, sizeof(szBuf));
	
	if (RegOpenKeyEx(HKEY_LOCAL_MACHINE, PSHK_REG_KEY, 0, KEY_QUERY_VALUE, &hk) != ERROR_SUCCESS)
        return ret;

	if (read_registry_value(hk, L"preChangeProg", (LPBYTE)szBuf, &szBufSize)) {
		ret.preChangeProg = _wcsdup(szBuf);
		ret.valid = 1;
	}

	if (read_registry_value(hk, L"preChangeProgArgs", (LPBYTE)szBuf, &szBufSize))
		ret.preChangeProgArgs = _wcsdup(szBuf);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"preChangeProgWait", (LPBYTE)szBuf, &szBufSize))
		ret.preChangeProgWait = wcstol(szBuf, NULL, 10);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"postChangeProg", (LPBYTE)szBuf, &szBufSize))
		ret.postChangeProg = _wcsdup(szBuf);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"postChangeProgArgs", (LPBYTE)szBuf, &szBufSize))
		ret.postChangeProgArgs = _wcsdup(szBuf);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"postChangeProgWait", (LPBYTE)szBuf, &szBufSize))
		ret.postChangeProgWait = wcstol(szBuf, NULL, 10);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"logfile", (LPBYTE)szBuf, &szBufSize))
		ret.logFile = _wcsdup(szBuf);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"maxlogsize", (LPBYTE)szBuf, &szBufSize))
		ret.maxLogSize = wcstol(szBuf, NULL, 10);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"loglevel", (LPBYTE)szBuf, &szBufSize))
		ret.logLevel = wcstol(szBuf, NULL, 10);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"urlencode", (LPBYTE)szBuf, &szBufSize))
		ret.urlencode = string_to_bool(szBuf);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"doublequote", (LPBYTE)szBuf, &szBufSize))
		ret.doublequote = string_to_bool(szBuf);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"environment", (LPBYTE)szBuf, &szBufSize)) {
		ret.environmentStr = _wcsdup(szBuf);
		ret.environment = parse_env(szBuf);
	} else
		ret.valid = 0;
	if (read_registry_value(hk, L"workingdir", (LPBYTE)szBuf, &szBufSize))
		ret.workingDir = _wcsdup(szBuf);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"priority", (LPBYTE)szBuf, &szBufSize))
		ret.priority = wcstol(szBuf, NULL, 10);
	else
		ret.valid = 0;
	if (read_registry_value(hk, L"output2log", (LPBYTE)szBuf, &szBufSize))
		ret.inheritParentHandles = string_to_bool(szBuf);
	else
		ret.valid = 0;

    RegCloseKey(hk);
	
	return ret;
} 