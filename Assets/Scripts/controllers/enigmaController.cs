using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enigmaController : MonoBehaviour
{
    // Start is called before the first frame update
    static bool encodeInProgress = false;
    public bool decoding = false;
    public TMP_Text message;
    static int[] reflector = { 5, 21, 9, 0, 22, 7, 8, 1, 15, 23, 11, 2, 4, 3, 6, 20, 25, 10, 24, 16, 19, 12, 17, 13, 18, 14 };
    void Start()
    {
        message.text = Singleton.originalString;
        Singleton.key.generateKey(10);
    }

    // Update is called once per frame
    void Update()
    {
        char c;
        int letter =-1;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space key was pressed");
        }
            if (Input.GetKeyUp(KeyCode.A)){
                letter = 0;
                Singleton.originalString += "a";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.B)){
                letter = 1;
                Singleton.originalString += "b";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.C)){
                letter = 2;
                Singleton.originalString += "c";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.D)){
                letter = 3;
                Singleton.originalString += "d";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.E)){
                letter = 4;
                Singleton.originalString += "e";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.F)){
                letter = 5;
                Singleton.originalString += "f";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.G)){
                letter = 6;
                Singleton.originalString += "g";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.H)){
                letter = 7;
                Singleton.originalString += "h";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.I)){
                letter = 8;
                Singleton.originalString += "i";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.J)){
                letter = 9;
                Singleton.originalString += "j";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.K)){
                letter = 10;
                Singleton.originalString += "k";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.L)){
                letter = 11;
                Singleton.originalString += "l";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.M)){
                letter = 12;
                Singleton.originalString += "m";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.N)){
                letter = 13;
                Singleton.originalString += "n";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.O)){
                letter = 14; 
                Singleton.originalString += "o";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.P)){
                letter = 15;
                Singleton.originalString += "p";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.Q)){
                letter = 16;
                Singleton.originalString += "q";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.R)){
                letter = 17;
                Singleton.originalString += "r";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.S)){
                letter = 18;
                Singleton.originalString += "s";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.T)){
                letter = 19;
                Singleton.originalString += "t";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.U)){
                letter = 20;
                Singleton.originalString += "u";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.V)){
                letter = 21;
                Singleton.originalString += "v";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.W)){
                letter = 22;
                Singleton.originalString += "w";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.X)){
                letter = 23;
                Singleton.originalString += "x";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.Y)){
                letter = 24;
                Singleton.originalString += "y";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.Z)){
                letter = 25;
                Singleton.originalString += "z";
                Debug.Log(Singleton.originalString);
            }
            else if (Input.GetKeyDown(KeyCode.Space)){
                Singleton.originalString += " ";
                Singleton.encodedString += " ";
                Debug.Log(Singleton.originalString);
            }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Singleton.key.augment = 0;
            decoding = !decoding;
            Singleton.originalString = Singleton.encodedString;
            Singleton.encodedString = "";
        }
        enigmaController.encodeInProgress = true;
            if (letter != -1)
            {
                if (decoding)
                {
                    c = decode(letter);
                }
                else
                {
                    c = encode(letter);
                }
                Singleton.encodedString += c;
            }
        message.text = Singleton.encodedString;
    }
    public static char encode(int letter)
    {
        if (letter != -1)
        {
            letter = Singleton.key.plugboard[letter];
            letter = Singleton.key.rotor1[(letter + Singleton.key.augment) % 26];
            if (Singleton.key.augment % 26 == 0 && Singleton.key.augment / 26 != 0)
            {
                letter = Singleton.key.rotor2[(letter + Singleton.key.augment / 26 * 2 - 1) % 26];
            }
            else
            {
                letter = Singleton.key.rotor2[(letter + Singleton.key.augment / 26 * 2) % 26];
            }
            if (Singleton.key.augment % 26 == 0 && Singleton.key.augment / 26 != 0)
            {
                letter = Singleton.key.rotor3[(letter + Singleton.key.augment / 26 - 1) % 26];
            }
            else
            {
                letter = Singleton.key.rotor3[(letter + Singleton.key.augment / 26) % 26];
            }
            letter = enigmaController.reflector[letter];
            if (Singleton.key.augment % 26 == 0 && Singleton.key.augment / 26 != 0)
            {
                letter = inverseRotor(Singleton.key.rotor3, letter) - (Singleton.key.augment / 26 - 1) % 26;
            }
            else
            {
                letter = inverseRotor(Singleton.key.rotor3, letter) - (Singleton.key.augment / 26) % 26;
            }
            if (letter < 0)
            {
                letter = letter + 26;
            }
            if (Singleton.key.augment % 26 == 0 && Singleton.key.augment / 26 != 0)
            {
                letter = inverseRotor(Singleton.key.rotor2, letter) - (Singleton.key.augment / 26 * 2 - 1) % 26;
            }
            else
            {
                letter = inverseRotor(Singleton.key.rotor2, letter) - (Singleton.key.augment / 26 * 2) % 26;
            }
            if (letter < 0)
            {
                letter = letter + 26;
            }
            letter = inverseRotor(Singleton.key.rotor1, letter) - (Singleton.key.augment % 26);
            if (letter < 0)
            {
                letter = letter + 26;
            }
            letter = Singleton.key.plugboard[letter];
        }
        char c = numToChar(letter);
        Singleton.key.augment++;
        enigmaController.encodeInProgress = false;
        return c;
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
    public static int inverseRotor(int[] rotor, int input)
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
    public static char decode(int letter)
    {
        if (letter != -1)
        {
            letter = Singleton.key.plugboard[letter];
            letter = Singleton.key.rotor1[(letter + Singleton.key.augment) % 26];
            if (Singleton.key.augment % 26 == 0 && Singleton.key.augment / 26 != 0)
            {
                letter = Singleton.key.rotor2[(letter + Singleton.key.augment / 26 * 2 - 1) % 26];
            }
            else
            {
                letter = Singleton.key.rotor2[(letter + Singleton.key.augment / 26 * 2) % 26];
            }
            if (Singleton.key.augment % 26 == 0 && Singleton.key.augment / 26 != 0)
            {
                letter = Singleton.key.rotor3[(letter + Singleton.key.augment / 26 - 1) % 26];
            }
            else
            {
                letter = Singleton.key.rotor3[(letter + Singleton.key.augment / 26) % 26];
            }
            letter = inverseRotor(enigmaController.reflector, letter);
            if (Singleton.key.augment % 26 == 0 && Singleton.key.augment / 26 != 0)
            {
                letter = inverseRotor(Singleton.key.rotor3, letter) - (Singleton.key.augment / 26 - 1) % 26;
            }
            else
            {
                letter = inverseRotor(Singleton.key.rotor3, letter) - (Singleton.key.augment / 26) % 26;
            }
            if (letter<0)
            {
                letter = letter + 26;
            }
            if (Singleton.key.augment % 26 == 0 && Singleton.key.augment / 26 != 0)
            {
                letter = inverseRotor(Singleton.key.rotor2, letter) - (Singleton.key.augment / 26 * 2 - 1) % 26;
            }
            else
            {
                letter = inverseRotor(Singleton.key.rotor2, letter) - (Singleton.key.augment / 26 * 2) % 26;
            }
            if (letter < 0)
            {
                letter = letter + 26;
            }
            letter = inverseRotor(Singleton.key.rotor1, letter) - (Singleton.key.augment % 26);
            if (letter<0)
            {
                letter = letter + 26;
            }
            letter = Singleton.key.plugboard[letter];
        }
        char c = numToChar(letter);
        Singleton.key.augment++;
        enigmaController.encodeInProgress = false;
        return c;

    }
}
