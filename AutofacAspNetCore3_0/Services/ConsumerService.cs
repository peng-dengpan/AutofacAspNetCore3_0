using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutofacAspNetCore3_0.Services
{
    public class ConsumerService : IConsumerService

    {
        public string get(int id)
        {
            return " 消费者 消费id=" + id;
        }
    }
}
