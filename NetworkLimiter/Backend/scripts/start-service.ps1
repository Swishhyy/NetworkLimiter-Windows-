# Check if PowerShell is running as Administrator
if (-not ([System.Security.Principal.WindowsPrincipal] [System.Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([System.Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Write-Output "This script requires administrator privileges. Re-launching as Administrator..."
    # Re-launch the script with elevated permissions
    Start-Process powershell -ArgumentList "-ExecutionPolicy Bypass -File `"$PSCommandPath`"" -Verb RunAs
    exit
}

# Define the service name
$serviceName = "NetworkLimitService"

# Check if the service exists
$service = Get-Service -Name $serviceName -ErrorAction SilentlyContinue

if ($null -ne $service) {
    # Start the service if it is not already running
    if ($service.Status -ne 'Running') {
        Start-Service -Name $serviceName
        Write-Output "$serviceName has been started."
    } else {
        Write-Output "$serviceName is already running."
    }
} else {
    Write-Output "$serviceName is not installed. Please install the service first."
}
