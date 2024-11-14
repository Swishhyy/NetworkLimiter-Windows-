@echo off
setlocal

REM Set the path to the PowerShell scripts directory
set scriptPath=%~dp0Backend\scripts

REM Check if script path exists
if not exist "%scriptPath%" (
    echo Script path not found: %scriptPath%
    pause
    exit /b 1
)

REM Display menu
echo -------------------------------------------
echo Network Limit Service Manager
echo -------------------------------------------
echo [1] Install Service
echo [2] Start Service
echo [3] Uninstall Service
echo [Q] Quit
echo -------------------------------------------
set /p choice=Choose an option:

REM Run the appropriate PowerShell script based on user choice
if /i "%choice%"=="1" (
    echo Running Install Service...
    powershell -ExecutionPolicy Bypass -File "%scriptPath%\install-service.ps1"
) else if /i "%choice%"=="2" (
    echo Starting Service...
    powershell -ExecutionPolicy Bypass -File "%scriptPath%\start-service.ps1"
) else if /i "%choice%"=="3" (
    echo Uninstalling Service...
    powershell -ExecutionPolicy Bypass -File "%scriptPath%\uninstall-service.ps1"
) else if /i "%choice%"=="Q" (
    echo Exiting...
    exit /b 0
) else (
    echo Invalid choice. Exiting...
    exit /b 1
)

pause
