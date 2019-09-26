FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["src-demo/GrpcServer/GrpcServer.csproj", "src-demo/GrpcServer/"]
RUN dotnet restore "src-demo/GrpcServer/GrpcServer.csproj"
COPY . .
WORKDIR "/src/src-demo/GrpcServer"
RUN dotnet build "GrpcServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcServer.dll"]