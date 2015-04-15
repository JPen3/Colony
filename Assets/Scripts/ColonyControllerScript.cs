using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColonyControllerScript : MonoBehaviour {

    public int ColonistCount = 20;
    public int ColResourceAway = 0;
    public int ColSupplyAway = 0; 
    public int ColonistsAvailable = 15;
    public int ColDeathCount = 0; 
    public int ColSickCount = 5; 
    public int ColResCount;
    public int ColMatCount;

    public int GardenerCount;

    public GameObject TotalColsTxt;
    public GameObject ColsAwayTxt;
    public GameObject ColsHereTxt;
    public GameObject ColDeathTxt; 
    public GameObject ColsSickTxt;
    public GameObject ColInfermDeathTxt; 
    
    // Use this for initialization
	void Start () {
        //ColonistCount = 20; //5 is the base amount of colonists you start with
        //ColonistsAvailable = 15;
        //ColSickCount = 5; //for testing only
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void UpdateQuartersStats()
    {
        print("Colony stats updated"); 
        TotalColsTxt.GetComponent<Text>().text = "Total Colonists: " + ColonistCount;
        ColsAwayTxt.GetComponent<Text>().text = "Colonists Away: " + ColResourceAway + "(Material) " + ColSupplyAway + "(Supplies)"; 
        ColsHereTxt.GetComponent<Text>().text = "Colonists Here: " + ColonistsAvailable;
        ColDeathTxt.GetComponent<Text>().text = "Colony Losses: " + ColDeathCount;
        ColsSickTxt.GetComponent<Text>().text = "Colonists Sick: " + ColSickCount;
        ColInfermDeathTxt.GetComponent<Text>().text = "Colony Losses: " + ColDeathCount;

    }

}
