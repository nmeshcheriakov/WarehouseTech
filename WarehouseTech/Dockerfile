FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["WarehouseTech.csproj", "./"]
RUN dotnet restore "WarehouseTech.csproj"
COPY . .
RUN dotnet publish "WarehouseTech.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WarehouseTech.dll"]