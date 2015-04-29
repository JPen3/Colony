using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class WindowControllerScript : MonoBehaviour {

    public GameObject[] Windows;
    public GameObject[] Alarms; 
    public static bool updateWindows = false;
    public static bool updateAlarms = false; 
    public static bool isBoarded = false;
    public static bool isAlarmed = false; 
    public static bool canUpgradeWindow = false;
    public static bool canUpgradeDoors = false; 

    // Use this for initialization
	void Start () {
        Windows = GameObject.FindGameObjectsWithTag("windowObj");
        TurnOffBoardedWindow();
        Alarms = GameObject.FindGameObjectsWithTag("NoisAlarmObj");
        TurnOffAlarmedDoors(); 
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

        if(updateAlarms)
        {
            updateAlarms = false; 
            if(isAlarmed)
            {
                TurnOnAlarmedDoors(); 
            }
            else
            {
                TurnOffAlarmedDoors(); 
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

    public void TurnOffAlarmedDoors()
    {
        for (int i = 0; i< Alarms.Length; i++)
        {
            Alarms[i].transform.FindChild("noiseAlarm").gameObject.SetActive(false); 
        }
    }

    public void TurnOnAlarmedDoors()
    {
        for (int i = 0; i < Alarms.Length; i++)
        {
            Alarms[i].transform.FindChild("noiseAlarm").gameObject.SetActive(true);
        }
    }
}
