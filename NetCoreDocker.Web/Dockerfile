#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /App
#COPY bin/Release/net6.0/publish /App/
#ENTRYPOINT ["dotnet","NetCoreDocker.Web.dll"]

#FROM mcr.microsoft.com/dotnet/sdk:6.0
#WORKDIR /App
#COPY . .
#RUN dotnet restore
#RUN dotnet publish NetCoreDocker.Web.csproj -c Release -o publishfolder
#WORKDIR publishfolder
#ENV ASPNETCORE_URLS="http://*:4600"
#ENTRYPOINT ["dotnet","NetCoreDocker.Web.dll"]

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /App
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish NetCoreDocker.Web.csproj -c Release -o publishfolder
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build /App/publishfolder .
ENV ASPNETCORE_URLS="http://*:4600"
ENV MySite="ekremozer.com"
ENTRYPOINT ["dotnet","NetCoreDocker.Web.dll"]