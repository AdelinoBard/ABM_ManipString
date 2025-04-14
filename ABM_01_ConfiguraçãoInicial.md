## 🛠️ Configuração Inicial

Para criar a estrutura básica do projeto .NET 8.0, execute os seguintes comandos:

```csharp
// Cria a estrutura básica do projeto MVC
dotnet new globaljson --sdk-version 8.0.300 --output ABM_ManipString
dotnet new webapi --no-https --output ABM_ManipString --framework net8.0
dotnet new sln -o ABM_ManipString
dotnet sln ABM_ManipString add ABM_ManipString
```

**Observações:**
- Recomendado SDK .NET 8.0.300 ou superior
- Usamos `webapi` em vez de `mvc` para projetos API REST
- A flag `--no-https` simplifica o desenvolvimento local
- O `globaljson` pode ser útil para fixar a versão do SDK, mas não é obrigatório. Se for usar, coloque na raiz do projeto.
- Você não precisa especificar `--framework net8.0` se estiver usando o SDK 8.0, pois será o padrão.

## Próximos passos após criar a estrutura:

1. Crie suas pastas seguindo o padrão MVC:
   - `Controllers/` (já vem por padrão no webapi)
   - `Models/` (para suas classes de modelo e DTOs)
   - `Services/` (para a lógica de negócios)
   - `Helpers/` (para utilitários)
   - `View/` (para exibição)

## 🚀 Primeiros Passos

1. Acesse o diretório do projeto:
```bash
cd ABM_ManipString
```

2. Execute a aplicação:
```bash
dotnet run
```

3. A API estará disponível em:
```
http://localhost:5000/api/manipulacao-string
```
---