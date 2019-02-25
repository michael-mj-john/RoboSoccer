using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private float maxSpeed = 10.0f;

    private float boostTimer;
    private float boostCoolDown = 3.0f;
    [HideInInspector] public float boostFactor = 3.0f;
    protected new Collider collider;
    public float distToGround;
    protected Rigidbody rb;
    private Vector3 startPosition;

    [SerializeField] public GameObject opponent;
    [SerializeField] public GameObject ball;
    [SerializeField] public GameObject myGoal;
    [SerializeField] public GameObject opponentGoal;

    [SerializeField] public float physicsForce = 1000.0f;

    protected virtual void Awake() {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    protected virtual void Start() {
        boostTimer = Time.time;
        distToGround = collider.bounds.extents.y;
        
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            this.transform.position = startPosition;
        }
    }

    protected virtual void FixedUpdate() {
        // speed clamp code
        if ( rb.velocity.magnitude > maxSpeed ) {
            rb.velocity = rb.velocity.normalized * maxSpeed; 
        }

    }

    public bool boostAllowed {
        get {
            if( boostTimer + boostCoolDown > Time.time ) {
                boostTimer = Time.time;
                return true;
            }
            return false;
        }
    }

    public bool isGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + .3f);
    }

}
