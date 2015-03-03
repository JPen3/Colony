using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class GatheringControllerScript : MonoBehaviour {

    public int GathererNum = 0;
    public GameObject ColonyController;
    public GameObject GatherNumTxt;
    public GameObject Inventory; 
    
    // Use this for initialization
	void Start () {
	    if(GameObject.Find("Inventory"))
        {
            Inventory = GameObject.Find("Inventory"); 
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SendOutGatherers()
    {
        if(ColonyController != null)
        {
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAway += GathererNum;
            ColonyController.GetComponent<ColonyControllerScript>().ColResCount += GathererNum;

            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= GathererNum;
            GathererNum = 0;
            DisplayGatherNum();
        }
    }

    public void ReturnGather()
    {
        int stack01 = Random.Range(0,11);
        int stack02 = Random.Range(0, 11);
        int stack03 = Random.Range(0, 11);
        for(int i = 0; i<3; i++)
        {
            Inventory.GetComponent<Inventory>().AddItem(Random.Range(0, 9));
            /*for(int j = 0; i<Random.Range(1,11); j++)
            {
                Inventory.GetComponent<Inventory>().AddItem(Random.Range(0, 9));
            }*/
        }
    }

    public void DisplayGatherNum()
    {
        GatherNumTxt.GetComponent<Text>().text = GathererNum.ToString();
    }
}
