using System;
using System.Collections.Generic;

class SubstitutionCipher
{
    private Dictionary<char, char> encryptionMap;
    private Dictionary<char, char> decryptionMap;

    public SubstitutionCipher(Dictionary<char, char> map)
    {
        encryptionMap = map;
        decryptionMap = new Dictionary<char, char>();

        // Create a decryption map by reversing the encryption map
        foreach (var kvp in encryptionMap)
        {
            decryptionMap.Add(kvp.Value, kvp.Key);
        }
    }

    public string Encrypt(string plaintext)
    {
        char[] encryptedChars = new char[plaintext.Length];

        for (int i = 0; i < plaintext.Length; i++)
        {
            if (encryptionMap.ContainsKey(plaintext[i]))
            {
                encryptedChars[i] = encryptionMap[plaintext[i]];
            }
            else
            {
                // If the character is not in the encryption map, keep it unchanged
                encryptedChars[i] = plaintext[i];
            }
        }

        return new string(encryptedChars);
    }

    public string Decrypt(string ciphertext)
    {
        char[] decryptedChars = new char[ciphertext.Length];

        for (int i = 0; i < ciphertext.Length; i++)
        {
            if (decryptionMap.ContainsKey(ciphertext[i]))
            {
                decryptedChars[i] = decryptionMap[ciphertext[i]];
            }
            else
            {
                // If the character is not in the decryption map, keep it unchanged
                decryptedChars[i] = ciphertext[i];
            }
        }

        return new string(decryptedChars);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Define the substitution map
        Dictionary<char, char> substitutionMap = new Dictionary<char, char>
        {
            {'A', 'X'}, {'B', 'Y'}, {'C', 'Z'}, {'D', 'W'}, {'E', 'V'},
            {'F', 'U'}, {'G', 'T'}, {'H', 'S'}, {'I', 'R'}, {'J', 'Q'},
            {'K', 'P'}, {'L', 'O'}, {'M', 'N'}, {'N', 'M'}, {'O', 'L'},
            {'P', 'K'}, {'Q', 'J'}, {'R', 'I'}, {'S', 'H'}, {'T', 'G'},
            {'U', 'F'}, {'V', 'E'}, {'W', 'D'}, {'X', 'C'}, {'Y', 'B'},
            {'Z', 'A'},
            {'a', 'x'}, {'b', 'y'}, {'c', 'z'}, {'d', 'w'}, {'e', 'v'},
            {'f', 'u'}, {'g', 't'}, {'h', 's'}, {'i', 'r'}, {'j', 'q'},
            {'k', 'p'}, {'l', 'o'}, {'m', 'n'}, {'n', 'm'}, {'o', 'l'},
            {'p', 'k'}, {'q', 'j'}, {'r', 'i'}, {'s', 'h'}, {'t', 'g'},
            {'u', 'f'}, {'v', 'e'}, {'w', 'd'}, {'x', 'c'}, {'y', 'b'},
            {'z', 'a'}
        };

        // Create a substitution cipher instance
        SubstitutionCipher cipher = new SubstitutionCipher(substitutionMap);

        Console.WriteLine("Enter a message to encrypt:");
        string plaintext = Console.ReadLine().ToUpper(); // Convert input to uppercase

        // Encrypt the input message
        string ciphertext = cipher.Encrypt(plaintext);
        Console.WriteLine("Encrypted message: " + ciphertext);

        // Decrypt the encrypted message
        string decryptedText = cipher.Decrypt(ciphertext);
        Console.WriteLine("Decrypted message: " + decryptedText);
        Console.ReadLine();
    }
}
