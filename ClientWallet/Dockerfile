FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ClientWallet/ClientWallet.csproj", "ClientWallet/"]
RUN dotnet restore "ClientWallet/ClientWallet.csproj"
COPY . .
WORKDIR "/src/ClientWallet"
RUN dotnet build "ClientWallet.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ClientWallet.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ClientWallet.dll"]