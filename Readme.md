# Informações Gerais

PROJETO: ManagementCompany
OBJETIVO: Desenvolver uma API que permita o gerencimamento de empresas e funcionarios.
DESENVOLVEDOR: Tiago Penha
# 

Dependências:

Visual Studio 2022
https://visualstudio.microsoft.com/pt-br/downloads/

Docker
https://www.docker.com/get-started/

Obs: Neste repositório se encontra a solution ManagementCompany e dentro da pasta src os projtetos:
    - Management.Api
    - Management.Application
    - Management.Core
    - Management.Infrastructure
    - Management.Tests.Application

# API
## Resumo:
Aplicação do tipo ASPNET.CORE API, usando a versão .Net 6.0 e conexão com MySql, faz uso de controllers.

# Application
## Resumo:
Aplicação do tipo ClassLibray responsavel por realizar a regra de negocio da aplicação, utiliza o padrão CRQS, interfaces, serviços.

# Core
## Resumo:
Aplicação do tipo ClassLibray responsavel por gerenciar a aplicação, é a camada central.

# Infrastructure
## Resumo:
Aplicação do tipo ClassLibray responsavel por realizar a conexão com o Banco de dados MySQL, através do ORM Entity Framework Core

# Tests
## Resumo:
Aplicação do tipo xUnit responsavel por realizar os testes na aplicação, fazendo usado da biblioteca NSubstitute.

# Detalhes
## Refinamento:
 1 - A aplicação esta aplicando o uso de containers, para isso estou fazendo uso do Docker para as imagens e Docker Compose como orquestrador. 
     Observação: Com o uso do Visual Studio é possivel subir o container com a api e o banco de dados, basta selecionar o Docker Compose como inicializador.
      Podendo tambem ser iniciado manualmente, seguindo os passos abaixo:
        1 - Baixe o repositório do projeto, branch(develop)
        2 - Através da linha de comando entre dentro da pasta onde se encontra a solution e o arquivo docker-compose
        3 - Execute o seguinte comando:  docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d
        
 2 - A imagem da api está disponivel no Docker Hub, podendo ser acessada através do link abaixo:    
        -    https://hub.docker.com/repository/docker/137504/management.api/general

## _Linguagens/Frameworks utlizadas pela aplicação:_

- C#
- Net 6.0
- Microsoft.EntityFrameworkCore.7.0.16
- MySQL
- XUnit 
- NSubstitute
- Docker
- Docker Compose
