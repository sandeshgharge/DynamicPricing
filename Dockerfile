# Step 1: Specify the base image (build stage)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Step 2: Set the working directory
WORKDIR /app

# Step 3: Copy the .csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Step 4: Copy the rest of the application files
COPY . ./

# Step 5: Build the application
RUN dotnet publish -c Release -o out

# Step 5.1: Script to enter sample data reqiured for the project
# RUN dotnet ef migrations add InitialCreate --context DynamicPricingContext
# RUN dotnet tool install --global dotnet-ef
# RUN dotnet ef migrations add InitialCreate -n DynamicPricing.Data
# RUN dotnet ef database update --context /app/data/DynamicPricingContext

# RUN sqlite3 /app/DynamicPricing.db < /SampleDataScripts.sql
RUN chmod +x /app/executeSQL.sh
RUN ./executeSQL.sh
# Step 6: Specify the runtime image (runtime stage)
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Step 7: Set the working directory in runtime image
WORKDIR /app

# Step 8: Copy the build output from the previous stage
COPY --from=build-env /app/out .

# Step 9: Expose the port (optional, depending on the app)
# This lines tells the application that 5234 is open but do not force the servers to start on 5234
EXPOSE 5234

# Step 10: Specify the entry point to run the application
ENTRYPOINT ["dotnet", "DynamicPricing.dll"]
# ENTRYPOINT ["DynamicPricing"]