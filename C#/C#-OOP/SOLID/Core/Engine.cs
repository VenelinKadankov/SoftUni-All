using Logger.Core.Contracts;
using Logger.Factories;
using Logger.Models.Conflicts;
using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input?.ToUpper() != "END")
            {
                string[] inputArs = input.Split("|", StringSplitOptions.RemoveEmptyEntries);

                string level = inputArs[0];
                string dateTime = inputArs[1];
                string message = inputArs[2];

                try
                {
                    IError error = errorFactory.ProduceError(dateTime, message, level);

                    this.logger.Log(error);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }


                input = Console.ReadLine();
            }

            Console.WriteLine(this.logger);
        }
    }
}
