using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class MovetoIntercept : Action
{
    public bd_ai thisPlayer;
    private Rigidbody rb;

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<bd_ai>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate() {
        Vector3 target = myUtilities.findInterceptPoint(thisPlayer.ball.transform, thisPlayer.myGoal.transform, thisPlayer.transform);
        if ( Vector3.Magnitude(thisPlayer.transform.position - target) < 0.1 ) {
            return TaskStatus.Success;
        }
        Quaternion rotation = Quaternion.LookRotation(target - thisPlayer.transform.position, Vector3.up);
        thisPlayer.transform.rotation = rotation;
   //         myUtilities.aimAtTarget(target, rb, transform);
        myUtilities.moveToTarget(target, rb, transform, thisPlayer.targetSphere);
        return TaskStatus.Success;

    }

}

public class Jump : Action {

    public Rigidbody rb;

    public override void OnAwake() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate() {
 //       rb.AddForce(Vector3.up * 300);

        return TaskStatus.Success;

    }
}
