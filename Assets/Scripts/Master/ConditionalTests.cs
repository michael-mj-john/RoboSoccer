using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class OnDefense : Conditional
{
    public RedAI thisPlayer; 

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<RedAI>();
    }

    public override TaskStatus OnUpdate() {
        if (thisPlayer.ball.transform.position.x < 0) {
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }


}
