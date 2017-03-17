using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class leaderboardScript : MonoBehaviour
{

    private ILeaderboard leaderboard;
    // Use this for initialization
    void Start()
    {
        DoLeaderboard();
    }

    void DoLeaderboard()
    {
        leaderboard = Social.CreateLeaderboard();
        leaderboard.id = "Leaderboard012";
        leaderboard.LoadScores(result => DidLoadLeaderboard(result));
    }

    void DidLoadLeaderboard(bool result)
    {
        Debug.Log("Received " + leaderboard.scores.Length + " scores");
        foreach (IScore score in leaderboard.scores)
        { 
            Debug.Log(score);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}