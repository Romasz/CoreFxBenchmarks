@echo off

powershell -ExecutionPolicy ByPass -NoProfile -File "runTestScript.ps1" %*

exit /b %ERRORLEVEL%
