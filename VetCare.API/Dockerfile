FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VetCare.API/VetCare.API.csproj", "VetCare.API/"]
RUN dotnet restore "VetCare.API/VetCare.API.csproj"
COPY . .
WORKDIR "/src/VetCare.API"
RUN dotnet build "VetCare.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VetCare.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VetCare.API.dll"]
