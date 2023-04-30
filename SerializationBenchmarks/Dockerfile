FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SerialisationBenchmarks/SerialisationBenchmarks.csproj", "SerialisationBenchmarks/"]
RUN dotnet restore "SerialisationBenchmarks/SerialisationBenchmarks.csproj"
COPY . .
WORKDIR "/src/SerialisationBenchmarks"
RUN dotnet build "SerialisationBenchmarks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SerialisationBenchmarks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SerialisationBenchmarks.dll"]
