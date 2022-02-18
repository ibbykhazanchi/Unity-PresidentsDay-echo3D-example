using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textChanger : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshPro tmp;
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changePres(string name)
    {
        Debug.Log("trying to change");
        tmp.SetText(name);
    }

    public void removePres()
    {
        tmp.SetText("");
    }
}
