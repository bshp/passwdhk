#####################################################
#
# Name: Post-Change PasswdHK Script
# Description: Run multiple post-change actions
# Author: Jason A. Everling
# Version: 0.3 alpha
#
######################################################

$user = $args[0];
$passwd = $args[1];
$settings = "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa\passwdhk";
$curl = $Env:Programfiles"\Curl\bin";
$gam = $Env:Programfiles"\Google\Google Apps Manager";
$retcode = 0;

# Functions

# Get date as string
function datetime() {
    $datetime = Get-Date;
    return $datetime.ToString();
}

# Write to the system event application log
function log([int]$numEid, [string]$strLevel, [string]$strMsg) {
    $now = datetime;
    if ($loglevel -ne 0) {
        if ($loglevel -eq 1 -and $strLevel -eq "Error") {
            Write-EventLog -LogName Application -Source 'PasswordHK Filter' -EventId $numEid -EntryType $strLevel -Message "["$now"]" $strMsg;
        }
        if ($loglevel -ge 2) {
            Write-EventLog -LogName Application -Source 'PasswordHK Filter' -EventId $numEid -EntryType $strLevel -Message "["$now"]" $strMsg;
        }
    }
    # clear datetime if milliseconds apart
    $now = '';
}

# Get setting from registry
function getSetting($ini) {
    $result = (Get-ItemProperty -Path $settings -Name $ini).$ini;
    return $result;
}

# Send Email Message
function sendMail([string]$mailTo, [string]$mailSubject, [string]$mailMsg) {
    if ($mailEnabled) {
        $mailFrom = $mailNotify;
        $smtpServer = $mailServer;
        $smtp = New-Object Net.Mail.SmtpClient($smtpServer);
        $smtp.Send($mailFrom, $mailTo, $mailSubject, $mailMsg);
    }
}

# Load Settings
$loglevel = getSetting('loglevel');
$mailEnabled = getSetting('emailEnabled');
$mailNotify = getSetting('emailNotification');
$syncGSuite = getSetting('syncGSuite');
$syncOpenDJ = getSetting('syncOpenDJ');

# If sync password with GSuite
if ($syncGSuite) {
    & "$gam\gam.exe" update user $user password $passwd;
    if ($? -eq $false ) {
        log 400 "Error" "GSuite password sync encountered an error for $user";
        $retcode = 1;
    } else {
        log 202 "Information" "GSuite password updated for $user";
        $retcode = 0;
    }
}

# If sync password with OpenDJ
if ($syncOpenDJ) {
    & "$curl\curl.exe" --header "Content-Type: application/json" --header "X-OpenIDM-Username: admin-uid" --header "X-OpenIDM-Password: admin-password" -X PATCH "http://opendj.example.com/users/$user" --data "[{\"operation\": \"replace\", \"field\": \"userPassword\", \"value\": \"$passwd\"}]"
    if ($? -eq $false ) {
        log 400 "Error" "OpenDJ password sync encountered an error for $user";
        $retcode = 1;
    } else {
        log 202 "Information" "OpenDJ password updated for $user";
        $retcode = 0;
    }
}

if ($retcode = 0) {
    log 200 "Information" "Post-change script ran successfully for $user";
    exit 0
} else {
    log 500 "Error" "Post-change script reported an error for $user";
    exit 0
}
