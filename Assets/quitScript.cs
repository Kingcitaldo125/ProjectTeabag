using UnityEngine;
using System.Collections;

public class quitScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("User-Initiated Application Exit");
            Application.Quit();

            //Only allow the unity editor to read and use this code
           #if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying == true)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
           #endif
        }
    }
}
