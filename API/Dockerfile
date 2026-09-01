FROM ://microsoft.com AS build
WORKDIR /src
COPY ["API.csproj", "./"]
RUN dotnet restore "API.csproj"
COPY . .
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM ://microsoft.com AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_HTTP_PORTS=10000
ENTRYPOINT ["dotnet", "API.dll"]
