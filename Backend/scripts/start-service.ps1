# Define the service name
$serviceName = "NetworkLimitService"

# Check if the service exists
$service = Get-Service -Name $serviceName -ErrorAction SilentlyContinue

if ($null -ne $service) {

    # Start the service
    Start-Service -Name $serviceName
    Write-Output "$serviceName has been started."
} else {
    Write-Output "$serviceName is not installed."
}
