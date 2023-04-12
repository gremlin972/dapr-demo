# dapr-ps-demo
Cloud training assignment

### How to run

dapr run --app-id processor_eggs --log-level error --resources-path ../components/ --app-port 7005 -- dotnet run --project . --urls=http://localhost:7005/

dapr run --app-id processor_toast --log-level error --resources-path ../components/ --app-port 7006 -- dotnet run --project . --urls=http://localhost:7006/

dapr run --app-id processor_bacon --log-level error --resources-path ../components/ --app-port 7007 -- dotnet run --project . --urls=http://localhost:7007/

dapr run --app-id delivery --log-level error --resources-path ../components/ --app-port 7008 -- dotnet run --project . --urls=http://localhost:7008/

dapr run --app-id checkout --log-level error --resources-path ../components/ -- dotnet run --project .

### References

- [original repo](https://github.com/dapr/quickstarts/tree/master/pub_sub/csharp/sdk)
- [Azure deploy tutorial] (https://learn.microsoft.com/en-us/azure/container-apps/microservices-dapr-pubsub?pivots=csharp)
