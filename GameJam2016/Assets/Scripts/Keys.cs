using UnityEngine;
using System.Collections;

public class Keys  {

    public static string TAG_PLAYER = "Player";
    public static string TAG_FLOOR = "Floor";
    public static string TAG_ROCK = "Rock";



    //******* OGGETTI CHE APPARTENGONO A UNO STATO
    public static string TAG_STATE_FIRST = "First";
    public static string TAG_STATE_SECOND = "Second";
    public static string TAG_STATE_THIRD = "Third";
    public static string TAG_STATE_FOURTH = "Fourth";


    public static bool IsPlayer(GameObject other) {
        return other.CompareTag(TAG_PLAYER);
    }

    public static bool IsFloor(GameObject other) {
        return other.CompareTag(TAG_FLOOR);
    }

    public static bool IsRock(GameObject other) {
        return other.CompareTag(TAG_ROCK);
    }   
}
