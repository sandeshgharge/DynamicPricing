echo "Running SQL Queries to insert Sample data..."

dotnet tool install --global dotnet-ef
RUN dotnet ef database update --context DynamicPricingContext

sqlite3 /app/DynamicPricing.db < /app/SampleDataScripts.sql

echo "SQL Queries Executed."