using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VanillaMain2
{
    class Program
    {
        static void Main(string[] args)
        {
            //parameters
            double expiry = 1.0;
            double strike = 50.0;
            double spot = 49.0;
            double vol = 0.2;
            double r = 0.01;

            //input number of montecarlo paths
            ulong number_of_paths = 10000;
            Console.Write("Enter number of montecarlo paths : ");
            number_of_paths = ulong.Parse(Console.ReadLine());

            //create payoff & option object
            PayOff payoff1 = new PayOffCall(strike);
            VanillaOption option1 = new VanillaOption(payoff1, expiry);
            VanillaOption option2 = new VanillaOption(payoff1, expiry);
            
            //montecarlo simulation & output result
            double result = SimpleMC4.SimpleMonteCarlo3(option1, spot, vol, r, number_of_paths);
            Console.WriteLine("the call price is " + result.ToString());
            result = SimpleMC4.SimpleMonteCarlo3(option2, spot, vol, r, number_of_paths);
            Console.WriteLine("the call price is " + result.ToString());
            
            //other payoff
            PayOff payoff2 = new PayOffPut(strike);
            VanillaOption option3 = new VanillaOption(payoff2, expiry);
            option1 = option3.DeepCopy();
            result = SimpleMC4.SimpleMonteCarlo3(option1, spot, vol, r, number_of_paths);
            Console.WriteLine("the put price is " + result.ToString());
            
        
        }
    }
}
