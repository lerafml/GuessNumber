using GuessNumber;
using GuessNumber.Interfaces;
using GuessNumber.Concrete;


IRunnable checker = new CheckNumber(new Generator(), new MySettings(), new ConsoleDialogue());
checker.Run();