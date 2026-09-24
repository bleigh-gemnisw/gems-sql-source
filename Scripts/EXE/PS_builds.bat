SET PATH=%PATH%;C:\Program Files (x86)\CrSSL\bin;%USERPROFILE%\AppData\Local\Microsoft\WindowsApps;C:\Program Files\Azure Data Studio\bin;%USERPROFILE%\.dotnet\tools;C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\amd64;
msbuild.exe "c:\gems source sql\ps source\ps001\ps001.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ps source\ps002\ps002.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ps source\ps003\ps003.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ps source\ps004\ps004.sln" /property:configuration=release
