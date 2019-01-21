FROM microsoft/dotnet:sdk As build-env
WORKDIR /app


# Copiar csproj e restore como camadas distintas
COPY *.csproj ./
RUN dotnet restore


# Copiar todo o resto e buildar
COPY . ./
RUN dotnet publish -c Release -o out


# Construir imagem de tempo de execucao
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "ApiRelatorios.dll" ]