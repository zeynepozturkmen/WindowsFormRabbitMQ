using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormRabbitMQ
{
    public class Publisher
    {

        private readonly RabbitMQService _rabbitMQService;

        public Publisher(string queueName, string message)
        {
            _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                //Bu satırda ise method isminden de anlaşılabileceği üzere, yeni bir queue tanımlıyoruz
                //
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);
                    //queue: Oluşturulacak olan Queue’nun ismi.
                    //durable: Bu parametre ile in-memory olarak çalışan Queue disk üzerinden çalışmaya başlayacaktır.Bu sayede RabbitMQ servisi dursa bile Queue kaybolmayacaktır. Her güzelliğin getirdiği bir kötü tarafın olduğu gibi bununda beraberinde getireceği latency problemi bulunmaktadır haliyle.

                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(message));
                    //“BasicPublish” method’u ile kolay bir şekilde oluşturmuş olduğumuz ilgili Queue’ya mesaj gönderiyoruz.
                    //routingKey: Burada girmiş olduğumuz key’e göre ilgili Queue’ya yönlendirilecektir mesaj.
                    //body: Queue’ya göndermek istediğimiz mesajı byte[] tipinde gönderiyoruz.
                }
            }
        }

    }
}
