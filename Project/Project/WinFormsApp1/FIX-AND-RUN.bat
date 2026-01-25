@echo off
echo ========================================
echo FIXING AND REBUILDING PROJECT
echo ========================================
echo.

echo Step 1: Closing Visual Studio processes...
taskkill /F /IM devenv.exe 2>nul
taskkill /F /IM WinFormsApp1.exe 2>nul
timeout /t 2 /nobreak >nul

echo.
echo Step 2: Deleting build folders...
if exist "bin" (
    rmdir /s /q "bin"
    echo Deleted bin folder
)
if exist "obj" (
    rmdir /s /q "obj"
    echo Deleted obj folder
)
if exist ".vs" (
    rmdir /s /q ".vs"
    echo Deleted .vs folder
)

echo.
echo Step 3: Cleaning project...
dotnet clean >nul 2>&1
echo Clean completed

echo.
echo Step 4: Restoring packages...
dotnet restore >nul 2>&1
echo Restore completed

echo.
echo Step 5: Building project...
dotnet build
if %ERRORLEVEL% EQU 0 (
    echo.
    echo ========================================
    echo BUILD SUCCESSFUL!
    echo ========================================
    echo.
    echo You can now run the project from Visual Studio (F5)
    echo OR run: dotnet run
    echo.
) else (
    echo.
    echo ========================================
    echo BUILD FAILED - Check errors above
    echo ========================================
    echo.
    pause
)
