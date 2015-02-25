using UnityEngine;
using System.Collections;

public class RoomUIScript : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject ColonyController;
    public GameObject GatheringController; 
    public GameObject ResourcesPanel; 
    public GameObject ResourcesSendPanel;
    public GameObject ResourcesSendCountTxt; 
    public GameObject MaterialSendPanel;
    public GameObject MaterialSendCountTxt;
    public GameObject MainPanel;
    public GameObject DayPanel; 

    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackToTop()//sends camera to lerp back to it's top view
    {
        MainCamera.GetComponent<CameraLerpScript>().back2Top();
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = MainPanel; 
        MainPanel.SetActive(true);
    }

    public void SelectResources()//brings up the resources panel
    {
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel.SetActive(false);
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = ResourcesSendPanel;
        ResourcesSendPanel.SetActive(true);

    }

    public void Back2ResourcesPanel()//returns to the resources panel from either material or resources gathering pages
    {
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel.SetActive(false);
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = ResourcesPanel;
        ResourcesPanel.SetActive(true);
    }

    public void DayProgress()//will progress the game by one day
    {
        DayPanel.GetComponent<DayPropScript>().DayInt++; 
        //lines after this point will restore the colonists you sent out for now, will go elsewhere at a later date
        ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += ColonyController.GetComponent<ColonyControllerScript>().ColonistsAway;
        ColonyController.GetComponent<ColonyControllerScript>().ColonistsAway = 0; 
    }

    public void AddGatheringNum()//adds 1 to the number of gatherer you are sending out
    {
        if (GatheringController.GetComponent<GatheringControllerScript>().GathererNum < ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable)
        {
            GatheringController.GetComponent<GatheringControllerScript>().GathererNum++;
        }
        GatheringController.GetComponent<GatheringControllerScript>().DisplayGatherNum();
    }

    public void SubGatheringNum()
    {
        if(GatheringController.GetComponent<GatheringControllerScript>().GathererNum > 0)
        {
            GatheringController.GetComponent<GatheringControllerScript>().GathererNum--;
        }
        GatheringController.GetComponent<GatheringControllerScript>().DisplayGatherNum();
    }

    public void SendResourceGathering()
    {
        GatheringController.GetComponent<GatheringControllerScript>().SendOutGatherers(); 
    }
}
