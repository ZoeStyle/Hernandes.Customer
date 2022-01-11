# Hernandes.Customer

Projeto realizado para cadastro de cliente, seje ele pessoa física ou jurídica.

Foi criado um projeto WebApi, utilizando os seguintes recursos:

- Frameworks: .Net 6, MSTest;

- Arquetetura em camadas: Notifications, Response, Domain, Application, Infrastructure e Api;

- Banco de dados: MongoDb;

Funcionalidades implementadas

- Cadastro de cliente pessoa física e juridica;

- Consulta de cliente pessoa física através de um dos campos informado (CPF, RG ou Nome);

- Consulta de cliente pessoa jurídica através de um dos campos informados (Razão Social, Nome Fantasia ou CNPJ);

---

## Frameworks

- ### MsTest

Ferramenta gratuita e open-source para testes unitários, sendo mantida pela Microsoft.
Funciona com o .NET Core, .NET Framework, Universal Windows Apps e Xamarin.
Tem um template prório para o .NET Core, tanto via linha de comando quanto pelo Visual Studio 2019.
Em um projeto de testes do MsTest, basta criar uma classe e inserir o método com a anotação [TestMetod].

~~~ csharp
[TestClass]
[TestCategory("Store")]
public class StoreTest
{
    private Store _entity;

    [TestInitialize]
    public void Initializaze()
    {
        _entity = new Store(
            owner: "Victor",
            name: "_entity Test");
    }

    [TestMethod]
    public void TestExceptionAmount()
    {
        Assert.ThrowsException<ArgumentException>(() =>
        {
            _entity.CalculateBalance(ETransactions.CREDITO, 0);
        });
    }
}
~~~

---

## Arquetetura em camadas

- ### Notifications

Notifications é uma maneira fluente de usar o Padrão de Notificação com suas entidades, concentrando todas as alterações feitas e acessando facilmente quando necessário.

Este projeto/Dll, foi elaborada através do projeto Flunt desenvolvido por André Baltieri, porém foi adicionado algumas novas validações.

- ### Response

Response é uma maneira de padronizar resposta e facilitar o trabalho e integrações no dia-a-dia.

- ### Domain

Responsável por representar conceitos, informações e regras sobre a situação do negócio. Aqui, um estado que reflete a situação de negócio é controlado e usado, embora os detalhes técnicos de armazenagem sejam delegados à infraestrutura. Esta é o coração do software do negócio.

Foi adicionado as seguintes subCamadas: Entities, ValueObject, Services, Enums, Work

        Em breve as decrições de todas as subcamadas
               
- ### Application

Define as funções que o software deve executar e direciona os objetos expressivos do domínio para resolver os problemas. As tarefas sob a responsabilidade desta camada têm grande significado para o negócio ou são necessárias para a iteração com as camadas de aplicativos de outros sistemas.

Essa camada é mantida estreita. Ela não contém as regras ou o conhecimento do negócio, mas apenas coordena as tarefas e delega os trabalhos para o conjunto de objetos e o domínio na camada logo abaixo.  Ela não tem um estado que reflita a situação do negócio, mas pode ter um estado que reflita o andamento de uma tarefa para o usuário ou programa.

Foi adicionado as seguintes subCamadas: Commands, DTOs, Handlers, Repositories

        Em breve as decrições de todas as subcamadas
  
- ### Infrastructure

Fornece recursos técnicos genéricos que suportam as camadas mais altas: envio de mensagem para o aplicativo, persistência de domínio, assim por diante. 

Foi adicionado as seguintes subCamadas: Context, Repositories

        Em breve as decrições de todas as subcamadas
  
- ### Api

Responsável por mostrar informações ao usuário e interpretar os comandos do usuário. O agente externo pode, as vezes, ser outro sistema de computador em vez de usuário.

Foi adicionado as seguintes subCamadas: Controllers, Services

        Em breve as decrições de todas as subcamadas
  
---

## Banco de Dados

- ### MongoDb

MongoDB é um software de banco de dados orientado a documentos livre, de código aberto e multiplataforma.

Classificado como um programa de banco de dados NoSQL, o MongoDB usa documentos semelhantes a JSON com esquemas.


## Como executar o projeto ?

- Dentro do visual studio defina o projeto de inicialização como Customer.Hernandes.Api aperte F5

- Caso for executar o projeto pelo visual studio Code navegue até a pasta do projeto Customer.Hernandes.Api e execute o comando no terminal

~~~ csharp
dotnet run
~~~
