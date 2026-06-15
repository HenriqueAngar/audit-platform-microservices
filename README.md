# AUDIT PLATFORM MICROSERVICES

Projeto desenvolvido para a disciplina de Arquitetura de Software utilizando arquitetura de microsserviços, APIs REST, .NET e SQLite.

## Documento de Requisitos

### 1. Propósito do Sistema

O sistema tem como objetivo registrar movimentações financeiras e disponibilizar mecanismos de consulta e extração dessas informações de forma controlada.

Além das consultas, o sistema permite anonimizar dados sensíveis antes de disponibilizar resultados para usuários não autorizados, mantendo rastreabilidade das operações realizadas.

### 2. Usuários do Sistema

#### Administrador

Responsável pelo cadastro e gerenciamento de usuários da plataforma.

#### Agente Autorizado

Usuário com permissão para realizar consultas e extrações de dados financeiros.

#### Pessoa Externa

Usuário que pode solicitar extrações de informações, recebendo os resultados anonimizados quando necessário.

### 3. Requisitos Funcionais

#### RF01

Cadastrar usuários no sistema.

#### RF02

Consultar usuários cadastrados.

#### RF03

Validar autenticação de usuários.

#### RF04

Verificar autorização de acesso às funcionalidades da plataforma.

#### RF05

Registrar movimentações financeiras.

#### RF06

Consultar movimentações financeiras registradas.

#### RF07

Solicitar extrações de informações financeiras.

#### RF08

Registrar solicitações de extração realizadas pelos usuários.

#### RF09

Anonimizar dados sensíveis durante o processamento das extrações.

#### RF10

Registrar informações sobre processos de anonimização realizados.

#### RF11

Consultar registros de anonimização previamente executados.

---

## Descritivo Técnico

### Arquitetura

O sistema é composto por microsserviços independentes desenvolvidos utilizando:

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* REST API
* Swagger/OpenAPI

Cada microsserviço possui banco de dados próprio e responsabilidade específica.

---

### AccessManagementService

Responsável pelo gerenciamento de usuários e controle de acesso.

#### Funcionalidades

* Cadastro de usuários
* Consulta de usuários
* Autenticação
* Validação de autorização

---

### TransactionService

Responsável pelo armazenamento das movimentações financeiras.

#### Funcionalidades

* Registro de transações financeiras
* Consulta de transações
* Armazenamento de dados financeiros

---

### ExtractionService

Responsável pelo processamento das solicitações de extração de informações.

#### Funcionalidades

* Registro de solicitações de extração
* Processamento de consultas
* Integração com outros microsserviços
* Controle do fluxo de anonimização

---

### AnonymizationService

Responsável pela anonimização de dados sensíveis.

#### Funcionalidades

* Criptografia de dados
* Registro de chaves e metadados de anonimização
* Consulta de registros de anonimização
* Retorno de dados anonimizados

---

## Integrações Entre Microsserviços

### Integração 1 – Busca de Dados

O ExtractionService consulta o AccessManagementService para verificar se o usuário possui autorização para realizar uma extração.

### Integração 2 – Busca de Dados

O ExtractionService consulta o TransactionService para obter os dados financeiros solicitados na extração.

### Integração 3 – Alteração de Dados

O ExtractionService envia dados para o AnonymizationService quando a extração exige anonimização. O AnonymizationService processa os dados e registra um novo registro de anonimização em seu banco de dados.

---

## Estrutura da Solução

```text
AccessManagementService
TransactionService
ExtractionService
AnonymizationService
```

---

## Tecnologias Utilizadas

* .NET 8
* ASP.NET Core
* Entity Framework Core
* SQLite
* Swagger
* REST APIs

---

## Execução

1. Restaurar os pacotes NuGet.
2. Executar as migrations de cada microsserviço.
3. Executar os microsserviços individualmente.
4. Acessar o Swagger de cada serviço.
5. Realizar os testes de integração entre os microsserviços.

---

## Equipe

* Henrique
* Luiz Antônio Coral

---

## Critérios Atendidos

* Arquitetura baseada em microsserviços.
* Quatro microsserviços independentes.
* Duas integrações de consulta entre microsserviços.
* Uma integração de alteração de dados entre microsserviços.
* Utilização de .NET, SQLite e APIs REST.
* Documento de requisitos incorporado ao README.
* Descritivo técnico da arquitetura incluído na documentação.


