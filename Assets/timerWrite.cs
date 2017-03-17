using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timerWrite : MonoBehaviour {
    float startTime;
    string textTime;
    float guiTime;
    float minutes;
    float seconds;
    public GameObject textfield;
    bool hasFinished = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (hasFinished != true)
        {
            guiTime += Time.deltaTime;
        }
        //The gui-Time is the difference between the actual time and the start time.
        minutes = (int) (guiTime / 60); //Divide the guiTime by sixty to get the minutes.
        seconds = guiTime % 60.0f;//Use the euclidean division for the seconds.

        textTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        //text.Time is the time that will be displayed.
        //textField.text = textTime;
        textfield.GetComponent<Text>().text = "Timer:" + textTime;
    }

    void finished()
    {
        hasFinished = true;
    }
}
