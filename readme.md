## WFORECAST

- [WFORECAST](#wforecast)
  - [Descrição do Projeto](#descrição-do-projeto)
  - [Setup](#setup)
  - [Como rodar o projeto localmente](#como-rodar-o-projeto-localmente)

### Descrição do Projeto

O projeto WForecast apresenta a previsão do tempo separado em 3 módulos principais:

- As três cidades mais quentes do dia
- As três cidades mais frias do dia
- A previsão do tempo para uma cidade selecionada nos próximos 7 dias

O projeto utiliza ASP.NET MVC em uma arquitetura monolito, com banco de dados _SQLServer_.

Para gerenciar a geração e versões do banco, são utilizadas _migrations_, e para a interface entre código e banco, são utilizados _repositórios_.

Além disso, na página _Sobre_, são apresentados meus dados para esta seleção.

### Setup

Para executar o projeto, é necessário ter instalado:

> .NET Framework 4.6.1
> Sql Server
> Git (para clonar o projeto)

O ambiente de desenvolvimento foi o Visual Studio 2019 diretamente no IIS, porém o projeto tem suporte a docker que não foi utilizado nos testes.

### Como rodar o projeto localmente

Para executar o projeto no localhost e testá-lo:

1. baixe o código do projeto
2. Abra o projeto no Visual Studio 2019
3. Selecione no dropdown de execução IIS Express (Google Chrome) ao invés de Docker
4. Execute o build do projeto (CTRL + SHIFT + B)
5. Abra o Console do Gerenciador de Pacotes e execute
   > Update-Database
6. Execute a aplicação clicando no botão IIS Express.

No navegador, o projeto estará em https://localhost:44334/
