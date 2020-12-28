using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuFM2D : MonoBehaviour
{

    [MenuItem("FM2D/Player")]
    public static void CreatePlayer() {

        GameObject player = Instantiate(Resources.Load("PlayerFM2Dv1") as GameObject);
        player.name = "Player";

    }

}

