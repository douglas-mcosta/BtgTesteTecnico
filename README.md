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

- [.NET SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) (versão 8.0 ou superior)
- [Node.js](https://nodejs.org/pt/download/package-manager) (versão 18 ou superior)
- [Angular CLI](https://angular.io/cli)
- [Docker](https://docs.docker.com/desktop/install/windows-install)
- [RabbitMq](https://www.rabbitmq.com/docs/download) (recomendado utilizar o docker compose `/docker/docker-compose.yml`)

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
2. Verifique se todos os conteiners forem iniciados

![image](https://github.com/user-attachments/assets/f95834f6-c817-498a-9477-6994a51ff1ff)

4. Acesse o frontend em `http://localhost` e as APIs em `http://localhost:5000/swagger/index.html`, `http://localhost:5001/swagger/index.html`, `http://localhost:5002/swagger/index.html`

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
2. Para rodar localmente lembre-se de `**deixar apenas o docker btg-rabbit**` rodando e os outros como stop.

 ![Screenshot_8](https://github.com/user-attachments/assets/f3412241-25b9-45ad-b788-e45550194259)

3. Caso tenha uma instancia do sql na maquina, execute o arquivo `.banco-inicial.sql` localizada na pasta `/sql` desse projeto ou inicie o docker btg-sql-serve

 ![image](https://github.com/user-attachments/assets/916e50fd-d9e4-4ad9-8035-3e3f0af55c3b)

4. Caso tenha optado por usar o btg-sql-serve lembre-se de alterar a connection string dos `appsettings.Development.json` para `Server=bgt-sql-server,1433;Initial Catalog=identidade_db;Persist Security Info=True;User ID=sa;Password=n<8l=8R54I[j;MultipleActiveResultSets=True;Encrypt=False;connect timeout=30`


5. Execute o projeto Angular:
    ```bash
    ng s
    ```

6. Acesse o frontend em `http://localhost:4200`.
### Soluções de problemas
1. Caso ocorra o erro abaixo, ao adicionar produto ao pedido, verifique novamente o passo 2 em que apenas o `btg-rabbit` deve estar em execução caso esteja rodando o projeto localmente no visual studio.

![image](https://github.com/user-attachments/assets/62a9c358-b733-4d67-b9c7-365b1db28b8a)

Caso tenha seguido o passo 4 o `btg-sql-server` tambem pode estar em execução caso contrario apenas o `btg-rabbit`

![image](https://github.com/user-attachments/assets/76757b29-1874-48c9-9704-7abda493525e)




