using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{

public float life, speed, forJump;

private static Singleton instance;


private void Awake() {
    
    instance = this;

}

public static Singleton GetInstance(){

    return instance;

}

}
