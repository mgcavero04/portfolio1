# Stage 1: Build the React Frontend (Client)
FROM node:20-alpine AS frontend-build
WORKDIR /app
COPY client/package*.json ./client/
WORKDIR /app/client
RUN npm install
COPY client/ ./
RUN npm run build

# Stage 2: Build the C# Backend Environment
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS backend-build
WORKDIR /src

COPY ["API/API.csproj", "API/"]
RUN dotnet restore "API/API.csproj"

COPY . .

# Inject the React compiled dist files straight into the API's wwwroot folder
COPY --from=frontend-build /app/API/wwwroot ./API/wwwroot

RUN dotnet clean "API/API.csproj" -c Release
RUN dotnet publish "API/API.csproj" -c Release -o /app/publish --no-restore /p:UseAppHost=false

# Stage 3: Execution Runtime Environment
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final-runtime
WORKDIR /app
COPY --from=backend-build /app/publish .

USER root
RUN apt-get update && apt-get install -y libgssapi-krb5-2 && rm -rf /var/lib/apt/lists/*

ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_HOSTINGSTARTUP__EXCLUDEASSEMBLIES=Microsoft.AspNetCore.Watch.BrowserLink
ENV ASPNETCORE_HTTP_PORTS=10000

ENTRYPOINT ["dotnet", "API.dll"]
