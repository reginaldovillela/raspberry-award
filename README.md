# Raspberry Award

## Requeriments to run it
1. .net 8 SDK 8.0.403 - You can download [here](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-8.0.403-windows-x64-installer) or you can run a powershell script [here](https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.ps1)
2. Visual Studio 2022 - Download [here](https://c2rsetup.officeapps.live.com/c2r/downloadVS.aspx?sku=community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030:df218f5dcfc04cbe873863980478f51a) Or VS Code download [here](https://code.visualstudio.com/docs/?dv=win64)
3. NodeJS - Download [here] (https://nodejs.org/dist/v22.12.0/node-v22.12.0-x64.msi)
4. Angular 19 ```npm install -g @angular/cli```


## To run it
1. To run backend project (a .net project), on VS 2022 open the solution e run the RaspberryAwardAPI.
2. To run backend project (a .net project), on VS Code:
- cd src/backend/RaspeberryAwardAPI
- dotnet build
- dotnet run

The backend project (RaspberryAwardAPI) will run at 5000 port.

```
3. To run frontend project (RaspeberryAward), on VS Code:
- cd src/frontend
- ng serve

```

## What I did and used?

1. Techs
- .Net 8
- Angular 19
- NodeJS 22
- VS Code and Rider to develop
- Dev Container to running environments

2. Design Patterns
- DDD
- Repository
- UnitOfWork
- CQRS With MediatR Lib
- IoC and DI
- Extensions Patterns
