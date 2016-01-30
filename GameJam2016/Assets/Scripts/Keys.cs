using UnityEngine;
using System.Collections;

public class Keys  {

    public static string TAG_PLAYER = "Player";
    public static string TAG_FLOOR = "Floor";
    public static string TAG_ROCK = "Rock";


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
