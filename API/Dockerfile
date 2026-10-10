# Stage 1: Build the React Frontend (Client)
FROM node:20-alpine AS frontend-build
WORKDIR /app
# Copy the frontend package definitions and install dependencies
COPY client/package*.json ./
RUN npm install
# Copy the rest of the frontend source files and build the production assets
COPY client/ ./
RUN npm run build

# Stage 2: Build the C# Backend Environment
FROM ://microsoft.com AS backend-build
WORKDIR /src

COPY ["API/API.csproj", "API/"]
RUN dotnet restore "API/API.csproj"

COPY . .

# 👇 CRITICAL FIX: Inject the React compiled dist files straight into the API's wwwroot folder
COPY --from=frontend-build /app/dist ./API/wwwroot

# Clear lingering build targets and compile the complete application package
RUN dotnet clean "API/API.csproj" -c Release
RUN dotnet publish "API/API.csproj" -c Release -o /app/publish --no-restore /p:UseAppHost=false

# Stage 3: Execution Runtime Environment
FROM ://microsoft.com AS final-runtime
WORKDIR /app
COPY --from=backend-build /app/publish .

# Install missing Kerberos/GSSAPI dependency libraries required by Npgsql
USER root
RUN apt-get update && apt-get install -y libgssapi-krb5-2 && rm -rf /var/lib/apt/lists/*

ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_HOSTINGSTARTUP__EXCLUDEASSEMBLIES=Microsoft.AspNetCore.Watch.BrowserLink
ENV ASPNETCORE_HTTP_PORTS=10000

ENTRYPOINT ["dotnet", "API.dll"]
