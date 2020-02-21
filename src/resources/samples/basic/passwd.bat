:::::::::::::::::::::::::::::::::::::::::
::
:: Kervin Pierre, 11JUN02
:: kervin@blueprint-tech.com
:: Florida Tech, Information Technology
::
:: Test script for passwdhk DLL
::
:::::::::::::::::::::::::::::::::::::::::

@ECHO OFf
Set OUTFILE="C:\Windows\temp\passwd.txt"

echo user='%1' pass='%2' >> %OUTFILE%

