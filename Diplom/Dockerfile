#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Diplom/Diplom.csproj", "Diplom/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["Helper/Helper.csproj", "Helper/"]
RUN dotnet restore "Diplom/Diplom.csproj"
COPY . .
WORKDIR "/src/Diplom"
RUN dotnet build "Diplom.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Diplom.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diplom.dll"]