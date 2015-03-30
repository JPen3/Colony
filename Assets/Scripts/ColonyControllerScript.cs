using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColonyControllerScript : MonoBehaviour {

    public int ColonistCount = 15;
    public int ColResourceAway = 0;
    public int ColSupplyAway = 0; 
    public int ColonistsAvailable = 15;
    public int ColResCount;
    public int ColMatCount; 
    public GameObject TotalColsTxt;
    public GameObject ColsAwayTxt;
    public GameObject ColsHereTxt; 
    
    // Use this for initialization
	void Start () {
        ColonistCount = 15; //5 is the base amount of colonists you start with
        ColonistsAvailable = 15; 
	}
	
	// Update is called once per frame
	void Update () {
        UpdateQuartersStats();
	}

    public void UpdateQuartersStats()
    {
        TotalColsTxt.GetComponent<Text>().text = "Total Colonists: " + ColonistCount;
        ColsAwayTxt.GetComponent<Text>().text = "Colonists Away: " + ColResourceAway + "(Material) " + ColSupplyAway + "(Supplies)"; 
        ColsHereTxt.GetComponent<Text>().text = "Colonists Here: " + ColonistsAvailable; 
    }
}
