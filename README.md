# API de Manipulação de Strings (ABM_ManipString)

API REST que realiza operações de análise em strings recebidas via requisições POST, verificando palíndromos e contando ocorrências de caracteres.

## 📋 Descrição

Este projeto foi desenvolvido como resposta a um desafio back-end, criando um endpoint que:
- Verifica se uma string é um palíndromo
- Conta a ocorrência de cada caractere na string

## 🚀 Como Usar

### Requisição
**Método:** POST  
**Endpoint:** `/api/manipulacao-string`  
**Content-Type:** `application/json`

**Exemplo de corpo de requisição:**
```json
{
    "texto": "string a ser analisada"
}
```

### Resposta
**Formato:** JSON  
**Estrutura:**
```json
{
    "palindromo": "boolean",
    "ocorrencias_caracteres": {
        "caractere": "quantidade",
        ...
    }
}
```

### Exemplo com cURL
```bash
curl -X POST \
  -H "Content-Type: application/json" \
  -d '{"texto":"banana"}' \
  http://seuservidor.com/api/manipulacao-string
```

**Resposta esperada:**
```json
{
    "palindromo": false,
    "ocorrencias_caracteres": {
        "b": 1,
        "a": 3,
        "n": 2
    }
}
```

## ⚙️ Funcionalidades

1. **Verificação de Palíndromo**
   - Identifica se a string é igual quando lida de trás para frente
   - Considera todos os caracteres (case-sensitive)

2. **Contagem de Caracteres**
   - Retorna a frequência de cada caractere na string
   - Inclui todos os caracteres, incluindo espaços e símbolos

3. **Tratamento de Erros**
   - Validação de entrada vazia
   - Formato JSON correto

## 📌 Requisitos Técnicos

- Linguagem: C#
- Framework: ASP.NET Core (recomendado)
- Formato de entrada/saída: JSON estrito
- Hospedagem: Qualquer ambiente cloud (AWS, Azure, DigitalOcean, etc.)

## 📊 Critérios de Avaliação

- ✔️ Corretude das operações
- ⚡ Eficiência algorítmica
- 🛡️ Tratamento de erros robusto
- 📚 Boas práticas de código
- 📝 Documentação clara

## 🌐 Links Importantes

- **API Hospedada:** [URL da aplicação]() 
- **Código Fonte:** [URL do repositório]()

> Você só precisará preencher os URLs específicos quando tiver essas informações disponíveis.

## ⁉️ Casos Especiais

- String vazia retornará:
  ```json
  {
      "palindromo": true,
      "ocorrencias_caracteres": {}
  }
  ```
- Palíndromos case-sensitive ("Arara" ≠ "ararA")

## 🛠️ Desenvolvimento

Para implementar localmente:
1. Clone o repositório
2. Restaure as dependências do .NET
3. Execute o projeto
4. Acesse via `http://localhost:{porta}/api/manipulacao-string`

## 📝 Observações

- A estrutura exata do JSON deve ser mantida conforme especificado
- A aplicação será testada automaticamente - desvios no formato resultarão em falha
- Recomenda-se usar serviços como:
  - AWS Free Tier
  - Azure Students
  - Heroku Free Dyno
  - DigitalOcean Droplets

---