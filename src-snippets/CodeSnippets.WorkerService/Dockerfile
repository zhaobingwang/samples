#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src-snippets/CodeSnippets.WorkerService/CodeSnippets.WorkerService.csproj", "src-snippets/CodeSnippets.WorkerService/"]
RUN dotnet restore "src-snippets/CodeSnippets.WorkerService/CodeSnippets.WorkerService.csproj"
COPY . .
WORKDIR "/src/src-snippets/CodeSnippets.WorkerService"
RUN dotnet build "CodeSnippets.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CodeSnippets.WorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodeSnippets.WorkerService.dll"]