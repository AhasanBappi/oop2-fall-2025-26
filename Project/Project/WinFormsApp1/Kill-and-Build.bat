@echo off
cd /d "%~dp0"
echo ==========================================
echo  KILL AND BUILD - Fix MSB3021 / MSB3027
echo ==========================================
echo.
echo 1. If you started the app from Visual Studio (F5):
echo    -> Press Shift+F5 or click Stop to end debugging FIRST.
echo.
echo 2. Stopping WinFormsApp1...
taskkill /F /IM WinFormsApp1.exe 2>nul
if %ERRORLEVEL% EQU 0 (echo    App stopped.) else (echo    No app was running.)
echo.
echo 3. Waiting 3 seconds...
timeout /t 3 /nobreak >nul
echo.
echo 4. Removing locked exe (if possible)...
if exist "bin\Debug\net9.0-windows\WinFormsApp1.exe" (
    del /F /Q "bin\Debug\net9.0-windows\WinFormsApp1.exe" 2>nul
    if exist "bin\Debug\net9.0-windows\WinFormsApp1.exe" (
        echo    Could not delete exe - it is still in use.
        echo    Close Visual Studio, stop debugging, or restart PC, then try again.
        pause
        exit /b 1
    )
    echo    Deleted.
) else (echo    No exe to delete.)
echo.
echo 5. Building...
dotnet build
echo.
if %ERRORLEVEL% EQU 0 (
    echo ==========================================
    echo  BUILD SUCCEEDED.
    echo ==========================================
) else (
    echo ==========================================
    echo  BUILD FAILED. Stop debugging (Shift+F5), then run this script again.
    echo ==========================================
    pause
)
