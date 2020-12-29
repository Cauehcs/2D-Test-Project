using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class KitMovement : MonoBehaviour
{
    [HideInInspector] public Kit kit;
    [HideInInspector] public Rigidbody2D myRb;
    [HideInInspector] public SpriteRenderer mySr;
    public Collider2D walkCollider, CrouchCollider;

    //Controls Movement
    public KeyCode KCrun, KCcrouch, KCjump;
    public string KCHorizontal;

    public enum AxisRaw { On, Off };
    public AxisRaw enumWalkAxisRaw, enumRunAxisRaw, enumCrouchAxisRaw;

    public LayerMask groundLayer;

    public bool canMovement, canRun, canJump, canCrouch, WalkAxisRaw, runAxisRaw, crouchAxisRaw, movementInAir, bigJump, wallJump, doubleJump, soar, inGround;
    public float speed, runMultiplier, crouchMultiplier;
    [Range(-1, 1)] public float horizontalAxis;

    public void Awake() {

        myRb = this.gameObject.GetComponent<Rigidbody2D>();
        mySr = this.gameObject.GetComponent<SpriteRenderer>();
        kit = this.gameObject.GetComponent<Kit>();

    }

    private void Update() {

        WalkRunAndCrouch();
        Jump();

    }

    public void WalkRunAndCrouch() {

        if (canMovement) {

            horizontalAxis = WalkAxisRaw ? Input.GetAxisRaw(KCHorizontal) : Input.GetAxis(KCHorizontal);
            myRb.velocity = new Vector2(speed * horizontalAxis, myRb.velocity.y);

        }
            else horizontalAxis = 0f;

        if (canRun && Input.GetKey(KCrun)) {

            horizontalAxis = runAxisRaw ? Input.GetAxisRaw(KCHorizontal) : Input.GetAxis(KCHorizontal);
            myRb.velocity = new Vector2(speed * horizontalAxis * runMultiplier, myRb.velocity.y);

        }
            else if(canCrouch && Input.GetKey(KCcrouch)) {

                horizontalAxis = crouchAxisRaw ? Input.GetAxisRaw(KCHorizontal) : Input.GetAxis(KCHorizontal);
                myRb.velocity = new Vector2(speed * horizontalAxis * crouchMultiplier, myRb.velocity.y);

            }

    }

    public void Jump() {

        inGround = Physics2D.OverlapCircle(new Vector2(walkCollider.bounds.center.x, walkCollider.bounds.min.y), .2f, groundLayer);

    }

}
