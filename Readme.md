# Network Limit Service

**Network Limit Service** is a tool for managing network usage on your PC. It allows you to limit network bandwidth consumption on a system by creating a Windows service that can be configured and controlled easily. This is particularly useful for environments where multiple machines (like gaming PCs and servers) are sharing a network connection.

## Table of Contents

- [Project Overview](#project-overview)
- [Project Requirements](#project-requirements)
- [Installation Guide](#installation-guide)
  - [Running the Installer](#running-the-installer)
  - [Manual Installation](#manual-installation)
- [How to Build the Project](#how-to-build-the-project)
- [Usage](#usage)
- [Troubleshooting](#troubleshooting)
  - [Build Fails](#build-fails)
- [License](#license)

## Project Overview

Network Limit Service provides an easy way to limit network usage for a specific set of applications on your PC. By running as a Windows service, it works silently in the background without any direct interaction from the user, providing automatic management of bandwidth limits across your network.

This project is ideal for situations where gaming PCs, servers, or other devices are connected to the same network, and you want to ensure that no one device consumes too much bandwidth.

## Project Requirements

To build and run **Network Limit Service**, you need the following software installed:

1. **Git**: A version control system to clone and update the repository.
   - Install from [Git Official Website](https://git-scm.com/).

2. **.NET SDK (6.0 or later)**: A development platform for building and running .NET applications.
   - Install from [Microsoft .NET SDK](https://dotnet.microsoft.com/download).

3. **PowerShell (version 5.0 or later)**: Required for running the PowerShell scripts to install the service.
   - PowerShell is included with Windows by default, but you can check the version by running:
     ```powershell
     $PSVersionTable.PSVersion
     ```

4. **Administrator Privileges**: The script requires administrator permissions to install and manage the service.

Once these requirements are fulfilled, you can proceed with the installation and usage steps.

## Installation Guide

There are two methods to install **Network Limit Service**: using the automated batch installer (`NetworkLimiterInstaller.bat`) or manually setting it up.

### Running the Installer

1. **Download the `NetworkLimiterInstaller.bat` file** from the releases section or from your repository.
   
2. **Run the `.bat` file**:
   - Right-click on the file and select "Run as administrator". The script will:
     - Prompt for **administrator permissions** if not already granted.
     - Allow you to select the **installation directory** via a file explorer.
     - Clone the repository from GitHub and build the project automatically.
     - Install and start the **NetworkLimitService**.

3. **Once complete**: The service will be installed and running on your machine, managing network usage as configured.

### Manual Installation

If you prefer manual installation or need to troubleshoot, follow these steps:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Swishhyy/NetworkLimiter-Windows-.git
