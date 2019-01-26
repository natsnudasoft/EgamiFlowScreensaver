@echo off
SET openCoverVersion=4.6.519
SET xunitRunnerVersion=2.4.1
SET reportGeneratorVersion=4.0.9
SET coverallsVersion=1.4.2
IF "%1"=="buildserver" (
    "%~dp0..\packages\OpenCover.%openCoverVersion%\tools\OpenCover.Console.exe" -register:user "-filter:+[*]* -[*Tests]*" -target:"%~dp0..\packages\xunit.runner.console.%xunitRunnerVersion%\tools\net472\xunit.console.exe" -targetargs:"\"%~dp0..\test\unit\EgamiFlowScreensaver.Test\bin\Release\Natsnudasoft.EgamiFlowScreensaver.Test.dll\" -noshadow -appveyor" -excludebyattribute:*.ExcludeFromCodeCoverage* -excludebyfile:*Designer.cs -output:coverage.xml
    "%~dp0..\packages\coveralls.io.%coverallsVersion%\tools\coveralls.net.exe" --opencover coverage.xml
    IF %errorlevel%==0 echo Report generated and sent to coveralls...
) ELSE (
    "%~dp0..\packages\OpenCover.%openCoverVersion%\tools\OpenCover.Console.exe" -register:user "-filter:+[*]* -[*Tests]*" -target:"%~dp0..\packages\xunit.runner.console.%xunitRunnerVersion%\tools\net472\xunit.console.exe" -targetargs:"\"%~dp0..\test\unit\EgamiFlowScreensaver.Test\bin\Debug\Natsnudasoft.EgamiFlowScreensaver.Test.dll\" -noshadow" -excludebyattribute:*.ExcludeFromCodeCoverage* -excludebyfile:*Designer.cs -output:coverage.xml
    "%~dp0..\packages\ReportGenerator.%reportGeneratorVersion%\tools\net47\ReportGenerator.exe" -reports:coverage.xml -targetdir:coverage
    echo Press any key to display report...
    pause >nul
    start coverage\index.htm
)