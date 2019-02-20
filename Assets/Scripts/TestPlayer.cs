using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{

    public new Camera camera;
    private float yLock;
    public GameObject moveTarget;
    private Rigidbody rb;

    public float physicsForce = 10;
    public float rotateSpeed = 10;

    void Start() {
        yLock = this.transform.position.y;
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {


    }

    private void FixedUpdate() {

        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100)) {
            moveTarget.transform.position = new Vector3(hit.point.x, yLock, hit.point.z);
        }
        Vector3 targetVector = moveTarget.transform.position - transform.position;

        float step = rotateSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetVector, step, 0.0f);

       transform.rotation = Quaternion.LookRotation(newDirection);
       rb.AddForce(transform.forward * physicsForce );
       
        if(targetVector.magnitude < 1.0f) {
            rb.velocity = Vector3.zero;
        }

    }
}
