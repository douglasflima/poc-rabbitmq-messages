//Define uma conexão com o node RabbitMQ em localhost
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
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

//Solicita a entrega das msgs de forma async e fornece um retorno de chamada
var consumer = new EventingBasicConsumer(channel);

//Recebe a msg da fila e converter para string e imprime no console
consumer.Received += (model, ea) =>
{
  var body = ea.Body.ToArray();
  var message = Encoding.UTF8.GetString(body);
  Console.WriteLine($" [x] Recebida: {message}");
};

//Indica o consumo da msg no RabbitMQ
channel.BasicConsume(
  queue: "hello_world_1",
  autoAck: true,
  consumer: consumer);

Console.ReadLine();