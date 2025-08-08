FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["VidEngine.Api/VidEngine.Api.csproj", "VidEngine.Api/"]
RUN dotnet restore "VidEngine.Api/VidEngine.Api.csproj"
COPY . .
WORKDIR "/src/VidEngine.Api"
RUN dotnet build "VidEngine.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VidEngine.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["VidEngine.Api/certificates/devcert.pfx", "https/devcert.pfx"]
ENTRYPOINT ["dotnet", "VidEngine.Api.dll"]
