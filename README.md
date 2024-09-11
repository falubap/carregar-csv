# Carregamento de Arquivo CSV em Banco de Dados SQL

O presente programa tem por finalidade receber dados de um arquivo CSV a partir de uma URL, e carregá-los para dentro de uma tabela em um banco de dados relacional.

### Padrão de projeto
Foi utilizada uma versão simplificada do padrão **DAO (Data Access Object)**, que tem como principal característica a separação entre a lógica de negócio e a lógica de acesso aos dados. Desse modo, há um encapsulamento dos mecanismos de acesso a dados, e portanto eles se tornam independente das fontes.
O programa está separado nas seguintes camadas:
- **Entidades**: Aqui está armazenada a classe de domínio Escola, que possui como propriedades os campos de dados do arquivo CSV a ser lido;
- **DAOs**: Aqui está o objeto de acesso a dados da classe Escola, que é responsável por fazer a interface entre a classe de domínio e os métodos que irão realizar operações no banco de dados;
- **DAOImpls**: Aqui está a implementação dos métodos do objeto de acesso a dados EscolaDAO que serão responsáveis por realizar operações no banco de dados;
- **Services**: Aqui está a classe LerCsvService responsável por receber a requisição HTTP que irá fazer a leitura do arquivo CSV e transferir os seus dados para o DAO.

Além disso, o programa também apresenta uma classe  Program, responsável por implementar o método principal (Main), onde os métodos dos DAOs e Services serão chamados para realizar a leitura do arquivo CSV desejado e carregar os seus dados para uma tabela armazenada em um banco de dados.

### Dependências
O programa está escrito em linguagem **C#** e utiliza o **Microsoft .NET 8** como plataforma de desenvolvimento. Para executar o programa corretamente, por favor realize o download do SDK do .NET no link abaixo:

[Baixar .NET 8.0.401](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)

Para conferir se o .NET foi instalado com sucesso, basta abrir o terminal e digitar o seguinte comando:

``dotnet --info``

E o terminal irá retornar as versões instaladas do .NET na máquina.

Para a criação e opreação do banco de dados, optou-se por utilizar o **Microsoft SQL Server 2022**. Por favor realize o download do instalador do SQL Server 2022 pelo link abaixo:

[Baixar SQL Server 2022](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

No link acima, são disponibilizadas duas versões do SQL Server para download: a versão de desenvolvedor e a versão express. Para o correto funcionamento do presente programa, por favor utilize a versão express.


Após baixado, execute o arquivo do instalador, selecione a opção de instalação "Basic" e siga os passos indicados para concluir a instalação. Juntamente com SQL Server 2022.


Ao fim da instalação, também será exibido uma tela onde é oferecido a opção de instalar também o **Microsoft SQL Server Management Studio**, que é um DBMS (sistema de gerenciamento de dados) do SQL Server, por meio do botão *"Instalar SSMS"*. Um DBMS será necessário para visualizar o banco de dados e tabela que serão criados na execução do presente programa. Por isso, clique no botão indicado e siga os passos para realizar o download e a instação do Management Studio 20.

O presente programa também faz uso das bibliotecas CsvHelper e SqlClient. Para a correta construção e execução do programa na sua máquina, por favor instale as mencionadas bibliotecas copiando e colando os comandos abaixo no seu terminal:

``dotnet add package CsvHelper --version 33.0.1``

``dotnet add package Microsoft.Data.SqlClient --version 5.2.2``


### Configurando o ambiente
Primeiramente, clone o presente repositório para a sua máquina, abrindo o Git Bash no diretório desejado para armazenar o programa e utilizando o comando:

``git clone https://github.com/falubap/carregar-csv.git``

Após, abra o **SQL Server 2022 Configuration Manager**, que foi instalado juntamente com o SQL Server 2022 em sua máquina. Nele, clique duas vezes em *"Serviços do SQL Server"* e, caso o estado do campo *"SQL Server (SQLEXPRESS)"* não seja *"Em Execução"*, selecione esse campo com o botão direito e clique em iniciar.

### Executando o programa
Para executar o programa, abra o terminal e se dirija ao diretório **carregar-csv** que foi clonado para a sua máquina. Digite então o seguinte comando:

``dotnet run``

Após isso, o programa deve rodar como esperado e retornar as mensagens indicando o sucesso na criação da tabela e a inserção dos dados na tabela.

Para visualizar a tabela criada, abra o Management Studio e siga os seguintes passos para se conectar:

1. Em *"Server Type"* selecione *"Database Engine"*.
2. Em *"Server name"* digite *"localhost\sqlexpress"*.
3. Em "*Authentication"* selecione *"Windows Authentication"*.
4. Em *"Encryption"* selecione *"Mandatory"*.
5. Selecione a caixa *"Trust server certificate"*.
6. Clique em *"connect"*.
7. No servidor *"localhost\sqlexpress"*, expanda o diretório *"Databases"*.
8. Caso o banco de dados *EscolasDB* ainda não esteja sendo exibido, tendo selecionado o diretório *"Databases"* utilize o botão *"Refresh"*. Quando o banco de dados *EscolasDB* estiver sendo exibido clique nele para o selecionar.
9. Crie uma nova consulta, utilizando o botao *"New query"*.
10. Na consulta, digite o seguinte comando:

``SELECT * FROM dbo.Escolas``

11. Selecione o comando digitado anteriormente e aperte a tecla F5.

Seguidos esses passos, a tabela com os dados do arquivo CSV lido será exibida.