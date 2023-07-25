#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Challenge.Konsi.Web/Challenge.Konsi.Web.csproj", "src/Challenge.Konsi.Web/"]
COPY ["src/Challenge.Konsi.Application/Challenge.Konsi.Application.csproj", "src/Challenge.Konsi.Application/"]
COPY ["src/Challenge.Konsi.Domain/Challenge.Konsi.Domain.csproj", "src/Challenge.Konsi.Domain/"]
COPY ["src/Challenge.Konsi.Infrastructure/Challenge.Konsi.Infrastructure.csproj", "src/Challenge.Konsi.Infrastructure/"]
COPY ["src/Challenge.Konsi.Persistence/Challenge.Konsi.Persistence.csproj", "src/Challenge.Konsi.Persistence/"]
COPY ["src/Challenge.Konsi.Presentation/Challenge.Konsi.Presentation.csproj", "src/Challenge.Konsi.Presentation/"]
COPY ["src/Challenge.Konsi.Integration/Challenge.Konsi.Integration.csproj", "src/Challenge.Konsi.Integration/"]
RUN dotnet restore "src/Challenge.Konsi.Web/Challenge.Konsi.Web.csproj"
COPY . .
WORKDIR "/src/src/Challenge.Konsi.Web"
RUN dotnet build "Challenge.Konsi.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Challenge.Konsi.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Challenge.Konsi.Web.dll"]