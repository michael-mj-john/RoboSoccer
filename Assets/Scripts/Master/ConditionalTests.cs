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

public class OnTheGround : Conditional {

    public bd_ai thisPlayer;

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<bd_ai>();
    }

    public override TaskStatus OnUpdate() {
        return thisPlayer.isGrounded() ? TaskStatus.Success : TaskStatus.Failure;
    }
    
}

