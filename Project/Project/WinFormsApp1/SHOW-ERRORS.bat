@echo off
echo ========================================
echo CAPTURING BUILD ERRORS
echo ========================================
echo.
cd /d "%~dp0"
echo Cleaning first...
dotnet clean >nul 2>&1
echo.
echo Building and capturing ALL errors...
echo.
dotnet build --no-incremental 2>&1 | tee build-output.txt
echo.
echo ========================================
echo ERRORS FOUND:
echo ========================================
findstr /i /c:"error" build-output.txt
echo.
echo Full build output saved to: build-output.txt
echo.
pause
