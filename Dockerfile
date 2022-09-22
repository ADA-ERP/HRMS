FROM  mcr.microsoft.com/dotnet/sdk:6.0 As build-env
WORKDIR /src 

COPY . ./
RUN  dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /src
EXPOSE 7093
COPY --from=build-env /src/out .
ENTRYPOINT [ "dotnet","BootStrapper.dll" ]

