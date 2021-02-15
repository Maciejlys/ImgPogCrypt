namespace ImgPogCrypt
{
    /*
         * -em : secret message to encrypt into image
         * -ef : path to a file with text to encrypt into image
         * -o  : output where image should be stored
         * -b  : base image
         * -d  : decrypt from image file path
     */
    public enum CliAction
    {
        Em,
        O,
        D,
        Ef,
        H,
        B
    }
}