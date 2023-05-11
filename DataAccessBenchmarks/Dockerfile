FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DataAccessBenchmarks/DataAccessBenchmarks.csproj", "DataAccessBenchmarks/"]
RUN dotnet restore "DataAccessBenchmarks/DataAccessBenchmarks.csproj"
COPY . .
WORKDIR "/src/DataAccessBenchmarks"
RUN dotnet build "DataAccessBenchmarks.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataAccessBenchmarks.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataAccessBenchmarks.dll"]
