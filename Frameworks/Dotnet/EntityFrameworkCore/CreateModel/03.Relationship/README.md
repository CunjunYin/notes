# Dependency
```sh
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.5
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.5
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.5
```

# Migration
## One to one 
```sh
dotnet ef migrations add Initial --context Relationship.One2One.One2OneDBContext
dotnet ef database update  --context Relationship.One2One.One2OneDBContext
```