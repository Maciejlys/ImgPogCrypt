namespace ImgPogCrypt
{
    public class CliCommand
    {
        public CliAction Action { get; set; }
        public string Value { get; set; }

        public CliCommand(CliAction action, string value)
        {
            Action = action;
            Value = value;
        }
    }
}