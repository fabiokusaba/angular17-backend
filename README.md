## Projeto CRUD Filmes e Séries

Projeto desenvolvido com intuito de servir como uma API para realizar as quatro operações do CRUD (create, read, delete, update).

## Projeto desenvolvido utilizando as tecnologias:
* .NET 7
* EF Core
* Npgsql - Banco PostgreSQL

## Modo de uso
* Clone o repositório do Github e abra na sua IDE de preferência
* Execute o projeto e acesse `http://localhost:5202/swagger/index.html` para ter acesso a documentação da API

## Rotas disponíveis

* POST: `/films` -> método para cadastro de filmes e séries, passe no corpo da requisição: name, genre e rate
* GET: `/films` -> método para listar todos os filmes e séries cadastrados
* PUT: `/films/id` -> método para atualizar um filme/série especificado pelo seu ID
* DELETE: `films/id` -> método para remover um filme/série especificado pelo seu ID

