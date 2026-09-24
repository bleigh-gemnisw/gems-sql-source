SET PATH=%PATH%;C:\Program Files (x86)\CrSSL\bin;%USERPROFILE%\AppData\Local\Microsoft\WindowsApps;C:\Program Files\Azure Data Studio\bin;%USERPROFILE%\.dotnet\tools;C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\amd64;
msbuild.exe "c:\gems source sql\mr source\mr001\mr001.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\mr source\mr101\mr101.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\mr source\mr200\mr200.sln" /property:configuration=release
pause