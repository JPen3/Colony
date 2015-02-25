using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class GatheringControllerScript : MonoBehaviour {

    public int GathererNum = 0;
    public GameObject ColonyController;
    public GameObject GatherNumTxt; 
    
    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SendOutGatherers()
    {
        if(ColonyController != null)
        {
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAway += GathererNum;
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= GathererNum;
            GathererNum = 0;
            DisplayGatherNum();
        }
    }

    public void ReturnGather()
    {
        //this is where we will calculate the items that were gathered and if there were any casualties
        //set up a notification system that displays when a colonist has died...
    }

    public void DisplayGatherNum()
    {
        GatherNumTxt.GetComponent<Text>().text = GathererNum.ToString();
    }
}
