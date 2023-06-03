# Dependency
```sh
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.5
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.5
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.5
```

# Migrate
```sh
dotnet ef migrations add Initialize
dotnet ef database update
```

# SQL 
Run Script.SqlServer.sql in SqlServer  Database to create view and function.