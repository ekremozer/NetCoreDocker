FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY bin/Release/net6.0/publish /App/
ENTRYPOINT ["dotnet","NetCoreDocker.Console.dll"]