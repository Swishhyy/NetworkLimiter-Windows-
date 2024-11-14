# Network Limit

**Network Limit** is a Windows service designed to control and limit network usage on servers and PCs. This tool is particularly useful for setups where servers share network resources with gaming PCs or other servers, providing more granular control than Windows' metered connection settings.

---

## Features

- **Network Throttling**: Uses Windows `netsh` commands to limit bandwidth on specified network interfaces.
- **Dynamic Configuration Reloading**: Automatically reloads configuration from `appsettings.json` without restarting the service.
- **Scheduled Throttling**: Allows network limits to be applied based on specified hours.
- **Logging**: Logs actions and errors to `logs/service.log` for easy troubleshooting and monitoring.

---

## Table of Contents

- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)
- [PowerShell Scripts](#powershell-scripts)
- [Development](#development)
- [License](#license)

---

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/NetworkLimit.git
