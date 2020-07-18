using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class KitMovement : MonoBehaviour
{

    [HideInInspector] public Rigidbody2D myRb;
    [HideInInspector] public SpriteRenderer mySr;
    public List<Collider2D> colliders;

    public void Awake() {

        myRb = this.gameObject.GetComponent<Rigidbody2D>();
        mySr = this.gameObject.GetComponent<SpriteRenderer>();
        colliders.Add(this.gameObject.GetComponent<BoxCollider2D>());

    }

    public Collider2D AddComponent() {

        return this.gameObject.GetComponent<BoxCollider2D>();

    }

}
