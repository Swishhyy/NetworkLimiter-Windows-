$serviceName = "NetworkLimitService"
$exePath = "C:\path\to\your\compiled\NetworkLimit.exe"

New-Service -Name $serviceName -BinaryPathName $exePath -DisplayName "Network Limit Service" -Description "Service to limit network usage on specified network interfaces."
Start-Service -Name $serviceName
Write-Output "$serviceName installed and started."
