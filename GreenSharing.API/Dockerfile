#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV MORGANSTANLEY_BEARER_KEY "kBeQcs5eU1yH8vcEQuQq7mgVlhyj07B621x_fbIt09lDG_by3h7cZCUViptxdNkmhbpwxr9f7APysptcKhF7VLq9dfzCVi-gDmyXadt_XzYx9hByJVJpMQ9lA-hX5_5Vh54b_Dg3ApLBCGybY81-BS0x5jOxt7ga3Wzm5zXKVHLNWuwQgXJe0_a0AEj96iBfZNtq36dw301CReTz2A1xrs-WKRP14Wwm9iOYQtq_DB-ICr0SSBFUIJpop3gcUDiw3gSUahwGgbjIJKpk_fFCqcIPNqqlsjU-67imyP2rbEsK5AjqOxau8k0R3uXfl0wJDrL7wuIPlYZZbjK0m-BU0Q"
ENV ASPNETCORE_ENVIRONMENT "Development"

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GreenSharing.API.csproj", "."]
RUN dotnet restore "./GreenSharing.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GreenSharing.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GreenSharing.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GreenSharing.API.dll"]