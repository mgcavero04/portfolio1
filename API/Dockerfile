# Stage 1: Build Environment
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env
WORKDIR /src

# Copy project files and restore packages
COPY ["API.csproj", "./"]
RUN dotnet restore "API.csproj"

# Copy everything else and publish release build
COPY . .
RUN dotnet publish "API.csproj" -c Release -o /app/publish

# Stage 2: Runtime Environment
FROM ://microsoft.com AS runtime-env
WORKDIR /app
COPY --from=build-env /app/publish .

# Expose Render standard ports
ENV ASPNETCORE_HTTP_PORTS=10000

ENTRYPOINT ["dotnet", "API.dll"]


