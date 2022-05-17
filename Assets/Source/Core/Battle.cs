using System.Threading;

namespace Assets.Source.Core
{
    public class Battle
    {
        public Battle()
        {
            Loop();
        }

        public void Loop()
        {
            int counter = 0;
            while (counter < 10)
            {
                UserInterface.Singleton.SetText(counter.ToString(), UserInterface.TextPosition.BottomCenter);
                counter++;
                Thread.Sleep(300);
            }
        }
    }
}