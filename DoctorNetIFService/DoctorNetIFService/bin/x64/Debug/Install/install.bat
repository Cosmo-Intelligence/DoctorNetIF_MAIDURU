echo off

rem ===================================================
rem 該当APがあるフォルダへ移動するため、パスを設定する
rem ===================================================
cd C:\DoctorNetIFService\Install

rem ===================================================
rem 32bitアプリの場合
rem ===================================================
rem C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe ..\DoctorNetIFService.exe

rem ===================================================
rem 64bitアプリの場合
rem ===================================================
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe ..\DoctorNetIFService.exe

pause
