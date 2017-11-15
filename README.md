# Password Filter for Active Directory
This repo was updated from VS 2008 to VS 2010. The release dll has been built and tested for Windows Server x64 only. See the Original-README for more info, the below is for x64.

Installation
========
(a) Copy "passwdhk.dll" to C:\Windows\system32

(b) Edit the "HKLM->SYSTEM->CurrentControlSet->Control->Lsa->Notification Packages" registry value and add "passwdhk" (without the quotes) to the list of names there (on a new line).

(c) Edit the file "passwdhk.reg" to suit your environment and then import it into the registry by double-clicking that file.

(d) Reboot.

Notes
=======

The default settings set debug logging on and file paths to c:\windows\temp, please change logging level back to 1 'Error' or 0 for none.

Log Levels
==========

0 - Off
1 - Error
2 - Debug
3 - All
 
The programs and source code in this package and supplied by this package is made available under the LGPL license.  Please see LICENSE.txt in this package for more information.