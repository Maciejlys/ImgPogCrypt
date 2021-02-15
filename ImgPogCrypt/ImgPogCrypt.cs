﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace ImgPogCrypt
{
    public class ImgPogCrypt
    {
        static readonly BaseDecryptor Decryptor = new BaseDecryptor();
        static readonly BaseEncryptor Encryptor = new BaseEncryptor();
        static readonly RgbConverter Converter = new RgbConverter();
        static readonly EncryptedImageParser Parser = new EncryptedImageParser();

        private string[] args;

        public ImgPogCrypt(string[] args)
        {
            this.args = args;
        }

        public void Start()
        {
            List<CliCommand> cliCommands = CliUtil.ParseArgs(args);

            CliCommand encryptCommand = cliCommands.Find(c => c.Action == CliAction.Em || c.Action == CliAction.Ef);
            CliCommand decryptCommand = cliCommands.Find(c => c.Action == CliAction.D);
            CliCommand baseMapCommand = cliCommands.Find(c => c.Action == CliAction.B);

            if (encryptCommand != null)
            {
                Bitmap outputMap = null;
                CliCommand outputCommand = cliCommands.Find(c => c.Action == CliAction.O);
                if (outputCommand == null) throw new Exception("Unsupported action, make sure to give path -o missing");

                if (encryptCommand.Action == CliAction.Em)
                {
                    if (baseMapCommand != null && File.Exists(baseMapCommand.Value))
                    {
                        Bitmap inputMap = new Bitmap(baseMapCommand.Value);
                        outputMap = Converter.ToBitmap(Encryptor.Encrypt(encryptCommand.Value), inputMap);
                    }
                    else
                    {
                        outputMap = Converter.ToBitmap(Encryptor.Encrypt(encryptCommand.Value));
                    }
                }
                else if (encryptCommand.Action == CliAction.Ef && File.Exists(encryptCommand.Value))
                {
                    String inputFile = File.ReadAllText(encryptCommand.Value, Encoding.UTF8);

                    if (baseMapCommand != null && File.Exists(baseMapCommand.Value))
                    {
                        Bitmap inputMap = new Bitmap(baseMapCommand.Value);
                        outputMap = Converter.ToBitmap(Encryptor.Encrypt(inputFile), inputMap);
                    }
                    else
                    {
                        outputMap = Converter.ToBitmap(Encryptor.Encrypt(inputFile));
                    }
                }

                if (outputMap != null)
                {
                    outputMap.Save(outputCommand.Value);
                }
                else
                {
                    throw new ArgumentException("Invalid arguments");
                }
            }
            else if (decryptCommand != null && File.Exists(decryptCommand.Value))
            {
                Bitmap inputMap = new Bitmap(decryptCommand.Value);
                String result = "";
                if (baseMapCommand != null && File.Exists(baseMapCommand.Value))
                {
                    Bitmap basemap = new Bitmap(baseMapCommand.Value);
                    result = Decryptor.Decrypt(Parser.Parse(inputMap, basemap));
                }
                else
                {
                    result = Decryptor.Decrypt(Parser.Parse(inputMap));
                }

                Console.WriteLine(result);
            }
            else if (cliCommands.Any(c => c.Action == CliAction.H))
            {
                Console.WriteLine("-em : secret message to encrypt into image");
                Console.WriteLine("-o : output where  image should be stored");
                Console.WriteLine("-d : decrypt from image file path");
                Console.WriteLine("-ef : path to a file with text to encrypt into image");
                Console.WriteLine("-o must be used with -em or -ef");
                Console.WriteLine("-b  : base image");
            }
            else
            {
                throw new Exception("Unsupported action, use -d or -e");
            }
        }
    }
}