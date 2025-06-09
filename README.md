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
- Visual Studio 2022

---

## 🚀 Como rodar localmente

### 1. Clone o repositório

git clone https://github.com/murilors27/firewatch-dotnet.git  
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

---

## ✅ Funcionalidades

- Cadastro, listagem, edição e exclusão de abrigos
- Associação com cidade (relacionamento 1:N)
- Validações com DataAnnotations
- Visualização dinâmica em tabela HTML
- Navegação amigável com Razor Pages

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

## 👥 Equipe

| Nome                                | RM       | GitHub                                |
|-------------------------------------|----------|----------------------------------------|
| Murilo Ribeiro Santos               | RM555109 | [@murilors27](https://github.com/murilors27) |
| Thiago Garcia Tonato                | RM99404  | [@thiago-tonato](https://github.com/thiago-tonato) |
| Ian Madeira Gonçalves da Silva      | RM555502 | [@IanMadeira](https://github.com/IanMadeira) |

**Curso**: Análise e Desenvolvimento de Sistemas  
**Instituição**: FIAP – Faculdade de Informática e Administração Paulista
