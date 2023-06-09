﻿Serviço de Mensageria:

`	`Protocolo AMQP: Advanced Message Queuing Protocol

`	`Protocolo de enfileiramento de msgs

Caracterista do Protocolo:

`	`Orientação Mensagem

`	`Roteamento

`	`Confiabilidade

`	`Segurança

Papeis:

`	`- Producer/Pushiser:

`		`Quem publica um evento ou uma mensagem (Vendedor do ML)

`	`- Message Broker/EventBus:

`		`Responsável por entregar aos subscribers o evento ou mensagem (Correios)(RabbitMQ, SQS, Kafka, Azure Service Bus)

`	`- Exchange (RabbitMQ):

`		`O Broker recebe a msg através de um exchange que faz o roteamento da msg usando keys de roteamento e regras chamadas de Bindings. (Caixa de Correio)

`	`- Queues:

`		`São filas adicionadas pelo Bindings

`	`- Consumer/Subscriber:

`		`Quem irá consumir o evento ou mensagem (Comprador)

Conceitos:

`	`- Message:

`		`Bloco de dados binários que pode conter diferentes formatos (text, JSON, XML)

`		`\* A message é divida em:

`			`Payload: Representa o copor de dados que serão transmitidos

`			`Label: Descreve o payload

`	`-Producer/Pushiser:

`		`Responsável por incluir uma msg na filas

`	`- Exchange:

`		`É uma entidade AMQP para onde as msg são enviadas, ele recebe uma msg e a ecaminha para filas

`	`- Bindings:

`		`São responsáveis por estabelecer um relacionamento entre um Exchange e uma Queue

`	`- Queue:

`		`Local onde ficam armazenadas as msg até que sejam retiradas/consumidas

`	`- Consumer:

`		`Responsável por tirar/consumir uma msg da Queue

`	`Obs: No RabbitMQ os exchanges, bindings e Queues são referenciados como entidades AMQP

Links Úteis:

`	`- O que é mensageria: https://www.youtube.com/watch?v=U5h6B7eSiAE

`	`-Azure Service Bus — Entendendo seu funcionamento: https://renicius-pagotto.medium.com/azure-service-bus-entendendo-seu-funcionamento-parte-1-52ab641a4d00


Instalar RabbitMQ Windows:

`	`-Powershell como Admin: $ choco install rabbitmq

Acessar a pasta:

`	`cd C:\Program Files\RabbitMQ Server\rabbitmq\_server-3.11.17\sbin

`	`rabbitmq-plugins enable rabbitmq\_managment

Acessa pelo browser:

`	`localhost:15672

user: guest
senha: guest

Pacote Nuget RabbitMQ.Client

`	`NuGet\Install-Package RabbitMQ.Client -Version 6.5.0

NET Client

`	`dotnet add package RabbitMQ.Client --version 6.5.0