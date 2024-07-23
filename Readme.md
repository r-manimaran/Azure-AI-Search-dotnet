```bash
# Add User Secrets to the Project
> dotnet user-secrets init
# Add the package to support the user-secrets
> dotnet add package Microsoft.Extensions.Configuration.UserSecrets

# add the keys
> dotnet user-secrets set "indexName" "customer_support_index"

> dotnet user-secrets set "adminKey" "<azure ai Search Key>"

> dotnet user-secrets set "endpoint" "<endpoint here>

> dotnet add package Azure.Search.Documents --version 11.5.1

> dotnet add package CsvHelper

> dotnet new gitignore
```