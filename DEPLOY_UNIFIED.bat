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
echo [6] Awaken (Harvest Knowledge from Data)
echo [7] System Status Check
echo.
set /p choice="Select activation mode: "
if "%choice%"=="1" goto webapp
if "%choice%"=="2" goto github
if "%choice%"=="3" goto gitlab
if "%choice%"=="4" goto pushtowormhole
if "%choice%"=="5" goto importfromwormhole
if "%choice%"=="6" goto awaken
if "%choice%"=="7" goto status
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
