using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLAutomation
{
    public class Demo1AsynConceptTest
    {
        public async Task<string> GetHello()
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine(i);
                await Task.Delay(1000);
            }
            return "Hello, How are you";
        }

        [Test]
        public async Task CallHello1Test()
        {
            var callIt=GetHello();

            //await Task.Delay(5000);
          
            Console.WriteLine("doing some task independently");
            Console.WriteLine("doing some task independently");
            Console.WriteLine("doing some task independently - 20s - assume is taken");

            //check the executed method and get the output - here await - (if mtd not completed await and get, mtd completed get output)
            var output = await callIt;
            Console.WriteLine(output);
            Console.WriteLine("all task done");
        }

        [Test]
        public async Task CallHello2Test()
        {
            //async method to complete before moving on to next step then use await
            var output = await GetHello();


            Console.WriteLine("depends on GetHello()"+ output);
            Console.WriteLine("doing some task independently");
            Console.WriteLine("doing some task independently - 20s - assume is taken");

            Console.WriteLine("all task done");
        }

        //will start at 11:33 AM IST
    }
}
