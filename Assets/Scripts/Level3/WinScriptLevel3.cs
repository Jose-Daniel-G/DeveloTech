using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScriptLevel3 : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject myObjects;

    void Start()
    {
        pointsToWin = myObjects.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoints >= pointsToWin)
        {
            //WIN
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddPoints()
    {
        currentPoints++;
    }
}
