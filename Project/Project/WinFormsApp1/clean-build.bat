@echo off
echo Cleaning build artifacts...
if exist "bin" rmdir /s /q "bin"
if exist "obj" rmdir /s /q "obj"
echo Done! Now rebuild your project in Visual Studio.
pause
