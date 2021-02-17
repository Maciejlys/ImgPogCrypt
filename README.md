# ImgPogCrypt

Hi! ImgPogCrypt is a simple C# program that lets you hide a **text** inside an **image**!

# How it works?

Note: every pixel is defined by 3 colors (rgb) - amount of red, green and blue.

## Encrypting

User gives our program an input - **text** that is converted into a binary representation.
With given list of zeros and one's we iterate through base **image** pixels incrementing them if its possible or if we need to. Then our program outputs new image with hidden message to given path.

It is possbile to encrypt a message without a base image. The output will be a black square.

## Decrypting

We can't decrypt hidden message without a base image! that is image which was used to encrypt message (we can decrypt without a base image if the encryption was created without a base image).
User gives our program information where the base image is and where the encrypted image is. ImgPogCrypt loads two images and checks differences within them.
From that difference program is able to decrypt the hidden message inside image.

# How to use?

Interaction with program is done by our poorly written CLI.
We tried to keep is as simple as possible as we focused more on the problem than on user interaction.

## Commands

### Encrypting

- **-em** : (encrypt message) secret message to encrypt into image
- **-ef** : (encrypt file) path to a file with text to encrypt into image
- **-o** : (output) output where image should be stored

### Decrypting

- **-b** : (base) base image
- **-d** : (decrypt) decrypt from image file path

## Example usage

To encrypt a message without base image:

> -em=Hello -o=**full path**\user\Desktop\output.jpg

To decrypt a message without base image:

> -d=**full path**\user\Desktop\output.jpg

To encrypt a message from txt file:

> -ef=**full path**\user\Desktop\input.txt -b=**full path**\user\Desktop\base.jpg -o=**full path**\user\Desktop\output.jpg

To encrypt a message from CLI:

> -em=Hello -b=**full path**\user\Desktop\base.jpg -o=**full path**\user\Desktop\output.jpg

To decrypt:

> -d=**full path**\user\Desktop\output.jpg -b=**full path**\user\Desktop\base.jpg

# Contributors
