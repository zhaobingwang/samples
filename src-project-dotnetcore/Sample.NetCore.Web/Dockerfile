FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src-project-dotnetcore/Sample.NetCore.Web/Sample.NetCore.Web.csproj", "src-project-dotnetcore/Sample.NetCore.Web/"]
RUN dotnet restore "src-project-dotnetcore/Sample.NetCore.Web/Sample.NetCore.Web.csproj"
COPY . .
WORKDIR "/src/src-project-dotnetcore/Sample.NetCore.Web"
RUN dotnet build "Sample.NetCore.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Sample.NetCore.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Sample.NetCore.Web.dll"]