FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything and restore/publish the specific web project
COPY . .
RUN dotnet restore "src/CRM.API/CRM.API.csproj"
RUN dotnet publish "src/CRM.API/CRM.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Listen on port 80
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Replace CRM.API.dll with your assembly name if different
ENTRYPOINT ["dotnet", "CRM.API.dll"]
