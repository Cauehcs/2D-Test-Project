using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))][RequireComponent(typeof(Collider2D)), RequireComponent(typeof(SpriteRenderer))]
[HelpURL("https://github.com/Cauehcs?tab=repositories")][DisallowMultipleComponent]
public class CharBehaviour : MonoBehaviour
{

    public Kit kit;
    public KitMovement kitMovement;
    public KitAttack kitAttack;

    public bool movement, attack;

    public int referenceKits;

    private void Awake() {

        kit = this.gameObject.AddComponent<Kit>();

    }

    private void Update() {

        ReferenceKits();

    }

    void ReferenceKits() {
        referenceKits++;

        if(referenceKits == 1) {

            kitMovement = this.gameObject.GetComponent<KitMovement>();
            kitAttack = this.gameObject.GetComponent<KitAttack>();

        }

    }

}
