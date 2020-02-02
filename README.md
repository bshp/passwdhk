# Password Filter for Active Directory

This is a generic password filter for Active Directory that will run the program you specify before and/or after a password change is made. It can be a web service call, script call, or even update a sql database.  
  
The release dll has been built and tested for Windows Server x64 only. See the Original-README for more info, the below is for x64.  
  
Requirements  
============  
Server 2008 R2 to Server 2012 R2  
v1.0 - Microsoft Visual C++ 2010 Redistributable Package (x64)  
  
Server 2016 +  
v1.2 - Microsoft Visual C++ 2017 Redistributable Package (x64)  
  
Installation  
============  
(a) Copy "passwdhk.dll" to C:\Windows\system32  
  
(b) Edit the "HKLM->SYSTEM->CurrentControlSet->Control->Lsa->Notification Packages" registry value and add "passwdhk" (without the quotes) to the list of names there (on a new line).  
  
(c) Edit the file "passwdhk.reg" to suit your environment and then import it into the registry by double-clicking that file.  
  
(d) Reboot.  
  
Notes  
=======  
The default settings set error logging on and file paths to C:\WINDOWS\System32\LogFiles . Modify the reg file accordingly.  
  
Dictionary Matching (Alpha - Work in progress)  
===================  
There is an alpha preChangeScript to check against a defined wordlist, can be wirldcard matching, any password containing the disallowed value or whole word matching.  
  
Log Levels  
==========  
  
0 - Off  
1 - Error  
2 - Debug  
3 - All  
  
Original Sources  
================  
https://sourceforge.net/projects/passwdhk/  
  
The programs and source code in this package and supplied by this package is made available under the LGPL license.  Please see LICENSE.txt in this package for more information.  
