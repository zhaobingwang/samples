using Sample.Infrastructure.Framework;
using Sample.Utilities.Framework.RabbitMQOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.WindowsService
{
    public class MQConsumer : Consumer
    {
        public const string QUEUE_NAME = "click_house";

        public MQConsumer() : base(QUEUE_NAME)
        {

        }
        static TaskFactory fac = null;
        public override bool MessageConsume(string message)
        {
            try
            {

                //System.Threading.ThreadPool.SetMaxThreads(2, 2);
                //if (fac == null)
                //{
                //    fac = new TaskFactory(new LimitedConcurrencyLevelTaskScheduler(5));
                //}

                //fac.StartNew(() =>
                //{
                //    Do(message);
                //});

                Task.Run(() =>
                {
                    Do(message);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;
        }

        BaseAccess<User> baseAccess = new BaseAccess<User>();
        private void Do(string message)
        {
            try
            {

                var result = baseAccess.Insert(new User { Id = 1, Name = "测试", RegDate = DateTime.Now }, "test");
                //Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime RegDate { get; set; }
    }
}
