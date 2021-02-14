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
            string[] strings = arg.Split("=");
            CliAction cliAction;
            switch (strings[0])
            {
                default:
                    throw new ArgumentException("Unsupported action");

                case "-em":
                    cliAction = CliAction.Em;
                    break;
                case "-o":
                    cliAction = CliAction.O;
                    break;
                case "-d":
                    cliAction = CliAction.D;
                    break;
                case "-ef":
                    cliAction = CliAction.Ef;
                    break;
                case "-h":
                    cliAction = CliAction.H;
                    break;
            }

            return new CliCommand(cliAction, strings[1]);
        }
    }
}