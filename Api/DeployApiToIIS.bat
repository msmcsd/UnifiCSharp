REM This file should be run on target machine.

REM set CurrentFolder=%~dp0
set CurrentFolder="\\vmware-host\Shared Folders\VMWare-Share\TestTools\Deploy\"
set Appcmd=C:\windows\system32\inetsrv\appcmd

REM ##################################################################
REM # Create Application Pool "Unifi" in IIS
REM ##################################################################
set PoolName=Unifi
%Appcmd% list apppool | findstr %PoolName%
if %errorlevel% == 0 (
	%Appcmd% delete apppol %ApiSite%
)

%Appcmd% add apppool /name:%PoolName% /managedRuntimeVersion:"v4.0" /managedPipelineMode:"Integrated"

REM Assign the pool with local system privilege
%Appcmd% set apppool %PoolName% -processModel.identityType:LocalSystem

REM ##################################################################
REM # Deploy Api to IIS
REM ##################################################################
if %PROCESSOR_ARCHITECTURE% == x86 (
	set Arch=x86
) else (
	set Arch=x64
)

REM Create or Update Unifi Api site
set ApiDeploySrcFolder=%CurrentFolder%API\%Arch%\
set ApiDeployDstFolder=C:\inetpub\wwwroot\Unifi\Api\
set ApiSite=Unifi

%Appcmd% list site | findstr %ApiSite%
if %errorlevel% == 0 (
	%Appcmd% stop site %ApiSite%
	%Appcmd% delete site %ApiSite%
)

rmdir %ApiDeployDstFolder% /s /q
timeout 5

%Appcmd% add site /name:%ApiSite% /bindings:http://*:5000 /physicalPath:%ApiDeployDstFolder%

REM Assign app pool Unifi to this site
%Appcmd% set site /site.name:%ApiSite% /[path='/'].applicationPool:%PoolName%

if not exist %ApiDeployDstFolder% mkdir %ApiDeployDstFolder%
xcopy %ApiDeploySrcFolder% %ApiDeployDstFolder% /s /e /y

%Appcmd% start site %ApiSite%

REM ##################################################################
REM # Deploy Socket Server to IIS
REM ##################################################################
REM set ApiDeploySrcFolder=%CurrentFolder%SocketServer
REM set SocketDeployDstFolder=C:\inetpub\wwwroot\Unifi\SocketServer\
REM if exist %SocketDeployDstFolder% rmdir %SocketDeployDstFolder% /s /q
REM 
REM xcopy %ApiDeploySrcFolder% %SocketDeployDstFolder% /E/H/C/I



explorer http://localhost:5000/Api/Commands
