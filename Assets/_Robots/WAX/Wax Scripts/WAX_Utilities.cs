using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;

public static class WAX_Utilities
{ 
    public static void moveToTarget(Vector3 targetPoint, Rigidbody rb, Transform currentTransform, GameObject targetIndicator, float force)
    {
        // put targetSphere at target point
        targetIndicator.transform.position = targetPoint;

        // find vector from player to target point
        Vector3 lookVector = targetPoint - currentTransform.position;
        currentTransform.rotation = Quaternion.LookRotation(lookVector);
        currentTransform.rotation = Quaternion.Euler(0, currentTransform.eulerAngles.y, 0);
        rb.AddForce(currentTransform.forward * force);

        // stop if you reach the target point
        if (lookVector.magnitude < 1.0f)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public static float targetCheck(Vector3 targetOfInterest, Vector3 waxGoal)
    {
        //find relative position on the gameboard 0-1 of any object (consider your goal as 0 opponent goal is 1), run multiple times on different objects for comparisons
       
       float interestLoc = Vector3.Magnitude (targetOfInterest - waxGoal) / 50f;
        return interestLoc;

    }
    //unsure how to use this
    //public static Vector3 findAimedPoint(Vector3 ballPosition, Vector3 goalPosition)
    //{
    //    Vector3 ballToGoal = ballPosition - goalPosition;
    //    ballToGoal.Normalize();
    //    Vector3 target = ballPosition + ballToGoal * 3.5f;
    //    return target;
    //}



}




