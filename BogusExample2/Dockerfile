FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BogusExample2/BogusExample2.csproj", "BogusExample2/"]
RUN dotnet restore "BogusExample2/BogusExample2.csproj"
COPY . .
WORKDIR "/src/BogusExample2"
RUN dotnet build "BogusExample2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BogusExample2.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BogusExample2.dll"]
