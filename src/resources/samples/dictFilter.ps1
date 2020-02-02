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
$machine = $user.Substring($user.Length - 1);
$settings = "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa\passwdhk"
$wordlist = "C:\Windows\PasswdHK\wordlist.txt"

# Functions
function datetime() {
    $datetime = Get-Date;
    return $datetime.ToString();
}

function phkLog($numEid, $strLevel, $strMsg) {
    $now = datetime;
    Write-EventLog -LogName Application -Source 'PasswordHK Filter' -EventId $numEid -EntryType $strLevel -Message "["$now"]" $strMsg;
    # clear datetime if milliseconds apart
    $now = '';
}

function phkSetting($ini) {
    $result = (Get-ItemProperty -Path $settings -Name $ini).$ini;
    return $result;
}

# Load Settings
$useWildcard = phkSetting('wordlistUseWildcard');
$useWordlist = phkSetting('wordlistUseWordlist');
$loadWordlist = Test-Path $wordlist;
$changed = $true;

if ($machine -contains '$') {
    phkLog(105, "Information", "Bypassing filter, object is a machine");
    exit 0
}

if ($useWordlist) {
    if ($loadWordlist = "False") {
        phkLog(102, "Error", "Unable to load wordlist at " $wordlist ". If you are not using a wordlist change the setting wordlistUseWordlist to 0");
        exit 1
    }
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

    # Check new password matches a disallowed value
    if ($matcher -gt 0) {
        # block change
        $ext = "Wildcard matching is DISABLED.";
        if ($useWildcard) {
            $ext = "Wildcard matching is ENABLED.";
        }
        phkLog(111, "Error", '"New password for user:" $user ", matches a sequence in the wordlist." $ext');
        $changed = $false;
    }
}

if ($changed = $false) {
    exit 1
} else {
    exit 0
}
