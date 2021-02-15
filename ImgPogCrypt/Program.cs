namespace ImgPogCrypt
{
    class Program
    {
        /*
         * -em : secret message to encrypt into image
         * -ef : path to a file with text to encrypt into image
         * -o  : output where image should be stored
         * -b  : base image
         * -d  : decrypt from image file path
         */
        static void Main(string[] args)
        {
            ImgPogCrypt imgPogCrypt = new ImgPogCrypt(args);
            imgPogCrypt.Start();
        }
    }
}