using Logger.Core;
using Logger.Core.Contracts;
using Logger.Factories;
using Logger.Models.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int appenderCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            ParseAppendersInput(appenderCount, appenders);

            ILogger logger = new Logger.Models.Logger(appenders);

            IEngine engine = new Engine(logger);
            engine.Run();
        }

        private static void ParseAppendersInput(int appenderCount, ICollection<IAppender> appenders)
        {
            AppenderFactory appenderFactory = new AppenderFactory();

            for (int i = 0; i < appenderCount; i++)
            {
                string[] appendersArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];
                string level = "INFO";

                if (appendersArgs.Length == 3)
                {
                    level = appendersArgs[2];
                }

                try
                {
                    IAppender appender = appenderFactory.ProduceAppender(appenderType, layoutType, level);
                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }


            }
        }
    }
}
