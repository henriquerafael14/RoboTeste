using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Arpti.RoboInstalador
{
	public class RabbitMQService
	{
		private readonly string _queueName = "Arpti_RoboInstalador_Envios";
		private readonly ConnectionFactory _configuracao;
		private readonly IConnection _conexao;
		private readonly IModel _canal;

		public RabbitMQService()
		{
			_configuracao = new ConnectionFactory { HostName = "localhost" };
			_configuracao.Port = 5672;
			_configuracao.UserName = "guest";
			_configuracao.Password = "guest";

			_conexao = _configuracao.CreateConnection();

			_canal = _conexao.CreateModel();
			_canal.QueueDeclare(_queueName, false, false, false, null);
		}

		public void PublicarMensagem(string mensagem)
		{
			var body = Encoding.UTF8.GetBytes(mensagem);
			var novoCanal = _conexao.CreateModel();
			novoCanal.QueueDeclare("Arpti_RoboInstalador_Respostas", false, false, false, null);
			novoCanal.BasicPublish("", "Arpti_RoboInstalador_Respostas", null, body);
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

			_canal.BasicConsume(_queueName, true, consumer);
		}

		public void Dispose()
		{
			_canal.Close();
			_conexao.Close();
		}
	}
	//public class RabbitMQService
	//{
	//	private readonly string _queueName = "Arpti_RoboInstalador";
	//	private readonly ConnectionFactory _configuracao;
	//	private readonly IConnection _conexao;
	//	private readonly IModel _canal;

	//	public RabbitMQService()
	//	{
	//		_configuracao = new ConnectionFactory { HostName = "localhost" };
	//		_configuracao.Port = 5672;
	//		_configuracao.UserName = "guest";
	//		_configuracao.Password = "guest";

	//		try
	//		{
	//			_conexao = _configuracao.CreateConnection();

	//			_canal = _conexao.CreateModel();
	//			_canal.QueueDeclare(_queueName, false, false, false, null);
	//		}
	//		catch (Exception ex)
	//		{
	//			throw ex;
	//		}
	//	}

	//	public void PublicarMensagem(string mensagem)
	//	{
	//		var body = Encoding.UTF8.GetBytes(mensagem);
	//		_canal.BasicPublish("", _queueName, null, body);
	//	}

	//	public void StartListening(Action<string> messageHandler)
	//	{
	//		var consumer = new EventingBasicConsumer(_canal);
	//		consumer.Received += (model, ea) =>
	//		{
	//			var body = ea.Body.ToArray();
	//			var message = Encoding.UTF8.GetString(body);
	//			messageHandler(message);
	//		};

	//		_canal.BasicConsume(_queueName, true, consumer);
	//	}

	//	public void Dispose()
	//	{
	//		_canal.Close();
	//		_conexao.Close();
	//	}
	//}
}