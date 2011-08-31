using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RabbitHello
{
	using RabbitMQ.Client;
	using RabbitMQ.Client.Framing.v0_8;

	class Program
	{
		static void Main(string[] args)
		{
			var connectionFactory = new ConnectionFactory();
			connectionFactory.HostName = "localhost";
			using (var connection = connectionFactory.CreateConnection())
			{
				using (IModel model = connection.CreateModel())
				{
					model.QueueDeclare("BLAH", false, false, false, new Dictionary<string, object>());
					var properties = model.CreateBasicProperties();
					var message = "Hello";
					model.BasicPublish("", "", false, true, properties, Encoding.UTF8.GetBytes(message));
				}	
			}
		}
	}
}
