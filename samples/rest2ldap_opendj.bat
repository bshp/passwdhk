@echo on
:: Set new password of user in OpenDJ
:: The uid attribute in OpenDJ has to match sAMAccountName value for person in AD.
c:\curl\bin\curl.exe --header "Content-Type: application/json" --header "X-OpenIDM-Username: admin-uid" --header "X-OpenIDM-Password: admin-password" -X PATCH "http://opendj.example.com/users/%1" --data "[{\"operation\": \"replace\", \"field\": \"userPassword\", \"value\": \"%2\"}]"
pause
