using GuessNumber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Concrete
{
    internal class Generator : IGenerator
    {
        public int Generate(int min, int max)
        {
            return new Random().Next(min, max + 1);
        }
    }
}
