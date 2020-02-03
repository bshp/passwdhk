@echo off
Set OUTFILE="C:\WINDOWS\TEMP\passwd.txt"

echo user='%1' pass='%2' >> %OUTFILE%
