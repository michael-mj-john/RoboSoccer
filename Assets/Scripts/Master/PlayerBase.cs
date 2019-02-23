using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private float boostTimer;
    private float boostCoolDown = 3.0f;
    protected float boostFactor = 3.0f;
    protected new Collider collider;
    public float distToGround;

    [SerializeField] public GameObject opponent;
    [SerializeField] public GameObject ball;
    [SerializeField] public GameObject myGoal;
    [SerializeField] public GameObject opponentGoal;

    [SerializeField] protected float physicsForce = 1000.0f;

    protected virtual void Awake() {
        collider = GetComponent<Collider>();
    }

    protected virtual void Start() {
        boostTimer = Time.time;
        distToGround = collider.bounds.extents.y;
    }

    protected virtual void Update() {

    }

    protected bool boostAllowed {
        get {
            if( boostTimer + boostCoolDown > Time.time ) {
                boostTimer = Time.time;
                return true;
            }
            return false;
        }
    }

    public bool isGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 2.6f);
    }


    

}
