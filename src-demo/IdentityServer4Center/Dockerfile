FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src-demo/IdentityServer4Center/IdentityServer4Center.csproj", "src-demo/IdentityServer4Center/"]
RUN dotnet restore "src-demo/IdentityServer4Center/IdentityServer4Center.csproj"
COPY . .
WORKDIR "/src/src-demo/IdentityServer4Center"
RUN dotnet build "IdentityServer4Center.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IdentityServer4Center.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IdentityServer4Center.dll"]