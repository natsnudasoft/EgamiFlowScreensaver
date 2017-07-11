$newVersion = "$env:GitVersion_MajorMinorPatch.0"
$newVersionComma = $newVersion -replace "\.",","
Write-Output "Updating files with new version number: $newVersion"

#Update app.manifest
Write-Output "Updating app.manifest version number."
$appManifestPath = "$PSScriptRoot\..\src\EgamiFlowScreensaver\app.manifest"
$pattern = '(.*?)version="(0.1.0.0)"'
(Get-Content $appManifestPath) | ForEach-Object{
    if($_ -match $pattern){
        $matches[1] + 'version="{0}"' -f $newVersion
    } else {
        $_
    }
} | Set-Content $appManifestPath -Encoding UTF8

#Update NativeRes.rc2
Write-Output "Updating NativeRes.rc2 version number."
$nativeResPath = "$PSScriptRoot\..\src\EgamiFlowScreensaver\Properties\NativeRes.rc2"
$fileVersionStrPattern = '(.*?)FILEVERSION 0,1,0,0'
$productVersionStrPattern = '(.*?)PRODUCTVERSION 0,1,0,0'
$fileVersionPattern = '(.*?)"FileVersion", "0.1.0.0"'
$productVersionPattern = '(.*?)"ProductVersion", "0.1.0.0"'
(Get-Content $nativeResPath) | ForEach-Object{
    if($_ -match $fileVersionStrPattern){
        $matches[1] + 'FILEVERSION {0}' -f $newVersionComma
    } elseif($_ -match $productVersionStrPattern){
        $matches[1] + 'PRODUCTVERSION {0}' -f $newVersionComma
    } elseif($_ -match $fileVersionPattern){
        $matches[1] + '"FileVersion", "{0}"' -f $newVersion
    } elseif($_ -match $productVersionPattern){
        $matches[1] + '"ProductVersion", "{0}"' -f $newVersion
    } else {
        $_
    }
} | Set-Content $nativeResPath -Encoding Unicode