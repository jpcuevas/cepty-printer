```
dotnet ef dbcontext scaffold "Host=localhost;Database=Cepty_DbDevelop_v2;Username=postgres;Password=Developer2020" Npgsql.EntityFrameworkCore.PostgreSQL -o Models/Database -c PanamaBusTicketsContext
```

```
dotnet publish -c Release -o ./publish
```
