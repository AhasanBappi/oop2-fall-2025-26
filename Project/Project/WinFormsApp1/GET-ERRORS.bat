@echo off
echo ========================================
echo GETTING BUILD ERRORS
echo ========================================
echo.
echo Building project and showing errors...
echo.
cd /d "%~dp0"
dotnet build 2>&1 | findstr /i "error CS"
if %ERRORLEVEL% EQU 0 (
    echo.
    echo Errors found above.
) else (
    echo No errors found in build output.
    echo.
    echo Try: dotnet build --verbosity detailed
)
echo.
pause
