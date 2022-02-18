using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class shuffleButton : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(shuffle);

        Debug.Log(gameObject.transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void shuffle()
    {
        Debug.Log("pressed");
        GameObject.Find("AssetsParent").GetComponent<TestScript>().shuffleStopped = false;
        GameObject.Find("AssetsParent").GetComponent<TestScript>().shuffleClicked = true;
    }

}
