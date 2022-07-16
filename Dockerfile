FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /App
COPY ./NetCoreDocker.Web/*.csproj ./NetCoreDocker.Web/
COPY ./NetCoreDocker.Utility/*.csproj ./NetCoreDocker.Utility/
COPY *.sln .
RUN dotnet restore
COPY . .
#RUN dotnet test ./NetCoreDocker.Test/*.csproj
RUN dotnet publish ./NetCoreDocker.Web/*.csproj -c Release -o /publishfolder/
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build /publishfolder .
ENV ASPNETCORE_URLS="http://*:4600"
ENTRYPOINT ["dotnet","NetCoreDocker.Web.dll"]	