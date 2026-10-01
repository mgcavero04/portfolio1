# Stage 1: Build Environment....change this to the version of .NET you are using
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /src

# Copy project files and restore packages...change this to the name of your project file, also in lines: 11 and 24
COPY ["API.csproj", "./"]
RUN dotnet restore "API.csproj"

# Copy everything else and publish release build
COPY . .
RUN dotnet publish "API.csproj" -c Release -o /app/publish

# Stage 2: Runtime Environment
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime-env
WORKDIR /app
COPY --from=build-env /app/publish .

# Expose Render standard ports
# 👇 CRITICAL FIX: Force container to use polling at the system root level
ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_HOSTINGSTARTUP__EXCLUDEASSEMBLIES=Microsoft.AspNetCore.Watch.BrowserLink
ENV ASPNETCORE_HTTP_PORTS=10000

ENTRYPOINT ["dotnet", "API.dll"]


