
echo -----------------------------------------
echo *** Test Script for parameter ***
echo -----------------------------------------

dotnet ef migrations add %1 -p C:\Users\91734\Desktop\EventManager\Events\src\Ceremonies.Events\Ceremonies.Events.InfrastructureCeremonies.Events.Infrastructure.csproj

dotnet ef migrations script --idempotent --output C:\Users\91734\Desktop\EventManager\Events\deploy\script.sql
