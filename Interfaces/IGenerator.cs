using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Interfaces
{
    internal interface IGenerator
    {
        int Generate(int min, int max);
    }
}
