@echo off
setlocal

REM Define variables
set repoUrl=https://github.com/Swishhyy/NetworkLimiter-Windows-.git
set repoDir=%~dp0NetworkLimiter-Windows-
set backendDir=%repoDir%\NetworkLimiter\Backend
set psScriptPath=%backendDir%\scripts
set buildDir=%backendDir%\NetworkLimit

REM Step 1: Check for Git installation
git --version >nul 2>&1
if errorlevel 1 (
    echo Git is not installed. Please install Git and try again.
    pause
    exit /b 1
)

REM Step 2: Check for .NET SDK installation
dotnet --version >nul 2>&1
if errorlevel 1 (
    echo .NET SDK is not installed. Please install .NET SDK and try again.
    pause
    exit /b 1
)

REM Step 3: Clone or update the GitHub repository
if exist "%repoDir%" (
    echo Updating existing repository...
    cd %repoDir%
    git pull
) else (
    echo Cloning repository...
    git clone %repoUrl% "%repoDir%"
)

REM Step 4: Build the project
cd %buildDir%
dotnet build "%buildDir%\NetworkLimit.csproj" --configuration Release
if errorlevel 1 (
    echo Build failed. Please check for errors and try again.
    pause
    exit /b 1
)

REM Step 5: Run install-service.ps1 to install the service
powershell -ExecutionPolicy Bypass -File "%psScriptPath%\install-service.ps1"
if errorlevel 1 (
    echo Service installation failed. Please check for errors and try again.
    pause
    exit /b 1
)

echo Network Limit Service installed successfully.
pause
