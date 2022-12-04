REM 64 bit
set ApiPublishFolder="\\vmware-host\Shared Folders\VMWare-Share\TestTools\Deploy\API\x64\"
if exist %ApiPublishFolder% rmdir %ApiPublishFolder% /s /q
mkdir %ApiPublishFolder%
dotnet publish C:\repos\UnifiCSharp\Api\UnifiApi.csproj -c Release -r win-x64 --no-self-contained -o %ApiPublishFolder%
copy "\\vmware-host\Shared Folders\VMWare-Share\TestTools\Program\UnifiTasks.json" %ApiPublishFolder% /y

REM 32 bit
set ApiPublishFolder="\\vmware-host\Shared Folders\VMWare-Share\TestTools\Deploy\API\x86\"
if exist %ApiPublishFolder% rmdir %ApiPublishFolder% /s /q
mkdir %ApiPublishFolder%
dotnet publish -c Release -r win-x86 --no-self-contained -o %ApiPublishFolder%
copy "\\vmware-host\Shared Folders\VMWare-Share\TestTools\Program\UnifiTasks.json" %ApiPublishFolder% /y