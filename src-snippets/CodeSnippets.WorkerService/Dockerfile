#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS runtime
WORKDIR /app

COPY . .
ENTRYPOINT ["dotnet", "CodeSnippets.WorkerService.dll"]