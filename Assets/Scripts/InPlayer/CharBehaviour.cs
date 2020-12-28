using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))][RequireComponent(typeof(Collider2D)), RequireComponent(typeof(SpriteRenderer))]
[HelpURL("https://github.com/Cauehcs?tab=repositories")][DisallowMultipleComponent][ExecuteInEditMode][RequireComponent(typeof(Kit))]
public class CharBehaviour : MonoBehaviour
{

    public Kit kit;
    public KitMovement kitMovement;
    public KitAttack kitAttack;
    public KitStatus kitStatus;

    public bool movement, attack, status;

    public int referenceKits;

    private void Update() {

        ReferenceKits();

    }

    void ReferenceKits() {

            if (kitMovement == null && movement) kitMovement = this.gameObject.GetComponent<KitMovement>();
            if (kitAttack == null && attack) kitAttack = this.gameObject.GetComponent<KitAttack>();
            if (kitStatus == null && status) kitStatus = this.gameObject.GetComponent<KitStatus>();

            if(kit == null) {

                kit = this.gameObject.AddComponent<Kit>();

            }

    }

}
