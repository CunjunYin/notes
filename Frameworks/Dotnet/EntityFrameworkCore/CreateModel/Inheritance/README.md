# Dependency
```sh
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.5
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.5
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.5
```

# Migrate
```sh
dotnet ef migrations add Initialize --context CONTEXT
dotnet ef database update
```

dotnet ef migrations add Initialize --context TablePerType
dotnet ef database update --context TablePerType
