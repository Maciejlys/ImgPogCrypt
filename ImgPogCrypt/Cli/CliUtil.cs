using System;
using System.Collections.Generic;
using System.Linq;

namespace ImgPogCrypt
{
    public class CliUtil
    {
        public static List<CliCommand> ParseArgs(string[] args)
        {
            return args.ToList().Select(CliUtil.StringToCommand).ToList();
        }

        private static CliCommand StringToCommand(string arg)
        {
            CliAction cliAction;
            string value = "";
            if (arg.Contains("="))
            {
                string[] strings = arg.Split("=");
                value = strings[1];
                cliAction = StringToCliAction(strings[0]);
            }
            else
            {
                cliAction = StringToCliAction(arg);
            }

            return new CliCommand(cliAction, value);
        }

        private static CliAction StringToCliAction(string s)
        {
            switch (s)
            {
                default:
                    throw new ArgumentException("Unsupported action");

                case "-em":
                    return CliAction.Em;
                case "-o":
                    return CliAction.O;
                case "-d":
                    return CliAction.D;
                case "-ef":
                    return CliAction.Ef;
                case "-h":
                    return CliAction.H;
            }
        }
    }
}