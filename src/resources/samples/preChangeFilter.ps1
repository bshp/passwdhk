#####################################################
#
# Name: Pre-Change PasswdHK Script
# Description: Check new password against defined 
#   dictionary, returns False (not changed) 
#   or True (changed)
# Author: Jason A. Everling
# Version: 0.3 alpha
#
# Credits: The getPwnedPasswd function was adapted from the 
#   haveibeenpwned powershell module
#
######################################################
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

$user = $args[0];
$passwd = $args[1];
$settings = "HKLM:\SYSTEM\CurrentControlSet\Control\Lsa\passwdhk"
$wordlist = "C:\Windows\PasswdHK\wordlist.txt"
$pwnedAPI = "https://api.pwnedpasswords.com/range/";
$pwnedAPIKey = "";

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

function getSetting([string]$ini) {
    $result = (Get-ItemProperty -Path $settings -Name $ini).$ini;
    return $result;
}

function getHashedPasswd([string]$textToHash) {
    $hasher = New-Object -TypeName "System.Security.Cryptography.SHA1CryptoServiceProvider";
    $toHash = [System.Text.Encoding]::UTF8.GetBytes($textToHash);
    $bytes = $hasher.ComputeHash($toHash);
    $result = ($bytes | ForEach-Object ToString X2) -join '';
    return $result;
}

function getUserEmail([string]$Username) {}

function getPwnedPasswd([string]$Password) {
    $SHA1 = getHashedPasswd($Password);
    $URI = $pwnedAPI + $SHA1.SubString(0, 5);
    try {
        $request = Invoke-RestMethod -Uri $URI;
        $suffix = $SHA1.SubString(5, 35) + ":";
        $found = $request.split() | select-string "$suffix" | out-string;
        if ($found) {
            $cnt = (($found.split(':'))[1]).trim();
            #Write-Warning "Password has been pwned, total count:" $cnt;
            $result = 1;
        } else {
            $result = 0;
            #Write-Output "Not found!";
        }
        if ($result -eq 1) {
            return $true;
        } else {
            return $false;
        }
    } catch {
        $errorDetails = $null;
        $response = $_.Exception | Select-Object -ExpandProperty 'message' -ErrorAction Ignore;
        if ($response) {
            $errorDetails = $_.ErrorDetails;
        }
        if ($null -eq $errorDetails) {
            if ($response -contains "400") {
                log 400 "Error" "Bad Request - the account does not comply with an acceptable format";
            }
            if ($response -contains "403") {
                log 403 "Error" "Forbidden - no user agent has been specified in the request";
            }
            if ($response -contains "404") {
                log 404 "Error" "Password not found";
            }
            if ($response -contains "429") {
                log 429 "Error" "Too many requests - the rate limit has been exceeded"
            }
        } else {
            log 410 "Error" 'Request to "{0}" failed: {1}' -f $uri, $errorDetails;
        }
        # Write the error but allow change, if there is a network error do we really want to block changes?
        return $false;
    }
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
if ($usePwnedPassword) {
    $pwned = getPwnedPasswd $passwd;
    if ($pwned) {
        $changed = $false;
    }
}

if ($changed = $false) {
    exit 1
} else {
    exit 0
}
