using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{
    public static string[] preloadedMessages = new string[]{ 
        "world war two",
        "hello my name is inigo montoya you killed my father prepare to die",
        "alan turing",
        "originally built by the dutch",
        "plugboard rotors reflector and keyboard",
        "alrighty then",
        "you sit on a throne of lies",
        "Hello world",
        "wibbly wobbly timey wimey stuff",
        "the lord looks on the heart",
        "space the final frontier",
        "on your left",
        "once upon a december"};

    public static int decodeIndex = 1;
    public static int[] reflector = { 5, 21, 9, 0, 22, 7, 8, 1, 15, 23, 11, 2, 4, 3, 6, 20, 25, 10, 24, 16, 19, 12, 17, 13, 18, 14 };
    public static Message curr = new Message();
 


}
