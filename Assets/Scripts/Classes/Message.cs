using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Message 
{
    public string encodedString;
    public string originalString;
    public EnkryptionKeyClass key;

    public Message()
    {
        originalString = "";
        encodedString = "";
        key = new EnkryptionKeyClass();
    }

    public char encodeChar(char c)
    {
        int letter = charToNum(c);
        if (letter != -1)
        {
            letter = key.plugboard[letter];
            letter = key.rotor1[(letter + key.augment) % 26];
            if (key.augment % 26 == 0 && key.augment / 26 != 0)
            {
                letter = key.rotor2[(letter + key.augment / 26 * 2 - 1) % 26];
            }
            else
            {
                letter = key.rotor2[(letter + key.augment / 26 * 2) % 26];
            }
            if (key.augment % 26 == 0 && key.augment / 26 != 0)
            {
                letter = key.rotor3[(letter + key.augment / 26 - 1) % 26];
            }
            else
            {
                letter = key.rotor3[(letter + key.augment / 26) % 26];
            }
            letter = Singleton.reflector[letter];
            if (key.augment % 26 == 0 && key.augment / 26 != 0)
            {
                letter = inverseRotor(key.rotor3, letter) - (key.augment / 26 - 1) % 26;
            }
            else
            {
                letter = inverseRotor(key.rotor3, letter) - (key.augment / 26) % 26;
            }
            if (letter<0)
            {
                letter = letter + 26;
            }
            if (key.augment % 26 == 0 && key.augment / 26 != 0)
            {
                letter = inverseRotor(key.rotor2, letter) - (key.augment / 26 * 2 - 1) % 26;
            }
            else
            {
                letter = inverseRotor(key.rotor2, letter) - (key.augment / 26 * 2) % 26;
            }
            if (letter<0)
            {
                letter = letter + 26;
            }
            letter = inverseRotor(key.rotor1, letter) - (key.augment % 26);
            if (letter<0)
            {
                letter = letter + 26;
            }
            letter = key.plugboard[letter];
            c = numToChar(letter);
            key.augment++;
        }
        return c;

    }
    public static int charToNum(char c)
    {
        switch (c)
        {
            case 'a':
                return 0;
            case 'b':
                return 1;
            case 'c':
                return 2;
            case 'd':
                return 3;
            case 'e':
                return 4;
            case 'f':
                return 5;
            case 'g':
                return 6;
            case 'h':
                return 7;
            case 'i':
                return 8;
            case 'j':
                return 9;
            case 'k':
                return 10;
            case 'l':
                return 11;
            case 'm':
                return 12;
            case 'n':
                return 13;
            case 'o':
                return 14;
            case 'p':
                return 15;
            case 'q':
                return 16;
            case 'r':
                return 17;
            case 's':
                return 18;
            case 't':
                return 19;
            case 'u':
                return 20;
            case 'v':
                return 21;
            case 'w':
                return 22;
            case 'x':
                return 23;
            case 'y':
                return 24;
            case 'z':
                return 25;
        }
        return -1;
    }

    public static char numToChar(int letter)
    {
        switch (letter)
        {
            case 0:
                return 'a';
            case 1:
                return 'b';
            case 2:
                return 'c';
            case 3:
                return 'd';
            case 4:
                return 'e';
            case 5:
                return 'f';
            case 6:
                return 'g';
            case 7:
                return 'h';
            case 8:
                return 'i';
            case 9:
                return 'j';
            case 10:
                return 'k';
            case 11:
                return 'l';
            case 12:
                return 'm';
            case 13:
                return 'n';
            case 14:
                return 'o';
            case 15:
                return 'p';
            case 16:
                return 'q';
            case 17:
                return 'r';
            case 18:
                return 's';
            case 19:
                return 't';
            case 20:
                return 'u';
            case 21:
                return 'v';
            case 22:
                return 'w';
            case 23:
                return 'x';
            case 24:
                return 'y';
            case 25:
                return 'z';
        }
        return '#';
    }
    public int inverseRotor(int[] rotor, int input)
    {
        for (int i = 0; i < rotor.Length; i++)
        {
            if (rotor[i] == input)
            {
                return i;
            }
        }
        return -1;
    }

    public void encodeMessage()
    {
        for (int i = 0; i < originalString.Length; i++)
        {
            char curr = originalString[i];
            curr = encodeChar(curr);
            encodedString = encodedString + curr;
        }
    }
 
}
