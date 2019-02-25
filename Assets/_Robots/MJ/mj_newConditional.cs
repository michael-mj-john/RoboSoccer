using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class mj_onDefense : Conditional
{
    public mj_newAIBot thisPlayer;

    public override void OnAwake() {
        thisPlayer = gameObject.GetComponent<mj_newAIBot>();
    }

    public override TaskStatus OnUpdate()
    {
        if(thisPlayer.ball.transform.position.x < 0 )
        {
            Debug.Log("Ball is on defensive side");
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }




}
