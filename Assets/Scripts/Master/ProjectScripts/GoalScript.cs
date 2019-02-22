using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    [SerializeField] public GameManager.Team team = new GameManager.Team();
    
    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Ball" ) {
            GameManager.instance.goalScored(team);
        }

    }
         
}
