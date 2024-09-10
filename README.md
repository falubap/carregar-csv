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
O programa está escrito em linguagem **C#** e utiliza o **Microsoft .NET** na versão *8.0.8* como plataforma de desenvolvimento. Para executar o programa corretamente, por favor realize o download do Runtime do .NET no link abaixo:

[Baixar .NET 8.0.8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)

Para conferir se o .NET foi instalado com sucesso, basta abrir o terminal e digitar o seguinte comando:

``dotnet --info``

E o terminal irá retornar as versões instaladas do .NET na máquina.

Para a criação e opreação do banco de dados, optou-se por utilizar o **Microsoft SQL Server 2022**. Por favor realize o download do instalador do SQL Server 2022 pelo link abaixo:

[Baixar SQL Server 2022](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

No link acima, são disponibilizadas duas versões do SQL Server para download: a versão de desenvolvedor e a versão express. Para o correto funcionamento do presente programa, por favor utilize a versão express.


Após baixado, execute o arquivo do instalador, selecione a opção de instalação "Basic" e siga os passos indicados para concluir a instalação. Juntamente com SQL Server 2022, o instalador também irá incluir em sua máquina o **SQL Server 2022 Configuration Manager**. Por favor, antes de executar o programa, certifique-se de executar o Configuration Manager e, nele, iniciar a execução do servidor local **SQLEXPRESS**. Para isso, basta clicar com o botão direito em *SQL Server (SQLEXPRESS)* e após clicar na opção *Iniciar*.


Ao fim da instalação, também será exibido uma tela onde é oferecido a opção de instalar também o **Microsoft SQL Server Management Studio**, que é um DBMS (sistema de gerenciamento de dados) do SQL Server, por meio do botão *"Instalar SSMS"*. Um DBMS será necessário para visualizar o banco de dados e tabela que serão criados na execução do presente programa. Por isso, clique no botão indicado e siga os passos para realizar o download e a instação do Management Studio 20.


### Configurando o ambiente
O presente programa faz uso das bibliotecas CsvHelper e SqlClient. Para a correta construção e execução do programa na sua máquina, por favor instale as mencionadas bibliotecas copiando e colando os comandos abaixo no seu terminal:

``dotnet add package CsvHelper --version 33.0.1``

``dotnet add package Microsoft.Data.SqlClient --version 5.2.2``

### Executando o programa
Após ter instalado o **.NET** e o **SQL Server**, ter inicializado o servidor local **SQLEXPRESS**, e ter adicionado as bibliotecas **CsvHelper** e **SqlClient**, para executar o programa basta abrir o terminal e digitar o seguinte comando: 

``dotnet run``

Após isso, o programa deve rodar como esperado e retornar as mensagens indicando o sucesso na criação do banco de dados, da tabela e a inserção dos dados na tabela.

Para visualizar a tabela criada, abra o Management Studio e siga os seguintes passos para se conectar:

1. Em *"Server Type"* selecione *"Database Engine"*
2. Em *"Server name"* digite *"localhost\sqlexpress"*
3. Em "*Authentication"* selecione *"Windows Authentication"*
4. Em *"Encryption"* selecione *"Mandatory"*
5. Selecione a caixa *""Trust server certificate*
6. Clique em *"connect"*
7. No servidor *"localhost\sqlexpress"*, expanda o diretório *"Databases"*
8. Expanda o banco de dados **EscolasDB**, criado ao executar o programa
9. Crie uma nova consulta, utilizando o botao *"New query"*
10. Na consulta, digite o seguinte comando

``SELECT * FROM dbo.Escolas``

11. Selecione o comando digitado e aperte a tecla F5

Feitos esses passos, a tabela com os dados do arquivo CSV lido será exibida.