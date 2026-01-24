# Script to remove Zone.Identifier alternate data streams from all files
# This fixes MSB3821 build errors caused by "mark of the web"

$projectPath = $PSScriptRoot
$files = Get-ChildItem -Path $projectPath -Recurse -File

$removedCount = 0
foreach ($file in $files) {
    $zoneId = $file.FullName + ':Zone.Identifier'
    try {
        # Use Get-Item to check if the alternate data stream exists
        $stream = Get-Item $zoneId -ErrorAction SilentlyContinue
        if ($stream) {
            Remove-Item $zoneId -Force -ErrorAction SilentlyContinue
            $removedCount++
        }
    }
    catch {
        # Silently continue if stream doesn't exist or can't be removed
    }
}

if ($removedCount -gt 0) {
    Write-Host "Removed Zone.Identifier from $removedCount file(s)." -ForegroundColor Green
}
