# Hotel Management System

## Overview

- **Year:** 2019
- **Language(s):** C#, HTML, JavaScript, CSS
- **Discipline(s):** Object-Oriented Software Development, Web Development
- **Keywords:** `dotnet`, `dotnet-core`, `hotel`, `hotel-management``hotel-management-system`, `itemized-lodging-receipts`, `reservations`, `room-cleaning`, `service-requests`, `web-application`, `worker-logs`, `.NET`

## Description

*oléHotels* is a simple hotel management system web application developed with the .NET Core platform as part of the *Processes of Object-Oriented Software Development* course at the University of Central Florida.

This system handles the reservation of rooms and holds the customers’ information. It also holds room service requests, room cleaning requests, and prints itemized lodging receipts. If some room became recently vacant, a cleaning order is created by the system and a random worker is assigned to it. If the worker/cleaner logs into the system, she/he is able to see the work orders and they can mark it complete and write comments. The software also supports extra paid features for the hotel (i.e., parking, paid Wi-Fi, payTV, pool, etc.). The admin user is also able to see everything and assign rooms to specific customers.

### Team Members

- Ankita Tripathi
- Carlos Santiago Bañón
- Kenneth Rosario Rodríguez
- Noelle Midkiff
- Matthew Reid

## Build Instructions

To run this web application, all you need is a computer running macOS or Windows (32-bit or 64-bit). The product is self-contained, so it runs in all these operating systems without any issues by following the build instructions below.

### macOS

1. Download the folder entitled `macOS` from the repository for this project. This can be
found in `oléHotels > Executables`.
2. Open the folder.
3. Locate the executable file entitled `OleHotels` and double-click on it. This will open the
terminal and will show the creation of a new local host.
4. Copy or type the first link on the terminal to your web browser of choice. The link is:
`http://localhost:5000`.
5. The web app will open and will be ready for use.

### Windows

1. Download the folder entitled `Windows` from the repository for this project. This can
be found in `oléHotels > Executables`. You must specify whether you want the 32-bit
version or the 64-bit version. For most computers, the 64-bit version will suffice.
2. Open the folder and double-click on the folder for the version of your choice (i.e., `32-Bit`
or `64-Bit`).
3. Locate the executable file entitled `OleHotels.exe` and double-click on it. This will open a
command prompt and will show the creation of a new local host.
4. Copy or type the first link on the command prompt to your web browser of choice. The
link is: `http://localhost:5000`.
5. The web app will open and will be ready for use.

*Note: There have been some sporadic issues when running the web application with macOS Catalina, the newest version of macOS, due to the way it handles executables with its new contained file system and Gatekeeper. If this is the case, please use macOS Mojave or earlier, or use a Windows computer.*
