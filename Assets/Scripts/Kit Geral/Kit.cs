using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent][ExecuteInEditMode]
public class Kit : MonoBehaviour
{

    public KitMovement kitMovement;
    [HideInInspector] public KitAttack kitAtack;
    [HideInInspector] public KitStatus kitStatus;

    [HideInInspector] public bool hasMovement, hasAtack, hasStatus;
    [HideInInspector] public enum ViewGame { SideView, TopView }
    [HideInInspector] public ViewGame viewGame;

    private void Update()
    {

        hasMovement = this.gameObject.GetComponent<CharBehaviour>().movement;
        hasAtack = this.gameObject.GetComponent<CharBehaviour>().attack;
        hasStatus = this.gameObject.GetComponent<CharBehaviour>().status;

        if (hasAtack && this.GetComponent<KitAttack>() == null) {

            this.gameObject.AddComponent<KitAttack>();
            kitAtack = this.gameObject.GetComponent<KitAttack>();

        }
            else if(!hasAtack) {

                DestroyImmediate(this.gameObject.GetComponent<KitAttack>());

        }

        if (hasMovement && this.GetComponent<KitMovement>() == null)
        {

            this.gameObject.AddComponent<KitMovement>();
            kitMovement = this.gameObject.GetComponent<KitMovement>();

        }
            else if(!hasMovement) {

                DestroyImmediate(this.gameObject.GetComponent<KitMovement>());

            }

        if (hasStatus && this.GetComponent<KitStatus>() == null) 
        {

            this.gameObject.AddComponent<KitStatus>();
            kitStatus = this.gameObject.GetComponent<KitStatus>();

        }
            else if(!hasStatus) {

                DestroyImmediate(this.gameObject.GetComponent<KitStatus>());

            }

    }

}
