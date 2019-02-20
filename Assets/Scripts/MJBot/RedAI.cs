using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAI : PlayerBase
{

    public  GameObject targetSphere;
    private  Vector3 targetPoint;

    public  GameObject ball;
    public  GameObject myGoal;
    public  GameObject opponentGoal;
    public  GameObject opponent;
    private Vector3 vecToBall, vecToOpponent;
    private float rotateSpeed = 100;
    private Rigidbody rb;
    private bool hitPlayer = false;

    private void Start() {
        rb = this.GetComponent<Rigidbody>();
        targetSphere.transform.position = new Vector3(0, 0, 0);
    }

    public bool isNearBall {
        get {
            return vecToBall.magnitude < 2.0f;
        }
    }

    public bool ballNearMyGoal {
        get {
            float distToGoal = Vector3.Magnitude(ball.transform.position - myGoal.transform.position);
            Debug.Log("Checking ball near goal");
            return distToGoal < 5.0f;  
        }
    }

    private void Update() {
        vecToBall = this.transform.position - ball.transform.position;
        vecToOpponent = this.transform.position - opponent.transform.position;
    }


    public void jumpUp() {
        Debug.Log("Jump");
        rb.AddForce(Vector3.up * physicsForce * 10);
    }

    public bool hitsPlayer {
        get {
            if( hitPlayer ) { hitPlayer = false; return true; }
            return false;
        }
    }

    public void moveToOpponent() {
        targetPoint = opponent.transform.position;
 //       if ( vecToOpponent.magnitude < 3.0f) { boost(); }
    }

    public void moveToMyGoal() {
        targetPoint = myGoal.transform.position;
        Debug.Log("moving toward goal");
    }


    private void moveTo(Vector3 target) {

    }

    private void boost () {
        if( boostAllowed ) {
            rb.AddForce(transform.forward * physicsForce * boostFactor);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") { hitPlayer = true;  }
    }

    private void FixedUpdate() {

        if ( targetPoint != null ) {
            targetSphere.transform.position = targetPoint;

            Vector3 lookVector = targetPoint - transform.position;

            transform.rotation = Quaternion.LookRotation(lookVector);
            rb.AddForce(transform.forward * physicsForce);

            if (lookVector.magnitude < 1.0f) {
                rb.velocity = Vector3.zero;
            }

        }
    }


}
