using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAI : PlayerBase
{
    public  GameObject targetSphere;
    private  Vector3 targetPoint;

    public  GameObject myGoal;
    public  GameObject opponentGoal;

    private float rotateSpeed = 100;
    public Rigidbody rb;
    protected bool hitPlayer = false;
    protected Vector3 vecToBall, vecToOpponent;

    /* The usual Unity built-in methods here */
    protected override void Start() {
        rb = this.GetComponent<Rigidbody>();
        targetSphere.transform.position = new Vector3(0, 0, 0);
    }

    protected override void Update() {
        vecToBall = this.transform.position - ball.transform.position;
        vecToOpponent = this.transform.position - opponent.transform.position;
    }


    /* ACTIONS */
    /* Action methods for B3 */
    public void moveToOpponent() {
        targetPoint = opponent.transform.position;
    }

    public void moveToMyGoal() {
        targetPoint = myGoal.transform.position;
    }

    public void jumpUp() {
        rb.AddForce(Vector3.up * physicsForce * 10);
    }

    public void boost () {
        if( boostAllowed ) {
            rb.AddForce(transform.forward * physicsForce * boostFactor);
        }
    }

 


    /* TESTS */
    /* These are the boolean tests returned to the B3 tree tool */
    public bool isNearBall {
        get {
            return vecToBall.magnitude < 2.0f;
        }
    }

    public bool ballNearMyGoal {
        get {
            float distToGoal = Vector3.Magnitude(ball.transform.position - myGoal.transform.position);
            return distToGoal < 5.0f;
        }
    }

    public bool hitsPlayer {
        get {
            if (hitPlayer) { hitPlayer = false; return true; }
            return false;
        }
    }

    public bool onDefense {
        get {
            return ball.transform.position.x < 0;
        }
    }
}

