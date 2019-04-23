//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using BehaviorDesigner.Runtime.Tasks;

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