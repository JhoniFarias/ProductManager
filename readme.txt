comando para gerar as migrations

dotnet ef migrations add Inicial --project ProductContext.Infrastructure -s ProductContext.API -c AppDbContext --verbose



comando para atualizar a base 

dotnet ef database update --project ProductContext.Infrastructure -s ProductContext.API -c AppDbContext --verbose