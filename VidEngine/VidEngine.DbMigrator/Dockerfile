FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["VidEngine.DbMigrator/VidEngine.DbMigrator.csproj", "VidEngine.DbMigrator/"]
RUN dotnet restore "VidEngine.DbMigrator/VidEngine.DbMigrator.csproj"
COPY . .
WORKDIR "/src/VidEngine.DbMigrator"
RUN dotnet build "VidEngine.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VidEngine.DbMigrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VidEngine.DbMigrator.dll"]
