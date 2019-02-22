using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum Team { red, blue };
    public Dictionary<Team, int> gameScore = new Dictionary<Team, int>();
    private Dictionary<Team, string> teamNames = new Dictionary<Team, string>();

    public static GameManager instance;

    void Start()
    {
        instance = this; // partial singleton implementation

        teamNames[Team.red] = "Red";
        teamNames[Team.blue] = "Blue";
        gameScore[Team.red] = gameScore[Team.blue] = 0;
    }

    public void goalScored( Team teamName ) {
        gameScore[teamName]++;
        showScore();
    }

    public void showScore() {
        Debug.Log("Current score: Red " + gameScore[Team.red] + ", Blue " + gameScore[Team.blue]);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            showScore();
        }
    }
}
