# Audit Platform Microservices

Plataforma de auditoria desenvolvida com arquitetura de microsserviços para a disciplina de Arquitetura de Software.

O projeto tem como objetivo aplicar conceitos de sistemas distribuídos, integração entre serviços, APIs REST e persistência de dados utilizando .NET e SQLite.

---

# Documento de Requisitos

## 1. Propósito do Sistema

O sistema tem como finalidade registrar transações financeiras e manter um histórico de auditoria das operações realizadas pelos usuários.

A aplicação busca garantir rastreabilidade das informações, permitindo consultar registros, acompanhar alterações e gerar evidências para auditoria.

---

## 2. Usuários do Sistema

### Auditor

Responsável por consultar registros de auditoria e acompanhar alterações realizadas no sistema.

### Operador Financeiro

Responsável pelo cadastro e manutenção das transações financeiras.

### Administrador

Responsável pela gestão dos usuários e acompanhamento geral do sistema.

---

## 3. Requisitos Funcionais

### RF01

Cadastrar usuários.

### RF02

Consultar usuários cadastrados.

### RF03

Registrar transações financeiras.

### RF04

Consultar transações financeiras.

### RF05

Registrar eventos de auditoria.

### RF06

Consultar histórico de auditoria.

### RF07

Validar usuários antes do registro de transações.

### RF08

Atualizar informações de auditoria quando uma transação for alterada.

---

# Descritivo Técnico

## Arquitetura

O sistema é composto por três microsserviços independentes, desenvolvidos utilizando .NET, SQLite e comunicação REST.

---

## User Service

Responsável pelo gerenciamento de usuários do sistema.

### Funcionalidades

* Cadastro de usuários
* Consulta de usuários
* Validação de existência de usuário

---

## Transaction Service

Responsável pelo gerenciamento das transações financeiras.

### Funcionalidades

* Cadastro de transações
* Consulta de transações
* Atualização de transações

---

## Audit Service

Responsável pelo registro e consulta de eventos de auditoria.

### Funcionalidades

* Registro de eventos
* Histórico de auditoria
* Consulta de logs

---

# Integrações Entre Microsserviços

## Integração 1 - Busca de Dados

Transaction Service consulta User Service para validar se o usuário existe antes de registrar uma transação.

---

## Integração 2 - Busca de Dados

Audit Service consulta Transaction Service para obter informações detalhadas de uma transação durante uma auditoria.

---

## Integração 3 - Alteração de Dados

Quando uma transação é criada ou atualizada no Transaction Service, um evento é enviado para o Audit Service, que registra automaticamente um novo histórico de auditoria.

---

# Tecnologias Utilizadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* REST API
* Swagger/OpenAPI

---

# Estrutura do Projeto

```text
src/
├── UserService
├── TransactionService
├── AuditService
└── Shared
```

---

# Execução

1. Clonar o repositório.
2. Restaurar os pacotes NuGet.
3. Executar as migrations.
4. Iniciar os microsserviços.
5. Acessar a documentação Swagger de cada serviço.

---

# Equipe

* Henrique
* Integrante 2
* Integrante 3

---

# Critérios Atendidos

* Três microsserviços independentes.
* Duas integrações de consulta entre serviços.
* Uma integração de alteração de dados.
* Utilização de .NET, SQLite e APIs REST.
* Documento de requisitos incorporado ao README.
* Descritivo técnico da arquitetura.

