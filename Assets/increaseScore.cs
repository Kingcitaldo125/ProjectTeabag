using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class increaseScore : MonoBehaviour {
    public int score = 0;
    public GameObject scoreBoard;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        scoreBoard.GetComponent<Text>().text = "Score:" + score;
	}

    void oneUp()
    {
        score += 50;
    }
}
