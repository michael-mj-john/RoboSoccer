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
        Vector3 target = mj_Utilities.findInterceptPoint(thisPlayer.ball.transform, thisPlayer.myGoal.transform);
        if (Vector3.Magnitude(thisPlayer.transform.position - target) < 1.0f) {
            return TaskStatus.Success;
        }

        mj_Utilities.moveToTarget(target, rb, transform, thisPlayer.targetSphere, thisPlayer.physicsForce);
        return TaskStatus.Running;
    }
}

public class RunToBall: Action {
    public bd_ai thisPlayer;
    private Rigidbody rb;
    [SerializeField] private GameObject ball;

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<bd_ai>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate() {
        Vector3 target = thisPlayer.ball.transform.position;
        if (Vector3.Magnitude(thisPlayer.transform.position - target) < 0.1) {
            return TaskStatus.Failure;
        }
        mj_Utilities.moveToTarget(target, rb, transform, thisPlayer.targetSphere, thisPlayer.physicsForce);

        return TaskStatus.Success;

    }
}

public class BoostToBall : Action {
    public bd_ai thisPlayer;
    private Rigidbody rb;

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<bd_ai>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate() {
        Vector3 target = thisPlayer.ball.transform.position;
        if (Vector3.Magnitude(thisPlayer.transform.position - target) < 0.1) {
            return TaskStatus.Failure;
        }
        mj_Utilities.moveToTarget(target, rb, transform, thisPlayer.targetSphere, thisPlayer.physicsForce * thisPlayer.boostFactor );
        return TaskStatus.Success;
    }

}

public class RunBehindBall : Action {
    public bd_ai thisPlayer;
    private Rigidbody rb;

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<bd_ai>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate() {
        // find the desired point
        Vector3 ballToGoal = thisPlayer.ball.transform.position - thisPlayer.opponentGoal.transform.position;
        ballToGoal.Normalize();
        Vector3 target = thisPlayer.ball.transform.position + ballToGoal * 3.5f; ;
        if (Vector3.Magnitude(thisPlayer.transform.position - target) < 0.1) {
            return TaskStatus.Failure;
        }

        // move to point
        mj_Utilities.moveToTarget(target, rb, transform, thisPlayer.targetSphere, thisPlayer.physicsForce);
        return TaskStatus.Success;

    }


}

public class Jump : Action {

    public Rigidbody rb;

    public override void OnAwake() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate() {
        rb.AddForce(Vector3.up * 300);

        return TaskStatus.Success;

    }
}
