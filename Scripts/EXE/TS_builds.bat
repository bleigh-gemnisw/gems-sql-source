SET PATH=%PATH%;C:\Program Files (x86)\CrSSL\bin;%USERPROFILE%\AppData\Local\Microsoft\WindowsApps;C:\Program Files\Azure Data Studio\bin;%USERPROFILE%\.dotnet\tools;C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\amd64;
msbuild.exe "c:\gems source sql\ts source\ts001\ts001.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ts source\ts002\ts002.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ts source\ts003\ts003.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ts source\ts004\ts004.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ts source\ts005\ts005.sln" /property:configuration=release
msbuild.exe "c:\gems source sql\ts source\ts006\ts006.sln" /property:configuration=release
