using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private float boostTimer;
    private float boostCoolDown = 3.0f;
    protected float boostFactor = 3.0f;

    [SerializeField] public GameObject opponent;
    [SerializeField] public GameObject ball;

    [SerializeField] protected float physicsForce = 1000.0f;

    protected virtual void Start() {
        boostTimer = Time.time;
    }

    protected virtual void Update() {

    }

    protected bool boostAllowed {
        get {
            if( boostTimer + boostCoolDown > Time.time ) {
                boostTimer = Time.time;
                return true;
            }
            return false;
        }
    }


    

}
