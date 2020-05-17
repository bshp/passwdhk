# Password Filter for Active Directory

This is a generic password filter for Active Directory that will run the program you specify before and/or after a password change is made. It can be a web service, script and/or even update a sql database.  
  
Included are (2) Powershell Scripts, they are configured to use HaveIBeenPwned API services and Dictionary Wordlist matching using NIST blacklists.  
  
The release dll has been built and tested for Windows Server x64 only. If you you build the dll yourself, make sure you do not get ANY errors or warning, absolutly ZERO.  
  
If you get any errors/or warnings and you reboot your domain controller you could bluescreen because the LSA notification package's cannot return any errors on startup. In this case, you would need to boot into recovery mode and remove the registry entry.  
  
  The current 'master' branch dll hashes, a release package has it's own hash, this is ONLY for master branch target/passwdhk.dll  
  
  MD5: 35E4CDDB7FF3D55AFCE9B2A02A19B05D  
  SHA-1: ADD4D1E2AA74A2420210273E2D56D2F5A74CC66E  
  
## Requirements  
===============  
#### v1.0  
- Windows Server 2003 R2 x64
- Microsoft Visual C++ 2010 Redistributable Package (x64)  
  
#### v1.2+
- Windows Server 2008 R2 and up
- Microsoft Visual C++ 2017 Redistributable Package (x64)  
  
## Installation  
===============  
[Installation Guide](src/resources/Installation_Guide_v1.3.1.pdf)  
  
If the link is not working, it is located under /src/resources    

## Notes  
========  
The default settings set error logging on and file paths to C:\WINDOWS\System32\LogFiles . Modify the reg file accordingly.  

#### Manage via Group Policy (work in progress)  
==============================================================  
The feature/gpotemplate branch is a work in progress to moving passwdk managamenet to group policy.  
  
Road Map  
  - Update passwdhk dll to use policies subkey, i.e HKLM:\Software\Policies  
  - Create new group policy templates to read/write from HKLM:\Software\Policies\PasswdHK subkey  
  - Create enablement\disablement of passwdhk via group policy settings  
  
#### HaveIBeenPwned and Dictionary Matching (work in progress)  
==============================================================  
There is a Pre-Change Script, preChangeFilter.ps1, and a Post-Change Script, postChangeFilter.ps1  
(a) Can be set to check pwned passwords and email using the https://haveibeenpwned.com/ API services  Checking a persons email requires an API key, password hash checking does not
(b) Check against a defined wordlist, can be wildcard matching, any password containing the disallowed value or whole word matching  
(c) If you user email found by haveibeenpwned send an email alert/notification  
  
You can grab even larger wordlist's, the top 1xxx from the NIST blacklist located https://github.com/cry/nbp/tree/master/build_collection
## Log Levels  
=============  
  
0 - Off  
1 - Error  
2 - Debug  
3 - All  
  
## Original Sources  
===================  
https://sourceforge.net/projects/passwdhk/  
  
The programs and source code in this package and supplied by this package is made available under the LGPL license.  Please see LICENSE.txt in this package for more information.  
