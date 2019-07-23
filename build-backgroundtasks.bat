@echo off

echo "Windows Docker Image build"

cd src-project-dotnetcore/Sample.NetCore.HostBackgroundTasks

dotnet publish -c Release -o bin/Release/publish

cd bin/Release/publish

echo "publish success"

docker stop samplebg01
docker rm samplebg01
docker build -t sample.bg .
docker run -d -v C:/docker/sample/logs:/app/logs --name samplebg01 sample.bg