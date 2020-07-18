using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Kit : MonoBehaviour
{

    [HideInInspector] public KitMovement kitMovement;
    [HideInInspector] public KitAttack kitAtack;

    [HideInInspector] public bool hasMovement, hasAtack;

    private void Awake()
    {

        hasMovement = this.gameObject.GetComponent<CharBehaviour>().movement ? true : false;
        hasAtack = this.gameObject.GetComponent<CharBehaviour>().attack ? true : false;

        if (hasAtack)
        {

            this.gameObject.AddComponent<KitAttack>();
            kitAtack = this.gameObject.GetComponent<KitAttack>();

        }

        if (hasMovement)
        {

            this.gameObject.AddComponent<KitMovement>();
            kitMovement = this.gameObject.GetComponent<KitMovement>();

        }

    }

}
