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
                return 'A';
            case 1:
                return 'B';
            case 2:
                return 'C';
            case 3:
                return 'D';
            case 4:
                return 'E';
            case 5:
                return 'F';
            case 6:
                return 'G';
            case 7:
                return 'H';
            case 8:
                return 'I';
            case 9:
                return 'J';
            case 10:
                return 'K';
            case 11:
                return 'L';
            case 12:
                return 'M';
            case 13:
                return 'N';
            case 14:
                return 'O';
            case 15:
                return 'P';
            case 16:
                return 'Q';
            case 17:
                return 'R';
            case 18:
                return 'S';
            case 19:
                return 'T';
            case 20:
                return 'U';
            case 21:
                return 'V';
            case 22:
                return 'W';
            case 23:
                return 'X';
            case 24:
                return 'Y';
            case 25:
                return 'Z';
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
