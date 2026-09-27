FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
RUN apt update && apt install -y nodejs
COPY ["src/MaleFashion.Web/MaleFashion.Web.csproj","MaleFashion.Web/"]
COPY ["src/MaleFashion.Domain/MaleFashion.Domain.csproj","MaleFashion.Domain/"]
COPY ["src/MaleFashion.Application/MaleFashion.Application.csproj","MaleFashion.Application/"]
COPY ["src/MaleFashion.Infrastructure/MaleFashion.Infrastructure.csproj","MaleFashion.Infrastructure/"]
RUN dotnet restore "MaleFashion.Web/MaleFashion.Web.csproj"

COPY ./src/ .
WORKDIR "/src/MaleFashion.Web"
RUN dotnet build "MaleFashion.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MaleFashion.Web.csproj" -c Release -o /app

FROM build AS final 
WORKDIR /app
COPY --from=publish /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "MaleFashion.Web.dll"]