@echo off
echo ------------ Preparing artifacts ------------
IF "%1"=="buildserver" (
    Tools.InnoSetup\tools\iscc /O"artifact\EgamiFlowScreensaver" /Q EgamiFlowScreensaver.iss
    7z a EgamiFlowScreensaver_Release_Any_CPU.zip .\artifact\*
) ELSE (
    robocopy "%~dp0..\src\EgamiFlowScreensaver\bin\Windows\Release" artifact\EgamiFlowScreensaver Natsnudasoft.EgamiFlowScreensaver.exe /NDL /NJH /NJS /NP /NS /NC
    if exist artifact\EgamiFlowScreensaver\Natsnudasoft.EgamiFlowScreensaver.scr del artifact\EgamiFlowScreensaver\Natsnudasoft.EgamiFlowScreensaver.scr /q
    ren artifact\EgamiFlowScreensaver\Natsnudasoft.EgamiFlowScreensaver.exe Natsnudasoft.EgamiFlowScreensaver.scr
)
IF %errorlevel% LEQ 1 echo ------------ Artifacts prepared ------------
IF %errorlevel% LEQ 1 exit /B 0