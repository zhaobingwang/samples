using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

namespace Sample.WindowsService
{
    class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<ServiceManager>(s =>
                {
                    s.ConstructUsing(name => new ServiceManager());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Sample Topshelf Host");
                x.SetDisplayName("Stuff");
                x.SetServiceName("Stuff");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;


            //int workerThreadCount;
            //int ioThreadCount;

            //System.Threading.ThreadPool.SetMaxThreads(10, 10);
            //System.Threading.ThreadPool.GetMaxThreads(out workerThreadCount, out ioThreadCount);


            //Console.WriteLine(workerThreadCount);
            //Console.WriteLine(ioThreadCount);

        }
    }


    public class ServiceManager
    {
        private MQConsumer mqConsumer = null;
        public ServiceManager()
        {
 
        }
        public void Start()
        {
            mqConsumer = new MQConsumer();
            mqConsumer.StartConsume();
        }
        public void Stop()
        {
            if (mqConsumer != null)
            {
                mqConsumer.StopConsume();
            }
        }
    }
    public class HelloWorld
    {
        readonly Timer _timer;
        public HelloWorld()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} and all is well", DateTime.Now);
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }
}
