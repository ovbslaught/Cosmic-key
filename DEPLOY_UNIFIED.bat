@echo off
title COSMIC KEY UNIFIED - SUPERINTELLIGENCE SYSTEM
color 0A
echo.
echo  ================================================
echo    COSMIC KEY UNIFIED SYSTEM
echo    SUPERINTELLIGENCE ACTIVATION
echo  ================================================
echo.
echo [1] Launch Web Application (IIS Express)
echo [2] Sync to GitHub
echo [3] Sync to Wormhole (Drive)
echo [4] System Status Check
echo.
set /p choice="Select activation mode: "
if "%choice%"=="1" goto webapp
if "%choice%"=="2" goto github
if "%choice%"=="3" goto wormhole
if "%choice%"=="4" goto status
goto end

:webapp
echo.
echo Activating Web Application...
if exist "C:\Program Files (x86)\IIS Express\iisexpress.exe" (
    start "" "C:\Program Files (x86)\IIS Express\iisexpress.exe" /path:"%~dp0" /port:8080
    echo [✓] IIS Express started on port 8080
    start http://localhost:8080
) else (
    echo [ERROR] IIS Express not found.
)
pause
goto end

:github
echo.
echo Syncing to GitHub...
git push -u origin master
pause
goto end

:wormhole
echo.
echo Syncing to Wormhole...
set /p target="Enter full path to Wormhole folder (e.g. D:\Drive\Wormhole): "
powershell -File "%~dp0sync_to_wormhole.ps1" -TargetDir "%target%\cosmic-key"
pause
goto end

:status
echo.
echo SYSTEM STATUS CHECK
echo ================================================
echo.
if exist "Web.config" echo [✓] Web Config: OPERATIONAL
if exist "App_Data\api.md" echo [✓] Database: OPERATIONAL
if exist "bin\runnerDotNet.dll" echo [✓] Core Binary: OPERATIONAL
echo.
echo ================================================
pause
goto end

:end
