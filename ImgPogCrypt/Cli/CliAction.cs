namespace ImgPogCrypt
{
    /*
     * -m 
     *  secret message to encrypt into image
     * -o
     *  output where  image should be stored
     * -d
     *  decrypt from image file path
     * -e
     *  encrypt
     * -f
     *  path to a file with text to encrypt into image
     */
    public enum CliAction
    {
        Em,
        O,
        D,
        Ef,
        H
    }
}