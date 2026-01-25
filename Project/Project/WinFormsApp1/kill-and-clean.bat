@echo off
echo Killing WinFormsApp1 processes...
taskkill /F /IM WinFormsApp1.exe 2>nul
timeout /t 2 /nobreak >nul

echo Cleaning build files...
if exist "bin\Debug\net9.0-windows\WinFormsApp1.exe" (
    del /F /Q "bin\Debug\net9.0-windows\WinFormsApp1.exe" 2>nul
)

if exist "obj\Debug\net9.0-windows\apphost.exe" (
    del /F /Q "obj\Debug\net9.0-windows\apphost.exe" 2>nul
)

echo Done! You can now rebuild your project.
pause
