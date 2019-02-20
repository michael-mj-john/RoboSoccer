using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private new Camera camera;
    private Vector3 startPosition;
    private Rigidbody rb;

    private void Start() {
        startPosition = this.transform.position;
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // debug feature to move ball around with the mouse:

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100)) {
                this.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }

        if ( this.transform.position.y < -10 ) {
            this.transform.position = startPosition;
        }
    }
}
