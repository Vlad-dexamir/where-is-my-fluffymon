# Where's Fluffymon?
This is a serverless web application based on Next.js and .Net Core with Azure Functions
## Setup for processor
1) Install .Net SDK (v3.10, v5) from https://dotnet.microsoft.com/download/dotnet/5.0 .
2) Install Azure Functions Core Tool from https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=windows%2Ccsharp%2Cbash .
3) Clone repository.

### Person Microservice:
- Create a file named `local.settings.json` with:

```{
"IsEncrypted": false,
"Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "COSMOS_DB_CONNECTION_STRING": AZURE PORTAL -> AZURE COSMOS DB -> where-is-my-fluffymon-dev -> ConnectionString,
    "PERSON_DATABASE_NAME": AZURE PORTAL -> AZURE COSMOS DB -> where-is-my-fluffymon-dev -> Data Explorer -> Data,
    "PERSON_COLLECTION_NAME": AZURE PORTAL -> AZURE COSMOS DB -> where-is-my-fluffymon-dev -> Data Explorer -> Data,
    "JWT_KEY": AZURE PORTAL -> FUNCTION APP -> where-is-my-fluffymon-dev -> CONFIGURATION -> JWT_KEY
    },
"Host": {
    "CORS": "*"
    }
}
```

