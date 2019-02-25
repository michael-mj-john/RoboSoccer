using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class mj_MoveToOpponent : Action
{
    public mj_newAIBot thisPlayer;
    private Rigidbody rb;

    public override void OnAwake()
    {
        thisPlayer = gameObject.GetComponent<mj_newAIBot>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override TaskStatus OnUpdate()
    {
        Vector3 opponentPosition = thisPlayer.opponent.transform.position;
        Vector3 myPosition = transform.position;
        Vector3 lookVector =  opponentPosition - myPosition;

        transform.rotation = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        rb.AddForce(transform.forward * thisPlayer.physicsForce);

        return TaskStatus.Success;

    }


}
