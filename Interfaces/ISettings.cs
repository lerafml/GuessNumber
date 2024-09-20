using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Interfaces
{
    internal interface ISettings
    {
        int Min { get; }
        int Max { get; }
        int Amount { get; }
    }
}
