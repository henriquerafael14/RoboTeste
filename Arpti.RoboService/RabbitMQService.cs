using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arpti.RoboService
{
    public class RabbitMQService
    {
        private readonly string _queueName;
        private readonly ConnectionFactory _configuracao;
        private readonly IConnection _conexao;
        private readonly IModel _canal;

        public RabbitMQService(string queueName)
        {
            _queueName = queueName;

            _configuracao = new ConnectionFactory { HostName = "localhost" };
            _configuracao.Port = 5672;
            _configuracao.UserName = "guest";
            _configuracao.Password = "guest";
            _conexao = _configuracao.CreateConnection();
            _canal = _conexao.CreateModel();

            _canal.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void StartListening(Action<string> messageHandler)
        {
            var consumer = new EventingBasicConsumer(_canal);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                messageHandler(message);
            };

            _canal.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);
        }

        public void Dispose()
        {
            _canal.Close();
            _conexao.Close();
        }
    }
}
