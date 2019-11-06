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
**  MAR 2008
**  OCT 2010 - added alloc_copy functions
**  JAN 2011 - removed non-Unicode code, fixed memory leaks introduced by Unicode support code, handled NULL pointers
**  MAR 2011 - fixed careless typos, added memory wiping to rawurlencode and doublequote functions
**
** Redistributed under the terms of the LGPL
** license.  See LICENSE.txt file included in
** this package for details.
**
********************************************************************/

LPWSTR bool_to_string(BOOL b);
LPWSTR null_to_string(LPWSTR b);
LPWSTR alloc_copy(LPWSTR src, size_t length);
LPWSTR pshk_struct2str();
LPWSTR rawurlencode(LPWSTR src);
LPWSTR doublequote(LPWSTR src);
int pshk_exec_prog(int option, PUNICODE_STRING username, PUNICODE_STRING password);