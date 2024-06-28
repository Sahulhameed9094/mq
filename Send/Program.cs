using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();


const string message = "coming from code for fanout";
var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange: "request.exchange",
                     routingKey: "",
                     basicProperties: null,
                     body: body);
Console.WriteLine($" [x] Sent: {message}");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();