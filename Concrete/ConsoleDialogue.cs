using GuessNumber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Concrete
{
    internal class ConsoleDialogue : IDialogue<string>
    {
        public string? Read()
        {
            return Console.ReadLine();
        }

        public void Write(string value)
        {
            Console.WriteLine(value);
        }
    }
}
