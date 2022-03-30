using CommandLine;

namespace C314.SmallerCSAppsBundle.SingleMethodCommands
{
    [Verb("hmstoms", HelpText = "Converts Hours, Minutes and Seconds to milliseconds. Input should be seperated with spaces")]
    public class Hmstoms : Common.IVerb
    {
        [Value(0, HelpText = "Hours")]
        public int H { get; set; }
        [Value(1, HelpText = "Minutes")]
        public int M { get; set; }
        [Value(2, HelpText = "Seconds")]
        public int S { get; set; }

        public void HandleInput()
        {
            Console.WriteLine(Time.HMSToMs(H, M, S));
            return;
        }
    }
}
