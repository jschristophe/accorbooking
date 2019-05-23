# STAGE01 - Build application and its dependencies
FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app
#COPY WebApp/*.csproj ./
COPY . ./
RUN dotnet restore ./AccorBooking_API_HOTEL/AccorBooking_API_CATALOG.csproj

# STAGE02 - Publish the application
FROM build-env AS publish
#RUN ls AccorBooking_API_HOTEL/
RUN dotnet publish -c Release AccorBooking_API_HOTEL/ -o /app

# STAGE03 - Create the final image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=publish /app .
RUN ls
RUN ls /app
RUN ls /app/AccorBooking_API_HOTEL
RUN ls /app/AccorBooking_API_HOTEL/bin
ENTRYPOINT ["dotnet", "AccorBooking_API_CATALOG.dll", "--server.urls", "http://*:80"]