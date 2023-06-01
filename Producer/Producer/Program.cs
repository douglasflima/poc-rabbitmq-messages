//Define uma conexão com o node RabbitMQ em localho
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory()
{
  HostName = "localhost"
};

//Abre a conexão com um node do RabbitMQ
using var connection = factory.CreateConnection();

/*Cria um canal a onde será definido uma 
 queue, uma msg publicar a msg*/
using var channel = connection.CreateModel();
channel.QueueDeclare(
  queue: "hello_world_1",// Nome da fila
  durable: false, //True: Filha Permanece ativa após server reiniciado
  exclusive: false, //True: Só pode ser acessada pela conexão atual e são excluídas ao fechar a conexão
  autoDelete: false, //True: Será deletada automaticamente após os consumers usarem a queue
  arguments: null);

var message = "Welcome to RabbitMQ TOTVS";

//Msg em dada binário
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(
  exchange: "",
  routingKey: "hello_world_1",
  basicProperties: null,
  body: body);

Console.WriteLine($" [x] Enviada: {message}");