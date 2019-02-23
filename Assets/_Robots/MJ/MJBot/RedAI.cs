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

    private void FixedUpdate() {
        if (targetPoint != null) {
            targetSphere.transform.position = targetPoint;
            myUtilities.moveToTarget(targetPoint, rb, this.transform, targetSphere );
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") { hitPlayer = true; }

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
   //     rb.AddForce(Vector3.up * physicsForce * 10);
    }

    public void boost () {
        if( boostAllowed ) {
    //        rb.AddForce(transform.forward * physicsForce * boostFactor);
        }
    }

    public void interceptBall () {
        Vector3 targetVec = myUtilities.findInterceptPoint(ball.transform, opponentGoal.transform, this.transform);
        myUtilities.moveToTarget(targetVec, rb, this.transform, targetSphere);
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

/* Utilities class for AI */
/* Static methods for keeping AI class a little cleaner */
public static class myUtilities  {

    public static void moveToTarget( Vector3 targetPoint, Rigidbody rb, Transform currentTransform, GameObject targetIndicator ) {
        // put targetSphere at target point
        targetIndicator.transform.position = targetPoint;

        // find vector from player to target point
        Vector3 lookVector = targetPoint - currentTransform.position;

                rb.AddForce(currentTransform.forward * 0.0001f);

        // stop if you reach the target point
        if (lookVector.magnitude < 1.0f) {
            rb.velocity = Vector3.zero;
        }
    }

    public static void aimAtTarget( Vector3 targetPoint, Rigidbody rb, Transform currentTransform ) {
        // find vector from player to target point
        Vector3 lookVector = targetPoint - currentTransform.position;

        // quickly rotate to face the target
   //     currentTransform.rotation = Quaternion.LookRotation(lookVector);

    }

    public static Vector3 findInterceptPoint( Transform target, Transform targetDest, Transform currentPos ) {
        // find a point halfway between the target's current position, and where it's heading
        return (targetDest.position - target.position)* 0.5f;
    }

}
