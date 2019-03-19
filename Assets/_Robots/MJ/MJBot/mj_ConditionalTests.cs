using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class OnDefense : Conditional
{
    public bd_ai thisPlayer; 

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<bd_ai>();
    }

    public override TaskStatus OnUpdate() {
        if (thisPlayer.ball.transform.position.x < 0) {
            Debug.Log("Ball on defensive side");
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}

public class BehindBall: Conditional {

    public bd_ai thisPlayer;

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<bd_ai>();
    }

    public override TaskStatus OnUpdate() {
        return transform.position.x < thisPlayer.ball.transform.position.x ? TaskStatus.Success : TaskStatus.Failure;
    }
}

public class BoostAllowed: Conditional {

    public PlayerBase thisPlayer;

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<bd_ai>();
    }

    public override TaskStatus OnUpdate() {
        return thisPlayer.tryBoost ? TaskStatus.Success : TaskStatus.Failure;
    }

}

public class OnTheGround : Conditional {

    public bd_ai thisPlayer;

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<bd_ai>();
    }

    public override TaskStatus OnUpdate() {
        return thisPlayer.isGrounded() ? TaskStatus.Success : TaskStatus.Failure;
    }
    
}
 
public class CloseToBall : Conditional
{
    public bd_ai thisPlayer;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<bd_ai>();
    }

    public override TaskStatus OnUpdate()
    {
        return Vector3.Magnitude(thisPlayer.transform.position - thisPlayer.ball.transform.position) < 4.0f ? TaskStatus.Success : TaskStatus.Failure;
    }

}

public class mj_AlignedToBall : Conditional
{
    public bd_ai thisPlayer;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<bd_ai>();
    }

 // incomplete. ignore

}


