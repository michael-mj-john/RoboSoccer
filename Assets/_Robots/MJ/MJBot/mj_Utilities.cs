using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Utilities class for AI */
/* Static methods for keeping AI class a little cleaner */
public static class mj_Utilities {

    public static void moveToTarget(Vector3 targetPoint, Rigidbody rb, Transform currentTransform, GameObject targetIndicator, float force) {
        // put targetSphere at target point
        targetIndicator.transform.position = targetPoint;

        // find vector from player to target point
        Vector3 lookVector = targetPoint - currentTransform.position;

        currentTransform.rotation = Quaternion.LookRotation(targetPoint - currentTransform.position, Vector3.up);
        currentTransform.rotation = Quaternion.Euler(0, currentTransform.eulerAngles.y, 0);

        rb.AddForce(currentTransform.forward * force);

        // stop if you reach the target point
        if (lookVector.magnitude < 1.0f) {
            rb.velocity = Vector3.zero;
        }
    }

    public static Vector3 findInterceptPoint(Transform target, Transform targetDest) {
        // find a point halfway between the target's current position, and where it's heading
        return (targetDest.position + target.position) * 0.5f;
    }

    //public static Vector3 findReversePoint(Transform target, Transform targetDest ) {

    //}

}

