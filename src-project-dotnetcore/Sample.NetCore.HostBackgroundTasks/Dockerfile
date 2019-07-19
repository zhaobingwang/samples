#FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
#WORKDIR /src
#COPY ["src/CSTree.BackgroundTasks/CSTree.BackgroundTasks.csproj", "src/CSTree.BackgroundTasks/"]
#RUN dotnet restore "src/CSTree.BackgroundTasks/CSTree.BackgroundTasks.csproj"
#COPY . .
#WORKDIR "/src/src/CSTree.BackgroundTasks"
#RUN dotnet build "CSTree.BackgroundTasks.csproj" -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish "CSTree.BackgroundTasks.csproj" -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "CSTree.BackgroundTasks.dll"]

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY . .
EXPOSE 80
ENTRYPOINT ["dotnet", "Sample.NetCore.HostBackgroundTasks.dll"]