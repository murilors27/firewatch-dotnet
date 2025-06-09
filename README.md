# 🛡️ FireWatch.Abrigos (.NET Razor + PostgreSQL)

Sistema para cadastro e gerenciamento de abrigos de emergência, com foco em situações de risco como incêndios florestais ou desastres climáticos.

---

## 📐 Diagrama da Entidade

Cidade (1) -------- (N) Abrigo

- Cidade
  - Id (PK)
  - Nome

- Abrigo
  - Id (PK)
  - Nome
  - Capacidade
  - RecursosDisponiveis
  - TipoAtendimento
  - Latitude
  - Longitude
  - CidadeId (FK para Cidade)

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core Razor Pages (.NET 8)
- Entity Framework Core
- PostgreSQL
- Bootstrap 5 (via TagHelpers)
- Swagger (com API auxiliar)
- Visual Studio 2022

---

## 🚀 Como rodar localmente

### 1. Clone o repositório

git clone https://github.com/seu-usuario/firewatch-abrigos.git  
cd firewatch-abrigos

### 2. Configure o banco PostgreSQL

Crie um banco chamado `firewatch_abrigos`

Atualize `appsettings.json` com suas credenciais:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=firewatch_abrigos;Username=postgres;Password=123456"
}

### 3. Execute as migrations

dotnet ef database update

### 4. Rode o projeto

dotnet run

Acesse o sistema em:

http://localhost:5162

Acesse o Swagger (caso implementado):

http://localhost:5162/swagger

---

## ✅ Funcionalidades

- Cadastro, listagem, edição e exclusão de abrigos
- Associação com cidade (relacionamento 1:N)
- Validações com DataAnnotations
- Visualização dinâmica em tabela HTML
- Navegação amigável com Razor Pages
- Swagger documentando API auxiliar

---

## 📋 Exemplos de Testes (formulários)

### ➕ Cadastrar Abrigo

1. Acesse `/Abrigos/Create`
2. Preencha:
   - Nome: Abrigo Central
   - Capacidade: 100
   - Recursos: Água, comida, primeiros socorros
   - Tipo: 24h
   - Latitude: -23.56
   - Longitude: -46.63
   - Cidade: São Paulo
3. Clique em "Cadastrar"

---

## 🧪 Swagger (exemplo)

### GET /api/abrigos

[
  {
    "id": 1,
    "nome": "Abrigo Central",
    "capacidade": 200,
    "recursosDisponiveis": "Água, comida",
    "tipoAtendimento": "24h",
    "latitude": "-23.56",
    "longitude": "-46.63",
    "cidade": {
      "id": 1,
      "nome": "São Paulo"
    }
  }
]

---

## 📷 Prints

- Página de cadastro
- Listagem de abrigos
- Swagger em execução

---

## 🧾 Créditos

Desenvolvido por Murilo Ribeiro Santos – Projeto acadêmico para a disciplina de Desenvolvimento Web com .NET.
