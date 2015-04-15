using UnityEngine;
using System.Collections;

public class RoomUIScript : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject ColonyController;
    public GameObject GatheringController;
    public GameObject ConsumptionController; 
    public GameObject ResourcesPanel; 
    public GameObject ResourcesSendPanel;
    public GameObject ResourcesSendCountTxt; 
    public GameObject MaterialSendPanel;
    public GameObject MaterialSendCountTxt;
    public GameObject MainPanel;
    public GameObject ExitCheckPanel;
    public GameObject NotePanel; 
    public GameObject WeekPanel;
    public GameObject EventController; 

	private Inventory inventory;

    
    // Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
        MainPanel.SetActive(true); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckExit()
    {
        ExitCheckPanel.SetActive(true); 
        MainPanel.SetActive(false); 
        MainCamera.GetComponent<CameraLerpScript>().hasSelected = true; 
    }

    public void ExitCheckNo()
    {
        ExitCheckPanel.SetActive(false);
        MainPanel.SetActive(true); 
        MainCamera.GetComponent<CameraLerpScript>().hasSelected = false; 
    }

    public void BackToTop()//sends camera to lerp back to it's top view
    {
        MainCamera.GetComponent<CameraLerpScript>().back2Top();
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = MainPanel; 
        MainPanel.SetActive(true);

		inventory.SetShowInventory(false);
		inventory.SetShowCraft(false);
    }

    public void NoteClose()
    {
        NotePanel.SetActive(false);
        UserNoteScript.UserNote = null; 
        BackToTop(); 
    }

    public void SelectResources()//brings up the resources panel
    {
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel.SetActive(false);
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = ResourcesSendPanel;
        ResourcesSendPanel.SetActive(true);

    }

    public void SelectSupply()//brings up the resources panel
    {
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel.SetActive(false);
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = MaterialSendPanel;
        MaterialSendPanel.SetActive(true);

    }

    public void Back2ResourcesPanel()//returns to the resources panel from either material or resources gathering pages
    {
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel.SetActive(false);
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = ResourcesPanel;
        ResourcesPanel.SetActive(true);
    }

    public void DayProgress()//will progress the game by one day
    {
        WeekPanel.GetComponent<DayPropScript>().DayInt++;
        ConsumptionController.GetComponent<ConsumptionScript>().ConsumptionUpdate(); 

        if (ColonyController.GetComponent<ColonyControllerScript>().ColSupplyAway > 0)
        {
            print("Supply Party: ");
            EventController.GetComponent<ColonyEventScript>().GatheringEvent(ColonyController.GetComponent<ColonyControllerScript>().ColSupplyAway, "Supply");
        }
        if (ColonyController.GetComponent<ColonyControllerScript>().ColResourceAway > 0)
        {
            print("Material Gathering: ");
            EventController.GetComponent<ColonyEventScript>().GatheringEvent(ColonyController.GetComponent<ColonyControllerScript>().ColResourceAway, "Mat");
        }

        
        
        //lines after this point will restore the colonists you sent out for now, will go elsewhere at a later date
        
        EventController.GetComponent<ColonyEventScript>().ColonyEvent(ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable);
        EventController.GetComponent<ColonyEventScript>().SickEvent(ColonyController.GetComponent<ColonyControllerScript>().ColSickCount);
        ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += ColonyController.GetComponent<ColonyControllerScript>().ColSupplyAway;
        ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += ColonyController.GetComponent<ColonyControllerScript>().ColResourceAway;
        ColonyController.GetComponent<ColonyControllerScript>().ColonistCount = ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable + ColonyController.GetComponent<ColonyControllerScript>().ColSickCount;
        MainPanel.SetActive(false);
        UserNoteScript.updateNote = true;
        NotePanel.SetActive(true); 
        ColonyController.GetComponent<ColonyControllerScript>().ColSupplyAway = 0;
        ColonyController.GetComponent<ColonyControllerScript>().ColResourceAway = 0;
        GatheringController.GetComponent<GatheringControllerScript>().ReturnGather();
        GatheringController.GetComponent<GatheringControllerScript>().ReturnSupplyParty();  
        

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

    public void AddSupplyPartyNum()//adds 1 to the number to Supply party you are sending out
    {
        if (GatheringController.GetComponent<GatheringControllerScript>().SupplyGatherNum < ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable)
        {
            GatheringController.GetComponent<GatheringControllerScript>().SupplyGatherNum++;
        }
        GatheringController.GetComponent<GatheringControllerScript>().DisplaySupplyPartyNum();
    }

    public void SubSupplyNum()
    {
        if (GatheringController.GetComponent<GatheringControllerScript>().SupplyGatherNum > 0)
        {
            GatheringController.GetComponent<GatheringControllerScript>().SupplyGatherNum--;
        }
        GatheringController.GetComponent<GatheringControllerScript>().DisplaySupplyPartyNum();
    }

    public void SendSupplyParty()
    {
        GatheringController.GetComponent<GatheringControllerScript>().SendOutSupplyParty();
    }

    public void Back2Menu()
    {
        Application.LoadLevel("StartScreen"); 
    }

    public void AddGardener()
    {
        if (ColonyController.GetComponent<ColonyControllerScript>().GardenerCount < ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable)
        {
            ColonyController.GetComponent<ColonyControllerScript>().GardenerCount++; 
        }
        ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt(); 
    }

    public void MinusGardener()
    {
        if (ColonyController.GetComponent<ColonyControllerScript>().GardenerCount > 0)
        {
            ColonyController.GetComponent<ColonyControllerScript>().GardenerCount--;
        }
        ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt(); 
    }
}
