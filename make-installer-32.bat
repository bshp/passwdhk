
:::::::::::::::::::::::::::::::::::::::::::::::::::::
::
:: Kervin Pierre
:: kervin@blueprint-tech.com
:: 11JUN02
::
:: Modified by Brian Clayton
:: bclayton@clarku.edu
:: 25SEP17
::
:: BAT file for building 32-bit installer for passwdhk
::
:::::::::::::::::::::::::::::::::::::::::::::::::::::

@ECHO off

Set INSTALLER_TEMP=installer_temp
Set MAKENSIS_EXE="c:\program files (x86)\nsis\makensis.exe"

mkdir %INSTALLER_TEMP%

copy README.txt   %INSTALLER_TEMP%
copy LICENSE.txt  %INSTALLER_TEMP%
copy CHANGES.txt  %INSTALLER_TEMP%
copy passwdhk.nsi %INSTALLER_TEMP%
copy passwdhk.reg %INSTALLER_TEMP%
copy passwd.bat   %INSTALLER_TEMP%
copy passwdhk-config\passwdhk-config.ico %INSTALLER_TEMP%
copy Release\passwdhk.dll %INSTALLER_TEMP%
copy Release\passwdhk-driver.exe %INSTALLER_TEMP%
copy passwdhk-config\bin\Release\passwdhk-config.exe %INSTALLER_TEMP%

cd %INSTALLER_TEMP%
%MAKENSIS_EXE% passwdhk.nsi

