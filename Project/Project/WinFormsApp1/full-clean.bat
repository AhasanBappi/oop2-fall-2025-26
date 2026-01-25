@echo off
echo ========================================
echo Full Clean Build Script
echo ========================================
echo.
echo Deleting build artifacts...
if exist "bin" (
    echo Removing bin folder...
    rmdir /s /q "bin"
)
if exist "obj" (
    echo Removing obj folder...
    rmdir /s /q "obj"
)
echo.
echo Done! Now:
echo 1. Close Visual Studio completely
echo 2. Reopen Visual Studio
echo 3. Build -^> Clean Solution
echo 4. Build -^> Rebuild Solution
echo.
pause
