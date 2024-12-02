using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enigmaController : MonoBehaviour
{
    // Start is called before the first frame update
    static bool encodeInProgress = false;
    public bool decoding = true;
    public TMP_Text message;
    void Start()
    {
        Singleton.curr.key.generateKey(10);
        if (decoding)
        {

            Singleton.curr.originalString = Singleton.preloadedMessages[Singleton.decodeIndex];
            Singleton.curr.encodeMessage();
            Singleton.curr.key.augment = 0;
            Singleton.curr.originalString = "";
            message.text = "\n\tEncoded message: \n\t" + Singleton.curr.encodedString + "\n\t decoded as: \n\t" + Singleton.curr.originalString;
        }
        else
        {
            message.text = "\n\tYour message: \n\t" + Singleton.curr.originalString + "\n\t encoded as: \n\t" + Singleton.curr.encodedString;
        }
    }

    // Update is called once per frame
    void Update()
    {
        char c;
        int letter =-1;
        if (Input.GetKeyUp(KeyCode.A)){
            letter = 0;
        }
        else if (Input.GetKeyDown(KeyCode.B)){
          letter = 1;
        }
         else if (Input.GetKeyDown(KeyCode.C)){
          letter = 2;
        }
        else if (Input.GetKeyDown(KeyCode.D)){
                letter = 3;
        }
            else if (Input.GetKeyDown(KeyCode.E)){
                letter = 4;
        }
            else if (Input.GetKeyDown(KeyCode.F)){
                letter = 5;
            }
            else if (Input.GetKeyDown(KeyCode.G)){
                letter = 6;
            }
            else if (Input.GetKeyDown(KeyCode.H)){
                letter = 7;
            }
            else if (Input.GetKeyDown(KeyCode.I)){
                letter = 8;
            }
            else if (Input.GetKeyDown(KeyCode.J)){
                letter = 9;
            }
            else if (Input.GetKeyDown(KeyCode.K)){
                letter = 10;
            }
            else if (Input.GetKeyDown(KeyCode.L)){
                letter = 11;
            }
            else if (Input.GetKeyDown(KeyCode.M)){
                letter = 12;
            }
            else if (Input.GetKeyDown(KeyCode.N)){
                letter = 13;
            }
            else if (Input.GetKeyDown(KeyCode.O)){
                letter = 14; 
            }
            else if (Input.GetKeyDown(KeyCode.P)){
                letter = 15;
            }
            else if (Input.GetKeyDown(KeyCode.Q)){
                letter = 16;
            }
            else if (Input.GetKeyDown(KeyCode.R)){
                letter = 17;
            }
            else if (Input.GetKeyDown(KeyCode.S)){
                letter = 18;
            }
            else if (Input.GetKeyDown(KeyCode.T)){
                letter = 19;
            }
            else if (Input.GetKeyDown(KeyCode.U)){
                letter = 20;
            }
            else if (Input.GetKeyDown(KeyCode.V)){
                letter = 21;
            }
            else if (Input.GetKeyDown(KeyCode.W)){
                letter = 22;
            }
            else if (Input.GetKeyDown(KeyCode.X)){
                letter = 23;
            }
            else if (Input.GetKeyDown(KeyCode.Y)){
                letter = 24;
            }
            else if (Input.GetKeyDown(KeyCode.Z)){
                letter = 25;
            }
            else if (Input.GetKeyDown(KeyCode.Space)){
            letter = -1;
                Singleton.curr.originalString += " ";
                Singleton.curr.encodedString += " ";
            }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            //SceneManager.LoadScene(SampleScene);
            /*Singleton.key.augment = 0;
            decoding = !decoding;
            Singleton.originalString = Singleton.encodedString;
            Singleton.encodedString = "";*/
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //popup explaining it would not worked historically
            Singleton.curr.encodedString = Singleton.curr.encodedString.Remove(Singleton.curr.encodedString.Length-1);
            Singleton.curr.originalString = Singleton.curr.originalString.Remove(Singleton.curr.originalString.Length-1);
            Singleton.curr.key.augment--;
            //go to popup
        }
        if (letter != -1)
        {
            if (decoding)
            {
                c = decode(letter);
                Singleton.curr.originalString += c;
                message.text = "\n\tEncoded message: \n\t" + Singleton.curr.encodedString + "\n\t decoded as: \n\t" + Singleton.curr.originalString;
            }
            else
            {
                c = encode(letter);
                Singleton.curr.originalString += numToChar(letter);
                Singleton.curr.encodedString += c;
                message.text = "\n\tYour message: \n\t" + Singleton.curr.originalString + "\n\t encoded as: \n\t" + Singleton.curr.encodedString;
            }
            
        }
    }
    public static char encode(int letter)
    {
        if (letter != -1)
        {
            letter = Singleton.curr.key.plugboard[letter];
            letter = Singleton.curr.key.rotor1[(letter + Singleton.curr.key.augment) % 26];
            if (Singleton.curr.key.augment % 26 == 0 && Singleton.curr.key.augment / 26 != 0)
            {
                letter = Singleton.curr.key.rotor2[(letter + Singleton.curr.key.augment / 26 * 2 - 1) % 26];
            }
            else
            {
                letter = Singleton.curr.key.rotor2[(letter + Singleton.curr.key.augment / 26 * 2) % 26];
            }
            if (Singleton.curr.key.augment % 26 == 0 && Singleton.curr.key.augment / 26 != 0)
            {
                letter = Singleton.curr.key.rotor3[(letter + Singleton.curr.key.augment / 26 - 1) % 26];
            }
            else
            {
                letter = Singleton.curr.key.rotor3[(letter + Singleton.curr.key.augment / 26) % 26];
            }
            letter = Singleton.reflector[letter];
            if (Singleton.curr.key.augment % 26 == 0 && Singleton.curr.key.augment / 26 != 0)
            {
                letter = inverseRotor(Singleton.curr.key.rotor3, letter) - (Singleton.curr.key.augment / 26 - 1) % 26;
            }
            else
            {
                letter = inverseRotor(Singleton.curr.key.rotor3, letter) - (Singleton.curr.key.augment / 26) % 26;
            }
            if (letter < 0)
            {
                letter = letter + 26;
            }
            if (Singleton.curr.key.augment % 26 == 0 && Singleton.curr.key.augment / 26 != 0)
            {
                letter = inverseRotor(Singleton.curr.key.rotor2, letter) - (Singleton.curr.key.augment / 26 * 2 - 1) % 26;
            }
            else
            {
                letter = inverseRotor(Singleton.curr.key.rotor2, letter) - (Singleton.curr.key.augment / 26 * 2) % 26;
            }
            if (letter < 0)
            {
                letter = letter + 26;
            }
            letter = inverseRotor(Singleton.curr.key.rotor1, letter) - (Singleton.curr.key.augment % 26);
            if (letter < 0)
            {
                letter = letter + 26;
            }
            letter = Singleton.curr.key.plugboard[letter];
        }
        char c = numToChar(letter);
        Singleton.curr.key.augment++;
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
            letter = Singleton.curr.key.plugboard[letter];
            letter = Singleton.curr.key.rotor1[(letter + Singleton.curr.key.augment) % 26];
            if (Singleton.curr.key.augment % 26 == 0 && Singleton.curr.key.augment / 26 != 0)
            {
                letter = Singleton.curr.key.rotor2[(letter + Singleton.curr.key.augment / 26 * 2 - 1) % 26];
            }
            else
            {
                letter = Singleton.curr.key.rotor2[(letter + Singleton.curr.key.augment / 26 * 2) % 26];
            }
            if (Singleton.curr.key.augment % 26 == 0 && Singleton.curr.key.augment / 26 != 0)
            {
                letter = Singleton.curr.key.rotor3[(letter + Singleton.curr.key.augment / 26 - 1) % 26];
            }
            else
            {
                letter = Singleton.curr.key.rotor3[(letter + Singleton.curr.key.augment / 26) % 26];
            }
            letter = inverseRotor(Singleton.reflector, letter);
            if (Singleton.curr.key.augment % 26 == 0 && Singleton.curr.key.augment / 26 != 0)
            {
                letter = inverseRotor(Singleton.curr.key.rotor3, letter) - (Singleton.curr.key.augment / 26 - 1) % 26;
            }
            else
            {
                letter = inverseRotor(Singleton.curr.key.rotor3, letter) - (Singleton.curr.key.augment / 26) % 26;
            }
            if (letter < 0)
            {
                letter = letter + 26;
            }
            if (Singleton.curr.key.augment % 26 == 0 && Singleton.curr.key.augment / 26 != 0)
            {
                letter = inverseRotor(Singleton.curr.key.rotor2, letter) - (Singleton.curr.key.augment / 26 * 2 - 1) % 26;
            }
            else
            {
                letter = inverseRotor(Singleton.curr.key.rotor2, letter) - (Singleton.curr.key.augment / 26 * 2) % 26;
            }
            if (letter < 0)
            {
                letter = letter + 26;
            }
            letter = inverseRotor(Singleton.curr.key.rotor1, letter) - (Singleton.curr.key.augment % 26);
            if (letter < 0)
            {
                letter = letter + 26;
            }
            letter = Singleton.curr.key.plugboard[letter];
        }
        char c = numToChar(letter);
        Singleton.curr.key.augment++;
        return c;
    }
}
