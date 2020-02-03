@echo off
:: Sync password to Google Apps, removes the need for an additional password filter from Google, Google Apps Passowrd Sync
:: Using https://github.com/jay0lee/GAM and files copied to C:\Program Files\Google\Google Apps Manager
"%ProgramFiles%\Google\Google Apps Manager\gam.exe" update user %1 password %2
exit 0
