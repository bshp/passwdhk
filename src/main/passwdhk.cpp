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
**  OCT, 2010 - added alloc_copy functions
**  JAN, 2011 - removed non-Unicode code, fixed memory leaks introduced by Unicode support code, handled NULL pointers
**  SEP, 2017 - fixed minor naming inconsistencies
**
** Redistributed under the terms of the LGPL
** license.  See LICENSE.txt file included in
** this package for details.
**
********************************************************************/


#include "passwdhk.h"

#ifndef STATUS_SUCCESS
#define STATUS_SUCCESS  ((NTSTATUS)0x00000000L)
#endif

// Holds all the persistant context information 
// Due to the nature of the LSA, this is basically
// a read only structure
pshkConfigStruct pshk_config;
// Mutex for pshk_exec_prog function
HANDLE hExecProgMutex;

// This is the post-password change function 
// The password change has been done
NTSTATUS NTAPI PasswordChangeNotify(PUNICODE_STRING username, ULONG relativeid, PUNICODE_STRING password)
{
	pshk_exec_prog(PSHK_POST_CHANGE, username, password);
	return STATUS_SUCCESS;
}


// This is the pre-password change function 
// A password change has been requested
BOOL NTAPI PasswordFilter(PUNICODE_STRING username, PUNICODE_STRING FullName, PUNICODE_STRING password, BOOL SetOperation)
{
	int retVal = pshk_exec_prog(PSHK_PRE_CHANGE, username, password);
	return retVal == PSHK_SUCCESS ? TRUE : FALSE;
}


// This is the initialization function
BOOL NTAPI InitializeChangeNotify(void)
{
	HANDLE h;
	LPWSTR configString;

	// Read the configuration from the registry
	pshk_config = pshk_read_registry();

	if (!pshk_config.valid)
		return FALSE;
	
	// Create pshk_exec_prog mutex
	hExecProgMutex = CreateMutex(NULL, FALSE, NULL);

	if (pshk_config.logLevel > 0) {
		h = pshk_log_open();
		if (h == INVALID_HANDLE_VALUE)
			return FALSE;
		pshk_log_write_a(h, "\r\nInit");
		configString = pshk_struct2str();
		pshk_log_write_w(h, configString);
		free(configString);
		pshk_log_write_a(h, "End Init\r\n");
		pshk_log_close(h);
	}

	// Set the priority of passwd program
	if (pshk_config.priority == -1)
		pshk_config.processCreateFlags |= IDLE_PRIORITY_CLASS;
	else if (pshk_config.priority == 1)
		pshk_config.processCreateFlags |= HIGH_PRIORITY_CLASS;
	else
		pshk_config.processCreateFlags |= NORMAL_PRIORITY_CLASS;

	// Other creation flags
	pshk_config.processCreateFlags |= PSHK_PROCESS_FLAGS;
	//pshk_config.processCreateFlags |= CREATE_NEW_PROCESS_GROUP | CREATE_NO_WINDOW;

	return TRUE;
}
