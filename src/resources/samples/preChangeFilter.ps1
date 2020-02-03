#####################################################
#
# Name: Pre-Change PasswdHK Script
# Description: Check new password against defined 
#   dictionary, returns False (not changed) 
#   or True (changed)
# Author: Jason A. Everling
# Version: 0.3 alpha
#
######################################################

$user = $args[0];
$passwd = $args[1];
$settings = "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa\passwdhk"
$wordlist = "C:\Windows\PasswdHK\wordlist.txt"

# Functions
function datetime() {
    $datetime = Get-Date;
    return $datetime.ToString();
}

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

function getSetting($ini) {
    $result = (Get-ItemProperty -Path $settings -Name $ini).$ini;
    return $result;
}

# Load Settings
$loglevel = getSetting('loglevel');
$usePwnedEmail = getSetting('beenPwnedEmail');
$usePwnedPassword = getSetting('beenPwnedPassword');
$useWildcard = getSetting('wordlistUseWildcard');
$useWordlist = getSetting('wordlistUseWordlist');
$loadWordlist = Test-Path $wordlist;
$changed = $true;

if ($useWordlist) {
    if ($loadWordlist = "False") {
        log 404 "Error" "Unable to load wordlist at " $wordlist ". If you are not using a wordlist change the setting wordlistUseWordlist to 0";
        exit 1
    }
    # Matching is case-insensative
    if ($useWildcard) {
        $matcher = Get-Content $wordlist |
        Where-Object {
            $passwd -like "*" + $_ + "*"
        } | Select-Object -First 1
    } else {
        $matcher = Get-Content $wordlist |
        Where-Object {
            $passwd -eq $_
        } | Select-Object -First 1
    }

    # Check if new password matches a value in the dictionary
    if ($matcher -gt 0) {
        # block change
        $ext = "Wildcard matching is DISABLED.";
        if ($useWildcard) {
            $ext = "Wildcard matching is ENABLED.";
        }
        log 403 "Error" '"New password for user:" $user ", matches a sequence in the wordlist." $ext';
        $changed = $false;
    }
}

# Check if pwned email and send alert to designated email address
if ($usePwnedEmail) {}

# Check if pwned password, block and/or alert if found
if ($usePwnedPassword) {}

if ($changed = $false) {
    exit 1
} else {
    exit 0
}
