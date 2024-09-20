using GuessNumber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber.Concrete
{
    internal class MySettings : ISettings
    {
        public int Min { get => Settings.Default.Min; }
        public int Max { get => Settings.Default.Max; }
        public int Amount { get => Settings.Default.Amount; }
    }
}
