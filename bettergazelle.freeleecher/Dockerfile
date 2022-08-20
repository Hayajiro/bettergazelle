FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["bettergazelle.freeleecher/bettergazelle.freeleecher.csproj", "bettergazelle.freeleecher/"]
RUN dotnet restore "bettergazelle.freeleecher/bettergazelle.freeleecher.csproj"
COPY . .
WORKDIR "/src/bettergazelle.freeleecher"
RUN dotnet build "bettergazelle.freeleecher.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "bettergazelle.freeleecher.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bettergazelle.freeleecher.dll"]
