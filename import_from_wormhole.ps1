param(
    [Parameter(Mandatory = $true)]
    [string]$SourceDriveDir
)

$TargetRepoDir = $PSScriptRoot

if (-not (Test-Path $SourceDriveDir)) {
    Write-Host "Error: Source Drive directory '$SourceDriveDir' does not exist." -ForegroundColor Red
    exit 1
}

Write-Host "Integrating data from Drive ($SourceDriveDir) into Repository ($TargetRepoDir)..."
Write-Host "Policy: Zero Data Loss. New and newer files will be copied. NO files will be deleted."

# /E - Subdirectories including empty
# /XO - Exclude Older (only copy if source is newer)
# /XC - Exclude Changed (optional, but usually we want newer) -- actually standard robocopy defaults to overwriting if different. 
# We want to bring in everything that is NOT in repo, or IS in repo but older.
# Robocopy default behavior is: Copy if file is different (time/size).
# We definitely do NOT want /MIR (which deletes).

robocopy $SourceDriveDir $TargetRepoDir /E /XO /XD .git .vs bin obj App_Data /XF *.user

Write-Host "Integration Complete. Please check 'git status' to see new files."
