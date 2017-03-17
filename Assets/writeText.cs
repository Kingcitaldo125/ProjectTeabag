using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class writeTextFile : MonoBehaviour
{
    //private string path;
    private string text;
    private string[] textElements;
    [SerializeField]
    string path = "C:\\Users\\Paul\\Desktop\\";
    [SerializeField]
    string fileName = "Leaderboard.txt";

    // Use this for initialization
    void Start()
    {
        //readFileAsString();
    }

    void readFileAsArray()
    {
        string filePath = path + fileName;
        textElements = System.IO.File.ReadAllLines(@"C:\\Users\\Paul\\Desktop\\Leaderboard.txt");

        // Display the file contents by using a foreach loop.
        System.Console.WriteLine("Contents of WriteLines2.txt = ");
        foreach (string line in textElements)
        {
            // Use a tab to indent each line of the file.
            System.Console.WriteLine("\t" + line);
        }
    }

    void readFileAsString()
    {
        string filePath = path + fileName;
        string text = System.IO.File.ReadAllText(@"C:\\Users\\Paul\\Desktop\\Leaderboard.txt");

        // Display the file contents to the console. Variable text is a string.
        System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
    }

    bool isKeyPressed()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            System.Console.WriteLine("Wrote to file");
            writeStrings();
            return true;
        }
        else
        {
            return false;
        }
    }

    void writeStrings()
    {
        string text = "FOO BAR BAZ BASH";
        System.IO.File.WriteAllText(@"C:\Users\Paul\Desktop", text);
    }

    void writeArrayStrings()
    {

    }

    void writeMultiple()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool bar = isKeyPressed();
    }
}
