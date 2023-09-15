FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as base
WORKDIR /src

COPY ["./Tests/UnitTests/Core.Tests/", "martianRobots/Tests/UnitTests/Core.Tests/"] 
COPY ["./App/", "martianRobots/App/"] 
RUN dotnet restore "martianRobots/App/martianRobots.csproj" 
RUN dotnet restore "martianRobots/Tests/UnitTests/Core.Tests/Core.Tests.csproj" 
RUN dotnet test "martianRobots/Tests/UnitTests/Core.Tests/Core.Tests.csproj" -l "console;verbosity=detailed" -t

WORKDIR /App
COPY ./App .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app
COPY --from=base /app/published-app /app

ENV ASPNETCORE_HTTP_PORT=https://+:5001
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT [ "dotnet", "/app/martianRobots.dll" ]
