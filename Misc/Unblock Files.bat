@echo off
title Unblock Files Script

:: Check if a parameter was provided
if "%~1"=="" (
    echo Error: Please provide a folder path.
    echo Usage: UnblockFolder.bat "C:\Your\Path\Here"
    echo.
    pause
    exit /b
)

echo Target Directory: %~1
echo Processing...
echo.

:: %~1 strips out any surrounding quotes so we can handle them safely in PowerShell
powershell -NoProfile -ExecutionPolicy Bypass -Command "Get-ChildItem -Path '%~1' -Recurse | Unblock-File -Verbose"

echo.
echo Operation complete.
pause