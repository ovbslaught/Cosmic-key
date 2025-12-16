param(
    [Parameter(Mandatory=$true)]
    [string]$TargetDir
)

$SourceDir = $PSScriptRoot

if (-not (Test-Path $TargetDir)) {
    Write-Host "Target directory does not exist. Creating..."
    New-Item -ItemType Directory -Path $TargetDir -Force
}

Write-Host "Syncing from $SourceDir to $TargetDir..."
robocopy $SourceDir $TargetDir /MIR /XD .git .vs bin obj App_Data /XF *.user

Write-Host "Sync Complete."
