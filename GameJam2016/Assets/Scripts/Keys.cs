﻿using UnityEngine;
using System.Collections;

public class Keys  {

    public static string TAG_PLAYER = "Player";
    public static string TAG_FLOOR = "Floor";

    public static bool IsPlayer(GameObject other) {
        return other.CompareTag(TAG_PLAYER);
    }

}
