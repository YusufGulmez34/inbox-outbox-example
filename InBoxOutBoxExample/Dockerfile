#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/InBoxOutBoxExample.API/InBoxOutBoxExample.API.csproj", "Presentation/InBoxOutBoxExample.API/"]
COPY ["Infrastructure/InBoxOutBoxExample.Persistence", "Infrastructure/InBoxOutBoxExample.Persistence/"]

# RUN dotnet ef --startup-project ./Infrastructure/InBoxOutBoxExample.Persistence migrations add mig_1
RUN dotnet restore "Presentation/InBoxOutBoxExample.API/InBoxOutBoxExample.API.csproj"
COPY . .
WORKDIR "/src/Presentation/InBoxOutBoxExample.API"
RUN dotnet build "InBoxOutBoxExample.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InBoxOutBoxExample.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./appsettings.json /app
ENTRYPOINT ["dotnet", "InBoxOutBoxExample.API.dll"]