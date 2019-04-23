using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;



public class WAX_on_Defense : Conditional
{
    public WAX_newAIBot thisPlayer;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
    }
    public override TaskStatus OnUpdate()
    {
        return WAX_Utilities.targetCheck(thisPlayer.ball.transform.position, thisPlayer.myGoal.transform.position) < 0.5f ? TaskStatus.Success : TaskStatus.Failure;
    }
}

public class WaxBehindBall : Conditional
{
    public WAX_newAIBot thisPlayer;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
    }
    public override TaskStatus OnUpdate()
    {
        float ballSize = 4.8f / 50f;
        float myLoc = WAX_Utilities.targetCheck(thisPlayer.transform.position, thisPlayer.myGoal.transform.position);
        float ballLoc = WAX_Utilities.targetCheck(thisPlayer.ball.transform.position, thisPlayer.myGoal.transform.position);

        return myLoc < ballLoc+ballSize ? TaskStatus.Success : TaskStatus.Failure;
    }
}


//check to see if you are closer to the ball than opponent 
public class OpponentNearBall : Conditional
{
    public WAX_newAIBot thisPlayer;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
    }
    public override TaskStatus OnUpdate()
    {
        float myLoc = WAX_Utilities.targetCheck(thisPlayer.transform.position, thisPlayer.myGoal.transform.position);
        float ballLoc = WAX_Utilities.targetCheck(thisPlayer.ball.transform.position, thisPlayer.myGoal.transform.position);
        float opponentLoc = WAX_Utilities.targetCheck(thisPlayer.opponent.transform.position, thisPlayer.myGoal.transform.position);

        return myLoc - opponentLoc > myLoc - ballLoc  ? TaskStatus.Success : TaskStatus.Failure;
    }
}

public class WaxNearBall : Conditional
{
    public WAX_newAIBot thisPlayer;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
    }
    public override TaskStatus OnUpdate()
    {
        Vector3 playerPos = thisPlayer.transform.position;
        Vector3 ballPos = thisPlayer.ball.transform.position;

       return Vector3.Magnitude(playerPos - ballPos) >= 3 ? TaskStatus.Success : TaskStatus.Failure;
    }

}



//public class WaxGoalCheck : Conditional
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


//public class WaxDistToBall : Conditional
//{
//    public WAX_newAIBot thisPlayer;

//    public override void OnAwake()
//    {
//        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
//    }

//    public override TaskStatus OnUpdate()
//    {
//        return Vector3.Magnitude(thisPlayer.transform.position - thisPlayer.ball.transform.position) < 4.0f ? TaskStatus.Success : TaskStatus.Failure;
//    }

//}

//public class WaxBehindBall : Conditional
//{

//    public WAX_newAIBot thisPlayer;

//public override void OnAwake()
//    {
//        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
//    }

//    public override TaskStatus OnUpdate()
//    {
//        return transform.position.x < thisPlayer.ball.transform.position.x ? TaskStatus.Success : TaskStatus.Failure;
//    }
//}

//public class WaxBoostAllowed : Conditional
//{

//    public PlayerBase thisPlayer;

//    public override void OnAwake()
//    {
//        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
//    }

//    public override TaskStatus OnUpdate()
//    {
//        return thisPlayer.boostAllowed ? TaskStatus.Success : TaskStatus.Failure;
//    }

//}



//public class HighDanger : Conditional
//{
//    public WAX_newAIBot thisPlayer;

//    public override void OnAwake()
//    {
//        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
//    }
//    public override TaskStatus OnUpdate()
//    {
//        return WAX_Utilities.DangerCheck(thisPlayer.ball.transform.position, thisPlayer.myGoal.transform.position) < 0.2f ? TaskStatus.Success : TaskStatus.Failure;
//    }
//}

//public class LookForShot : Conditional
//{
//    public WAX_newAIBot thisPlayer;

//    public override void OnAwake()
//    {
//        thisPlayer = gameObject.GetComponent<WAX_newAIBot>();
//    }
//    public override TaskStatus OnUpdate()
//    {
//        return WAX_Utilities.DangerCheck(thisPlayer.ball.transform.position, thisPlayer.myGoal.transform.position) > 0.8f ? TaskStatus.Success : TaskStatus.Failure;
//    }
//}



//public class WAX_on_Defense : Conditional
//{
//    public GameObject ball;
//    public override TaskStatus OnUpdate()
//    {
//        if (ball.transform.position.x < 0)
//        {
//            Debug.Log("Ball is on defensive side");
//            return TaskStatus.Success;
//        }
//        return TaskStatus.Failure;
//    }
//}


//public class HighDanger : Conditional
//{
//public GameObject ball;
//public GameObject waxGoal;
//public override TaskStatus OnUpdate()
//{
//    return 
//}






//}
