@echo off
powershell -ExecutionPolicy Bypass -NoProfile -Command "Get-ChildItem -Path '%1' -Recurse -File | ForEach-Object { $zoneId = $_.FullName + ':Zone.Identifier'; try { $stream = Get-Item $zoneId -ErrorAction SilentlyContinue; if ($stream) { Remove-Item $zoneId -Force -ErrorAction SilentlyContinue } } catch {} }"
exit /b 0
