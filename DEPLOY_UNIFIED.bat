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
echo [3] Sync to GitLab
echo [4] Push TO Wormhole (Repo -> Drive)
echo [5] Import FROM Wormhole (Drive -> Repo)
echo [7] Organize Raw Data (Dedupe & Sort)
echo [8] Setup System (Keys, MCP, Environment)
echo [9] Launch Cosmic Watchdog (Daemon)
echo [10] Cosmic Chat (Unified AI Matrix)
echo [11] Open in VS Code (Antigravity Mode)
echo [12] System Status Check
echo.
set /p choice="Select activation mode: "
if "%choice%"=="1" goto webapp
if "%choice%"=="2" goto github
if "%choice%"=="3" goto gitlab
if "%choice%"=="4" goto pushtowormhole
if "%choice%"=="5" goto importfromwormhole
if "%choice%"=="6" goto awaken
if "%choice%"=="7" goto sortdata
if "%choice%"=="8" goto setup
if "%choice%"=="9" goto watchdog
if "%choice%"=="10" goto chat
if "%choice%"=="11" goto vscode
if "%choice%"=="12" goto status
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
git push -u origin main
pause
goto end

:gitlab
echo.
echo Syncing to GitLab...
git push -u gitlab main
pause
goto end

:pushtowormhole
echo.
echo Syncing Repo -> Wormhole...
set /p target="Enter full path to Wormhole folder (e.g. D:\Drive\Wormhole): "
powershell -File "%~dp0sync_to_wormhole.ps1" -TargetDir "%target%\cosmic-key"
pause
goto end

:importfromwormhole
echo.
echo Integrating Drive Data -> Repo...
set /p source="Enter full path to Wormhole folder (e.g. D:\Drive\Wormhole\cosmic-key): "
powershell -File "%~dp0import_from_wormhole.ps1" -SourceDriveDir "%source%"
echo.
echo Don't forget to commit the new data!
pause
goto end

:awaken
echo.
echo Initiating Knowledge Harvest...
python "%~dp0knowledge_harvester.py"
pause
goto end

:sortdata
echo.
echo Organizing Raw Data...
echo Tip: Your dump folder is likely '...[Wormhole]\mother-brain\temporal_raw_data'
set /p rawpath="Enter full path to source folder (Press Enter to check local project): "
if "%rawpath%"=="" set rawpath=%~dp0temporal_raw_data
python "%~dp0temporal_sorter.py" "%rawpath%"
pause
goto end

:setup
echo.
echo Setting up Credentials and MCP...
echo Trying to locate KEYZ in project or simple search...
python "%~dp0setup_mcp.py"
pause
goto end

:watchdog
echo.
echo Launching Cosmic Watchdog...
start "Cosmic Watchdog" python "%~dp0cosmic_watchdog.py" --active
pause
goto end

:chat
echo.
echo Entering Cosmic Chat Matrix...
python "%~dp0cosmic_chat.py"
pause
goto end

:vscode
echo.
echo Opening VS Code...
code "%~dp0"
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
