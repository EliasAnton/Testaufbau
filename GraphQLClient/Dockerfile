FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GraphQLClient/GraphQLClient.csproj", "GraphQLClient/"]
RUN dotnet restore "GraphQLClient/GraphQLClient.csproj"
COPY . .
WORKDIR "/src/GraphQLClient"
RUN dotnet build "GraphQLClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GraphQLClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GraphQLClient.dll"]
