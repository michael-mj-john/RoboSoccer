using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class MovetoIntercept : Action
{
    public RedAI thisPlayer;

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<RedAI>();
    }

    public override TaskStatus OnUpdate() {
        Vector3 target = myUtilities.findInterceptPoint(thisPlayer.ball.transform, thisPlayer.myGoal.transform, thisPlayer.transform);
        if ( Vector3.Magnitude(thisPlayer.transform.position - target) < 0.1 ) {
            return TaskStatus.Success;
        }
        myUtilities.moveToTarget(target, thisPlayer.rb, thisPlayer.transform);
        return TaskStatus.Running;


    }

}
