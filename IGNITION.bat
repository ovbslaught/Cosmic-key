@echo off
title COSMIC IGNITION
color 0B
echo.
echo ==================================================
echo       COSMIC KEY OS - IGNITION SEQUENCE
echo ==================================================
echo.

echo [1/3] Launching Web Application (IIS Express)...
if exist "C:\Program Files (x86)\IIS Express\iisexpress.exe" (
    start "Cosmic Web App" "C:\Program Files (x86)\IIS Express\iisexpress.exe" /path:"%~dp0" /port:8080
) else (
    echo [WARNING] IIS Express not found. Skipping Web App.
)

timeout /t 2 /nobreak >nul

echo [2/3] Activating Cosmic Watchdog...
start "Cosmic Watchdog" python "%~dp0cosmic_watchdog.py" --active

timeout /t 1 /nobreak >nul

echo [3/3] Opening Cosmic Chat Matrix...
start "Cosmic Chat" python "%~dp0cosmic_chat.py"

echo.
echo ==================================================
echo          ALL SYSTEMS ARE GO
echo ==================================================
timeout /t 3
exit
