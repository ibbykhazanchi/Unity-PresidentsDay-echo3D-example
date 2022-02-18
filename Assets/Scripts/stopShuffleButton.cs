using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stopShuffleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(stopShuffle);

        Debug.Log(gameObject.transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void stopShuffle()
    {
        GameObject.Find("AssetsParent").GetComponent<TestScript>().shuffleClicked = false;
        GameObject.Find("AssetsParent").GetComponent<TestScript>().shuffleStopped = true;
    }
}
