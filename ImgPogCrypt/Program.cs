using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ImgPogCrypt
{
    class Program
    {
        /*
         * -em 
         *  secret message to encrypt into image
         * -o
         *  output where  image should be stored
         * -d
         *  decrypt from image file path
         * -ef
         *  path to a file with text to encrypt into image
         */
        static void Main(string[] args)
        {
            Console.WriteLine("-h to help");
            BaseDecryptor baseDecryptor = new BaseDecryptor();
            BaseEncryptor baseEncryptor = new BaseEncryptor();
            RgbConverter rgbConverter = new RgbConverter();
            EncryptedImageParser parser = new EncryptedImageParser();

            List<CliCommand> cliCommands = CliUtil.ParseArgs(args);

            if (cliCommands.Any(c => c.Action == CliAction.Em || c.Action == CliAction.Ef))
            {
                Bitmap outputMap = null;
                CliCommand outputCommand = cliCommands.Find(c => c.Action == CliAction.O);
                if (outputCommand == null) throw new Exception("Unsupported action, make sure to give path -o missing");
                CliCommand command = cliCommands.Find(c => c.Action == CliAction.Em || c.Action == CliAction.Ef);
                if (command.Action == CliAction.Em)
                {
                    outputMap = rgbConverter.ToBitmap(baseEncryptor.Encrypt(command.Value));
                }
                else if (command.Action == CliAction.Ef)
                {
                    if (File.Exists(command.Value))
                    {
                        String inputFile = File.ReadAllText(command.Value, Encoding.UTF8);
                        outputMap = rgbConverter.ToBitmap(baseEncryptor.Encrypt(inputFile));
                    }
                }

                outputMap.Save(outputCommand.Value);
            }
            else if (cliCommands.Any(c => c.Action == CliAction.D))
            {
                CliCommand command = cliCommands.Find(c => c.Action == CliAction.D);
                if (File.Exists(command.Value))
                {
                    Bitmap inputMap = new Bitmap(command.Value);
                    string s = baseDecryptor.Decrypt(parser.Parse(inputMap));
                    Console.WriteLine(s);
                }
            }
            else if (cliCommands.Any(c => c.Action == CliAction.H))
            {
                Console.WriteLine("-em ");
                Console.WriteLine("secret message to encrypt into image");
                Console.WriteLine("-o");
                Console.WriteLine("output where  image should be stored");
                Console.WriteLine("-d");
                Console.WriteLine("decrypt from image file path");
                Console.WriteLine("-ef");
                Console.WriteLine("path to a file with text to encrypt into image");
                Console.WriteLine("-o must be used with -em or -ef");
            }
            else
            {
                throw new Exception("Unsupported action, use -d or -e");
            }
        }
    }
}