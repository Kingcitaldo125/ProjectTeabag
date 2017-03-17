using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class wrtScript : MonoBehaviour
{
    //private string path;
    private string text;
    private string[] textElements;
    [SerializeField] string path = @"C:\Users\Paul\Desktop\";
    [SerializeField] string fileName = "Leaderboard.txt";

    private ArrayList ar;
    private ArrayList person;

    // Use this for initialization
    void Start()
    {
        ar = new ArrayList();
        person = new ArrayList();

        person.Add("Paul 0");
        ar.Add(person);
        person.Clear();

        person.Add("James 0");
        ar.Add(person);
        person.Clear();

        person.Add("Dan 0");
        ar.Add(person);
        person.Clear();

        person.Add("Tim 0");
        ar.Add(person);
        person.Clear();

        person.Add("Adam 0");
        ar.Add(person);
        person.Clear();

        person.Add("Matt 0");
        ar.Add(person);
        person.Clear();

        person.Add("Jacob 0");
        ar.Add(person);
        person.Clear();

        person.Add("John 0");
        ar.Add(person);
        person.Clear();

        person.Add("Jason 0");
        ar.Add(person);
        person.Clear();
    }

    void readFileAsArray()
    {
        string filePath = path + fileName;
        textElements = System.IO.File.ReadAllLines(filePath);

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
        string tex = path + fileName;
        string text = System.IO.File.ReadAllText(tex);
        // Display the file contents to the console. Variable text is a string.
        System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
    }

    bool isKeyPressed()
    {
        //Press Enter to 'send' scores
        if (Input.GetKey(KeyCode.Return))
        {
            writeStrings();
            System.Console.WriteLine("Wrote to file");
            return true;
        }
        else
        {
            return false;
        }
    }

    void writeStrings()
    {
        //string text = "FOO BAR BAZ BASH";
        foreach(string s in ar)
            System.IO.File.WriteAllText(path, s);
    }

    // Update is called once per frame
    void Update()
    {
        isKeyPressed();
    }
}
