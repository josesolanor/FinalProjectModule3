FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ApiWallet/ApiWallet.csproj", "ApiWallet/"]
RUN dotnet restore "ApiWallet/ApiWallet.csproj"
COPY . .
WORKDIR "/src/ApiWallet"
RUN dotnet build "ApiWallet.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiWallet.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiWallet.dll"]