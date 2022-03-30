using CommandLine;

namespace C314.SmallerCSAppsBundle
{
    [Verb("options", isDefault: true, HelpText = "Default options.")]
    public class Options : Common.IVerb
    { 
        [Option('k', "keycodes", Required = false, HelpText = "Runs the KeyCodes program which displays the keycode of the key you pressed in this format:\n<key you pressed> -> <keycode>")]
        public bool Keycodes { get; set; }

        public void HandleInput()
        {
            if (Keycodes)
            {
                ProjOne.KeyCodes.KeyCodesMain();
                return;
            }
        }
    }
}
