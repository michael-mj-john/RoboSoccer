using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAI : MonoBehaviour
{

    public new GameObject ball;
    public new GameObject myGoal;
    public new GameObject opponentGoal;
    public new GameObject opponent;
    private Vector3 vecToBall, vecToOpponent;
    private float rotateSpeed = 100; private float physicsForce = 100;
    private Rigidbody rb;

    private void Start() {
        rb = this.GetComponent<Rigidbody>();
    }

    public bool isNearBall {
        get {
            return vecToBall.magnitude < 2.0f;
        }
    }

    public bool ballNearMyGoal {
        get {
            float distToGoal = Vector3.Magnitude(ball.transform.position - myGoal.transform.position);
            return distToGoal < 2.0f;  
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

    public void moveToOpponent() {
        moveTo(opponent.transform.position);
    }

    public void moveToMyGoal() {
        Vector3 targetVector = myGoal.transform.position;

        moveTo(targetVector);


    }


    private void moveTo(Vector3 target) {

        float step = rotateSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, target, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
        rb.AddForce(transform.forward * physicsForce);

        if (target.magnitude < 1.0f) {
            rb.velocity = Vector3.zero;
        }
    }



}
