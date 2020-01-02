@echo off

set tag=0.1
set workdir=C:\publish\docker\CodeSnippets.IdentityCenter\
set repo=zhaobingwang/codesnippets.identitycenter

@echo Default Tag:%tag%
@echo Default Working Directory:%workdir%
@echo Default Repository:%repo%

@echo Set variables(If no value is entered,the default value will be used)

set /p tag=Tag:
set /p workdir=Working directory:
set /p repo=Repository:

@echo Locate to the working directory
cd %workdir%


@echo Docker login:
docker login

@echo Docker build:
docker build -t %repo%:%tag% .

@echo Docker push
docker push %repo%:%tag%

pause