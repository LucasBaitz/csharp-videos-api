# API VibeFlix

API desenvolvida em ASP.NET Core, integrada com MySQL, que serve como o back-end da aplicação VibeFlix.

## Descrição

A API VibeFlix fornece endpoints para gerenciar vídeos e categorias relacionadas. Ela permite a criação, recuperação, atualização e exclusão de vídeos e categorias, além de fornecer recursos para pesquisar vídeos por título e categorias por nome.

## Tecnologias Utilizadas

- C#
- ASP.NET Core
- EntityFramework
- MySQL
- AutoMapper

## Endpoints

### Vídeos

- `GET /api/videos`
  - Retorna todos os vídeos cadastrados.

- `GET /api/videos/Title?title={title}`
  - Retorna um vídeo pelo título especificado.
  - Parâmetros de consulta:
    - `title`: O título do vídeo.

- `GET /api/videos/{id}`
  - Retorna um vídeo pelo ID.
  - Parâmetros de rota:
    - `id`: O ID do vídeo.

- `POST /api/videos`
  - Cria um novo vídeo.
  - Corpo da solicitação: Objeto JSON contendo os dados do vídeo.

- `PUT /api/videos/{id}`
  - Atualiza as informações de um vídeo existente.
  - Parâmetros de rota:
    - `id`: O ID do vídeo.
  - Corpo da solicitação: Objeto JSON contendo os dados atualizados do vídeo.

- `DELETE /api/videos/{id}`
  - Exclui um vídeo pelo ID.
  - Parâmetros de rota:
    - `id`: O ID do vídeo.

### Categorias

- `GET /api/categories`
  - Retorna todas as categorias cadastradas.

- `GET /api/categories/Name?name={name}`
  - Retorna uma categoria pelo nome especificado.
  - Parâmetros de consulta:
    - `name`: O nome da categoria.

- `POST /api/categories`
  - Cria uma nova categoria.
  - Corpo da solicitação: Objeto JSON contendo os dados da categoria.

- `DELETE /api/categories/{id}`
  - Exclui uma categoria pelo ID.
  - Parâmetros de rota:
    - `id`: O ID da categoria.

## Configuração do Banco de Dados

A API utiliza o banco de dados MySQL para armazenar os vídeos e categorias. Certifique-se de configurar corretamente a conexão com o banco de dados no arquivo de configuração `appsettings.json`.

Exemplo de configuração do banco de dados:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=VibeFlixDB;Uid=seu_usuario;Pwd=sua_senha;"
  }
}

Pré-requisitos
- ASP.NET Core SDK instalado
- MySQL Server instalado

Como Executar
1. Clone o repositório para sua máquina local.
2. Abra o projeto no Visual Studio ou em um editor de sua preferência.
3. Configure a conexão com o banco de dados no arquivo `appsettings.json`.
4. Execute o projeto.
5. Acesse a API através da URL `http://localhost:{porta}/api`.

## Considerações

Para utilizar os endpoints em um projeto pessoal, siga as seguintes etapas:

1. Abra o arquivo `Program.cs` do seu projeto.
2. Localize a configuração de CORS.
3. Adicione o IP da aplicação que fará as requisições na lista de políticas permitidas.

Exemplo de configuração de CORS no ASP.NET Core:

```csharp
app.UseCors(options =>
{
	options.WithOrigins("http://localhost:0000 <- Seu IP aqui"); 
	options.AllowAnyMethod();
	options.AllowAnyHeader();
});


Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir problemas (issues) e enviar pull requests para melhorar esta API.

Licença
Este projeto está licenciado sob os termos da [MIT License](LICENSE).

