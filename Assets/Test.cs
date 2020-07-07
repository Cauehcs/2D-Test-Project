using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

private void Update() {
    
    float a = Singleton.GetInstance().speed;
    Debug.Log(a);
            
}

}
