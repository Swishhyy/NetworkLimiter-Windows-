# Check if PowerShell is running as Administrator
if (-not ([System.Security.Principal.WindowsPrincipal] [System.Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([System.Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Write-Output "This script requires administrator privileges. Re-launching as Administrator..."
    # Re-launch the script with elevated permissions
    Start-Process powershell -ArgumentList "-ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs
    exit
}

# Define the service name
$serviceName = "NetworkLimitService"

# Get the directory of the current script
$scriptDir = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition

# Define the relative path to the executable
$exePath = Join-Path -Path $scriptDir -ChildPath "..\NetworkLimit\bin\Release\net8.0\NetworkLimit.exe"

# Resolve the full path (useful if any symbolic links or relative paths are involved)
$exePath = (Resolve-Path $exePath).Path

# Check if the service is already installed
$service = Get-Service -Name $serviceName -ErrorAction SilentlyContinue

if ($null -ne $service) {
    Write-Output "$serviceName is already installed."
} else {
    # Install the service
    New-Service -Name $serviceName -BinaryPathName $exePath -DisplayName "Network Limit Service" -Description "Service to limit network usage on specified network interfaces."
    Write-Output "$serviceName has been installed as a Windows service."
}
