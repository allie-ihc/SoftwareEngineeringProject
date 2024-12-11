using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{
    public static string[] preloadedMessages = new string[]{
        "famously used in world war two",
        "hello my name is inigo montoya you killed my father prepare to die",
        "alan turing cracked the enigma machine",
        "jesus wept",
        "originally built by the dutch",
        "you sit on a throne of lies",
        "plugboard rotors reflector and keyboard",
        "alrighty then",
        "encryption through circuit",
        "hello world",
        "plugboard swaps letters at the beginning and end of circuit",
        "wibbly wobbly timey wimey stuff",
        "three rotors scramble letters",
        "the lord looks on the heart",
        "rotor stepping allows for further encryption",
        "space the final frontier",
        "after the left rotor makes a full rotation the next rotor makes a step",
        "on your left",
        "double stepping is a quirk of the enigma machine",
        "once upon a december",
        "reflector is a stationary rotor that sends the electricity back through the rotors ",
        "the room where it happens",
        "the number of plugs effects the encryption",
        "tower of babbel",
        "keys complete the circuit",
        "welcome to the internet",
        "plugboard to rotor to reflector back through rotors and plug board",
        "caesar cipher",
        "originally light showed encoded letter",
        "always"};


    public static int decodeIndex = 0;
    public static int[] reflector = { 5, 21, 9, 0, 22, 7, 8, 1, 15, 23, 11, 2, 4, 3, 6, 20, 25, 10, 24, 16, 19, 12, 17, 13, 18, 14 };
    public static Message curr = new Message();
 


}
