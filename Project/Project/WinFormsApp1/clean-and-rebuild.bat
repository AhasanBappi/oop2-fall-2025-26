@echo off
echo Cleaning project...
if exist "bin" rmdir /s /q "bin"
if exist "obj" rmdir /s /q "obj"
echo Clean complete.
echo.
echo Building project...
dotnet build
echo.
echo Build complete!
pause
