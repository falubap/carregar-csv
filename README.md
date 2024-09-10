# Carregamento de Arquivo CSV em Banco de Dados SQL

O presente programa tem por finalidade receber dados de um arquivo CSV a partir de uma URL, e carregá-los para dentro de uma tabela em um banco de dados relacional.

### Padrão de projeto
Foi utilizado o padrão **DAO (Data Access Object)**, que tem como principal característica a separação entre a lógica de negócio e a lógica de acesso aos dados. Desse modo, ao se alterar o tipo de armazenamento dos dados, não é necessário refatorar o código.
Seguindo o padrão DAO, o programa está separado em:
- **Entidades**: Tipo de dado que representa tanto uma classe do programa quanto um objeto no banco de dados;
- **Serviços**: Implementam os métodos de suas respectivas entidades;
- **Objetos de acesso a  dados**: Interface entre as entidades e os serviços;

Além disso, o programa também apresenta uma classe  Program, responsável por implementar o método principal (Main), onde são declarados e instanciados serviços para realizar operações no banco de dados.

### Dependências
O programa está escrito em linguagem **C#** e utiliza o **Microsoft .NET** na versão *8.0.304* como plataforma de desenvolvimento. Para executar o programa corretamente, por favor realize o download do SDK do .NET no link abaixo:

[Baixar .NET 8.0.304](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)

Para a criação e opreação do banco de dados, optou-se por utilizar o **Microsoft SQL Server 2022**. Por favor realize o download do SQL Server 2022 pelo link abaixo:

[Baixar SQL Server 2022](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

Juntamente com SQL Server 2022, o instalador também irá incluir em sua máquina o **SQL Server 2022 Configuration Manager**. Por favor, antes de executar o programa, certifique-se de executar o Configuration Manager e, nele, iniciar a execução do servidor local **SQLEXPRESS**. Para isso, basta clicar com o botão direito em *SQL Server (SQLEXPRESS)* e após clicar na opção *Iniciar*.

### Configurando o ambiente
O presente programa faz uso das bibliotecas CsvHelper e SqlClient. Para a correta construção e execução do programa na sua máquina, por favor instale as mencionadas bibliotecas copiando e colando os comandos abaixo no seu terminal:

``dotnet add package CsvHelper --version 33.0.1``

``dotnet add package Microsoft.Data.SqlClient --version 5.2.2``

### Executando o programa
Após ter instalado o **.NET** e o **SQL Server**, ter inicializado o servidor local **SQLEXPRESS**, e ter adicionado as bibliotecas **CsvHelper** e **SqlClient**, para executar o programa basta abrir o terminal e digitar o seguinte comando: 

``dotnet run``

Após isso, o programa deve rodar como esperado e retornar as mensagens indicando o sucesso na criação do banco de dados, da tabela e a inserção dos dados na tabela.
