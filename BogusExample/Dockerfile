FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BogusExample/BogusExample.csproj", "BogusExample/"]
RUN dotnet restore "BogusExample/BogusExample.csproj"
COPY . .
WORKDIR "/src/BogusExample"
RUN dotnet build "BogusExample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BogusExample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BogusExample.dll"]
