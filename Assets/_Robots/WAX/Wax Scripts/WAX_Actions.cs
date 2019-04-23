using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;


public class WaxMoveToOpponent : Action
{
    public WAX_newAIBot thisPlayer;
    private Rigidbody rb;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate()
    {

        WAX_Utilities.moveToTarget(thisPlayer.opponent.transform.position, rb, thisPlayer.transform, thisPlayer.targetSphere, thisPlayer.physicsForce);
        return TaskStatus.Success;
    }
}

public class WaxMoveToBall : Action
{
    public WAX_newAIBot thisPlayer;
    private Rigidbody rb;


    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate()
    {
        WAX_Utilities.moveToTarget(thisPlayer.ball.transform.position, rb, thisPlayer.transform, thisPlayer.targetSphere, thisPlayer.physicsForce);
        return TaskStatus.Success;
    }
}

public class WaxMoveToDefGoal : Action
{
    public WAX_newAIBot thisPlayer;
    private Rigidbody rb;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate()
    {
        WAX_Utilities.moveToTarget(thisPlayer.myGoal.transform.position, rb, thisPlayer.transform, thisPlayer.targetSphere, thisPlayer.physicsForce);
        {
            float myLoc = WAX_Utilities.targetCheck(thisPlayer.transform.position, thisPlayer.myGoal.transform.position);
            float ballLoc = WAX_Utilities.targetCheck(thisPlayer.ball.transform.position, thisPlayer.myGoal.transform.position);

            return myLoc < ballLoc ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}

public class WaxMoveToScoringGoal : Action
{
    public WAX_newAIBot thisPlayer;
    private Rigidbody rb;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate()
    {
        WAX_Utilities.moveToTarget(thisPlayer.opponentGoal.transform.position, rb, thisPlayer.transform, thisPlayer.targetSphere, thisPlayer.physicsForce);
            
            //this is going to be to keep the player from running across goal line
            float myLoc = WAX_Utilities.targetCheck(thisPlayer.transform.position, thisPlayer.myGoal.transform.position);
            float ballLoc = WAX_Utilities.targetCheck(thisPlayer.ball.transform.position, thisPlayer.myGoal.transform.position);
            //float scoreLoc = WAX_Utilities.targetCheck(thisPlayer.opponentGoal.transform.position, thisPlayer.myGoal.transform.position);

            return myLoc < ballLoc && ballLoc > +3 ? TaskStatus.Success : TaskStatus.Failure;
    
    }
}

public class WAX_KickBall : Action
{
    public WAX_newAIBot thisPlayer;
    private Rigidbody rb;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate()
    {
        Vector3 playerPos = thisPlayer.transform.position;
        Vector3 defenseGoal = thisPlayer.myGoal.transform.position;
        Vector3 ballPos = thisPlayer.ball.transform.position;


        Vector3 ballToGoal = ballPos - thisPlayer.opponentGoal.transform.position;
        ballToGoal.Normalize();

        Vector3 goalTarget = ballPos - ballToGoal * 3f;
        WAX_Utilities.moveToTarget(goalTarget, rb, thisPlayer.transform, thisPlayer.targetSphere, thisPlayer.physicsForce);

        if (WAX_Utilities.targetCheck(playerPos, defenseGoal) > .95
            || WAX_Utilities.targetCheck(playerPos, defenseGoal) > WAX_Utilities.targetCheck(ballPos, defenseGoal))
        {
            //Trying to get this to stop
            //thisPlayer.transform.rotation = Quaternion.Euler(0, thisPlayer.transform.eulerAngles.y, 0);
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }
}


//work in progress when opponenet goal is in range on the z access then spin 360 degrees to shoot (maybe also check for opponenet in the way)
public class WAX_SpinMove : Action
{
    public WAX_newAIBot thisPlayer;
    private Rigidbody rb;
    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public override TaskStatus OnUpdate()
    {
        Vector3 rotation = new Vector3(0, 0, 360);
        thisPlayer.transform.Rotate(rotation);
        return TaskStatus.Success;
    }
}



//public class WaxGoalCheck : Action
//{
//    public WAX_newAIBot thisPlayer;

//    public override void OnAwake()
//    {
//        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
//    }
//    public override TaskStatus OnUpdate()
//    {
//        float myLoc = WAX_Utilities.targetCheck(thisPlayer.transform.position, thisPlayer.myGoal.transform.position);
//        float ScoreLoc = WAX_Utilities.targetCheck(thisPlayer.opponentGoal.transform.position, thisPlayer.myGoal.transform.position);

//        return myLoc < ScoreLoc ? TaskStatus.Success : TaskStatus.Failure;
//    }
//}




//public class CheckOpponent : Conditional
//{

//}



