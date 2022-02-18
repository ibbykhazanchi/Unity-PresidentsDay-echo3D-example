using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class funFact : MonoBehaviour
{
    TextMeshPro tmp;
    public Dictionary<string, string> dict;
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
        dict = new Dictionary<string, string>();
        dict.Add("John F Kennedy", "The youngest elected president in US history");
        dict.Add("Theodore Roosevelt", "Was awarded the prestigious Nobel Peace Prize");
        dict.Add("George Washington", "No one will ever outrank him in the US Military");
        dict.Add("Abraham Lincoln", "The tallest president ever, standing at 6'4");
        dict.Add("Dwight D. Eisenhower", "Was once president of Columbia University");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeFF(string name)
    {
        Debug.Log("trying to change");
        tmp.SetText(dict[name]);
    }

    public void removeFF()
    {
        tmp.SetText("");
    }
}
