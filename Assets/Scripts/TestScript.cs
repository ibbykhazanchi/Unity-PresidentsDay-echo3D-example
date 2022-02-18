using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestScript : MonoBehaviour
{

    GameObject lincoln;
    GameObject jfk;
    GameObject washington;
    GameObject roosevelt;
    GameObject eisenhower;
    GameObject chosenPres;
    List<GameObject> presidents;
    bool presidentsFound;
    public bool shuffleClicked;
    public bool shuffleStopped;
    bool slowMove;

    float moveSpeed = 15f;
    Vector3 newPos = new Vector3(40, 0, 0);
    Vector3 shuffleVertex = new Vector3(0, 0, 0);
    Vector3 oldPos = new Vector3(-40, 0, 0);
    float step;

    IEnumerator coroutine;
    Vector3 presidentmoveTowards;

    // Start is called before the first frame update
    void Start()
    {
        step = moveSpeed * Time.deltaTime;
        coroutine = shuffle();
        presidents = new List<GameObject>();
        presidentmoveTowards = newPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!presidentsFound)
        {

            GameObject bg = GameObject.Find("wh.jpeg");
            if (bg != null)
            {
                bg.transform.rotation *= Quaternion.Euler(85, 180, 0);
                bg.transform.position = new Vector3(0, 30, 50);

                Image image = bg.GetComponent<Image>();
                if (image != null)
                {
                    var tempColor = image.color;
                    tempColor.a = 0f;
                    image.color = tempColor;
                }
            }


            findAndInitializePres(
                "Theodore Roosevelt.jpeg",
                "Theodore Roosevelt",
                0
            );
            findAndInitializePres(
                "JFK.jpeg",
                "John F Kennedy",
                -15
            );
            findAndInitializePres(
                "GeorgeWashington.jpeg",
                "George Washington",
                15
            );
            findAndInitializePres(
                "lincoln.jpeg",
                "Abraham Lincoln",
                30
            );
            findAndInitializePres(
                "eisenhower.jpeg",
                "Dwight D. Eisenhower",
                -30
            );

            if (presidents.Count == 5)
            {
                presidentsFound = true;
            }
        }
        if (presidentsFound && shuffleClicked)
        {
            GameObject.Find("funFact").GetComponent<funFact>().removeFF();
            GameObject.Find("selectedPres").GetComponent<textChanger>().removePres();

            StartCoroutine(shuffle());
        }

        if (shuffleStopped)
        {
            StopCoroutine(shuffle());
            chosenPres = randomPresident();
            slowMove = true;
            shuffleStopped = false;
        }
        if (slowMove)
        {
            moveUntilInVertex(chosenPres);
            if (!slowMove)
            {
                GameObject.Find("selectedPres").GetComponent<textChanger>().changePres(chosenPres.name);
                GameObject.Find("funFact").GetComponent<funFact>().changeFF(chosenPres.name);
            }
        }
    }

    private void findAndInitializePres(string file, string name, int x)
    {
        GameObject pres = GameObject.Find(file);
        if (pres != null)
        {
            pres.name = name;
            pres.transform.rotation *= Quaternion.Euler(90, 180, 0);
            pres.transform.localScale = new Vector3(1, 4, 1);
            pres.transform.position = new Vector3(x, 5, 0);
            presidents.Add(pres);
        }
    }

    IEnumerator shuffle()
    {

        foreach (GameObject child in presidents)
        {
            newPos.y = child.transform.position.y;
            oldPos.y = child.transform.position.y;

            child.transform.position = Vector3.MoveTowards(child.transform.position, newPos, step);

            if (Vector3.Distance(child.transform.position, newPos) == 0)
            {
                child.transform.position = oldPos;
            }
        }
        yield return null;
    }

    GameObject randomPresident()
    {
        var rand = new System.Random();
        int index = rand.Next(0, presidents.Count - 1);
        return presidents[index];
    }

    void moveUntilInVertex(GameObject president)
    {

        foreach (GameObject child in presidents)
        {
            newPos.y = child.transform.position.y;
            oldPos.y = child.transform.position.y;
            shuffleVertex.y = child.transform.position.y;
            presidentmoveTowards.y = child.transform.position.y;

            if (child.name != president.name)
            {
                child.transform.position = Vector3.MoveTowards(child.transform.position, newPos, step);
                if (Vector3.Distance(child.transform.position, newPos) == 0)
                {
                    child.transform.position = oldPos;
                }
            }
            else
            {
                child.transform.position = Vector3.MoveTowards(child.transform.position, presidentmoveTowards, step);
                if (Vector3.Distance(child.transform.position, newPos) == 0)
                {
                    child.transform.position = oldPos;
                    presidentmoveTowards = shuffleVertex;
                }
                if (Vector3.Distance(child.transform.position, shuffleVertex) == 0)
                {
                    slowMove = false;
                    presidentmoveTowards = newPos;
                    return;
                }
            }

        }
    }
}
