using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class WindowControllerScript : MonoBehaviour {

    public GameObject[] Windows;

    public static bool updateWindows = false;

    public static bool isBoarded = false;

    public static bool canUpgradeWindow = false; 

    // Use this for initialization
	void Start () {
        Windows = GameObject.FindGameObjectsWithTag("windowObj");
        TurnOffBoardedWindow(); 
	}
	
	// Update is called once per frame
	void Update () {
	    if(updateWindows)
        {
            updateWindows = false; 
            if(isBoarded)
            {
                TurnOnBoardedWindow(); 
            }
            else
            {
                TurnOffBoardedWindow(); 
            }
        }

        
	}

    public void TurnOffBoardedWindow()
    {
        for (int i = 0; i < Windows.Length; i++)
        {
            Windows[i].transform.FindChild("boardedWindow").gameObject.SetActive(false);
        }
    }

    public void TurnOnBoardedWindow()
    {
        for (int i = 0; i < Windows.Length; i++)
        {
            Windows[i].transform.FindChild("boardedWindow").gameObject.SetActive(true);
        }
    }
}
