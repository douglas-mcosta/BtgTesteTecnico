# Projeto .NET, Angular, SQL Server e Docker

## Descrição

Este projeto foi desenvolvido em .NET (backend), Angular (frontend), SQL Server e Docker, utilizando arquitetura de **microserviços** e mensageria com **RabbitMQ**, como parte de um teste técnico para um processo de recrutamento e seleção. O projeto visa demonstrar habilidades em desenvolvimento full-stack, além de aplicação de conceitos modernos de arquitetura de software.

## Tecnologias Utilizadas

- **Backend**: .NET Core
  - ASP.NET Core
  - Entity Framework Core
  - SQL Server
  - RabbitMQ (para comunicação entre microserviços)
- **Frontend**: Angular
- **Outros**:
  - Docker (para criação e gerenciamento de contêineres)
  - Docker Compose (para orquestração dos contêineres)
  - Swagger (para documentação da API)

## Funcionalidades

- Identidade: Registro de usuário e login
- Catalogo: Listagem de produtos com paginação e pesquisa por nome
- Produto: Adicionar e romover produto de um pedido
- Pedido: Processar pedido

## Estrutura do Projeto

- **/docker**:  Configuração de arquivos Docker e docker-compose.yml
- **/sql**:  Script inicial do banco
- **/src**:  Raiz
  - **/services**: Microsserviços
    - **/BTG.Identidade**: Serviço de identidade utilizando o Idenity
    - **/BTG.Ecommerce.API**: Serviço e-commerce com seleção de produtos e processamento de pedido
    - **/BTG.Relatorio.API**: Serviço de relatorio que consome os pedidos processados através de uma fila do RabbitMq
  - **/web**: 
    - **/btg-app**  Front-end
## Pré-requisitos

- [.NET SDK]([https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)) (versão 8.0 ou superior)
- [Node.js]([https://nodejs.org/](https://nodejs.org/pt/download/package-manager)) (versão 18 ou superior)
- [Angular CLI](https://angular.io/cli)
- Docker

## Instalação

1. Clone este repositório:
    ```bash
    git clone https://github.com/douglas-mcosta/BtgTesteTecnico.git
    cd BtgTesteTecnico
    ```

2. Instale as dependências do frontend:
    ```bash
    cd src/web/btg-app
    npm install --legacy-peer-deps
    ```

3. Script:
   - Execute o arquivo `.banco-inicial.sql` localizada na pasta `/sql` desse projeto

## Executando o Projeto

### Com Docker

1. Entre ma pasta `/docker`: 
    ```bash
    cd docker
    ```
2. Execute o comando para iniciar o projeto:
    ```bash
    docker-compose up -d
    ```

2. Acesse o frontend em `http://localhost` e as APIs em `http://localhost:5000/swagger/index.html`, `http://localhost:5001/swagger/index.html`, `http://localhost:5002/swagger/index.html`

### Localmente

#### Backend

1. Abra a solution `BtgTesteTecnico.sln` com o Visual Studio e configure a opção `Multiple startup projects` igual a imagem abaixo
   ![Screenshot_7](https://github.com/user-attachments/assets/b204fb7d-8441-4944-9268-4b5262b41d8a)

2. Execute a aplicação apertando `F5` no Visual Studio

#### Frontend

1. Navegue até a pasta do frontend:
    ```bash
    cd src/web/btg-app
    ```

2. Execute o projeto Angular:
    ```bash
    ng s
    ```

3. Acesse o frontend em `http://localhost:4200`.

