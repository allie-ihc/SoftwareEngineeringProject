using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnkryptionKeyClass 
{
    public int[] plugboard;
    public int[] rotor1;
    public int[] rotor2;
    public int[] rotor3;
    public int augment;

    public EnkryptionKeyClass()
    {
        this.augment = 0;
    }
    public void generateKey(int numPlugs)
    {
        this.rotor1 = generateRotor();
        this.rotor2 = generateRotor();
        this.rotor3 = generateRotor();
        this.plugboard = this.generatePlugs(numPlugs);
    }

    public int[] generateRotor()
    {
        int[] rotor = new int[26];
        for (int i = 0; i < 26; i++)
        {
            rotor[i] = i;
        }
        for (int i = 0; i < 52; i++)
        {//ensures each number shows up exactly once in a random order
            int r1 = Random.Range(0,26);
            int r2 = Random.Range(0, 26);
            int temp = rotor[r1];
            rotor[r1] = rotor[r2];
            rotor[r2] = temp;
        }
        return rotor;
    }

    public int[] generatePlugs(int num)
    {
        int[] rand = generateRotor();
        int[] plugboard = new int[26];
        for (int i = 0; i < 26; i++)
        {
            plugboard[i] = i;
        }
        for (int i = 0; i < num * 2; i += 2)
        {
            int p1 = rand[i];
            int p2 = rand[i + 1];
            int temp = plugboard[p1];
            plugboard[p1] = plugboard[p2];
            plugboard[p2] = temp;
        }
        return plugboard;
    }
}
