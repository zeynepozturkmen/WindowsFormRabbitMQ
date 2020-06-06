using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormRabbitMQ
{
    public class RabbitMQService
    {
        // localhost üzerinde kurulu olduğu için host adresi olarak bunu kullanıyorum.
        private readonly string _hostName = "localhost";

        public IConnection GetRabbitMQConnection()
        {

            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                //Yukarıdaki satır ile açmış olduğumuz connection üzerinden “CreateModel” method’unu çağırarak, RabbitMQ üzerinde yeni bir channel/session yaratmaktayız. Bu Channel sayesinde bir Queue oluşturabilirken, mesaj gönderme işlemlerini de gerçekleştirebilmekteyiz.

                // RabbitMQ'nun bağlantı kuracağı host'u tanımlıyoruz. Herhangi bir güvenlik önlemi koymak istersek, Management ekranından password adımlarını tanımlayıp factory içerisindeki "UserName" ve "Password" property'lerini set etmemiz yeterlidir.
                HostName = _hostName
            };

            return connectionFactory.CreateConnection();
        }
    }
}
