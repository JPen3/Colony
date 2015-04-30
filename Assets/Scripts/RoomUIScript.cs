using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

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
    public GameObject DaQuickHelpPanel;
    public GameObject EventController;
    public GameObject UserNoteController;
    public GameObject InventoryController;

    public GameObject UpgradeOptionsPanel; 

    public static int newColCount;
    public GameObject NewColMessageTxt;  
    public GameObject NewColQPanel; 

    public GameObject GameOverPanel; 

	private Inventory inventory;

    
    // Use this for initialization
	void Start () {
		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
        MainPanel.SetActive(true);
        DaQuickHelpPanel.SetActive(true);
        MainCamera.GetComponent<CameraLerpScript>().hasSelected = true; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CloseDaQuickHelpPanel()
    {
        DaQuickHelpPanel.SetActive(false);
        MainCamera.GetComponent<CameraLerpScript>().hasSelected = false; 
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
        MainPanel.SetActive(true);
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = MainPanel; 
        

		inventory.SetShowInventory(false);
		inventory.SetShowCraft(false);
    }

    public void NoteClose()
    {
        UserNoteController.GetComponent<UserNoteScript>().WriteJournal(); 
        NotePanel.SetActive(false);
        UserNoteScript.UserNote = null;
        Invoke("BackToTop", (float)0.5);
        MainCamera.GetComponent<CameraLerpScript>().hasSelected = false; 
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
        ConsumptionController.GetComponent<ConsumptionScript>().ProduceFoodWater();//this will produce food water and firewood
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

        EventController.GetComponent<ColonyEventScript>().SickEvent(ColonyController.GetComponent<ColonyControllerScript>().ColSickCount);
        EventController.GetComponent<ColonyEventScript>().ColonyEvent(ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable);
        ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += ColonyController.GetComponent<ColonyControllerScript>().ColSupplyAway;
        ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += ColonyController.GetComponent<ColonyControllerScript>().ColResourceAway;
        ColonyController.GetComponent<ColonyControllerScript>().ColonistCount = ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable + ColonyController.GetComponent<ColonyControllerScript>().ColSickCount + ColonyController.GetComponent<ColonyControllerScript>().TotalGardCount;
        MainPanel.SetActive(false);
        UserNoteScript.updateNote = true;
        NotePanel.SetActive(true);
        MainCamera.GetComponent<CameraLerpScript>().hasSelected = true; //disables ability to click on a room
        ColonyController.GetComponent<ColonyControllerScript>().ColSupplyAway = 0;
        ColonyController.GetComponent<ColonyControllerScript>().ColResourceAway = 0;
        GatheringController.GetComponent<GatheringControllerScript>().ReturnGather();
        GatheringController.GetComponent<GatheringControllerScript>().ReturnSupplyParty();
         
        if(ColonyController.GetComponent<ColonyControllerScript>().ColonistCount <= 0)
        {
            print("Game Over");
            GameOverPanel.SetActive(true); 
        }

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
        ConsumptionController.GetComponent<ConsumptionScript>().UpdateConsumerTxt(); 
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
        ConsumptionController.GetComponent<ConsumptionScript>().UpdateConsumerTxt(); 
    }

    public void Back2Menu()
    {
        Application.LoadLevel("StartScreen"); 
    }

    public void AddGardener()
    {
        if (ColonyController.GetComponent<ColonyControllerScript>().GardenerCount < ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable + ColonyController.GetComponent<ColonyControllerScript>().GardenerCount)
        {
            ColonyController.GetComponent<ColonyControllerScript>().GardenerCount++;
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable--; 
        }
        ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt(); 
    }

    public void AddWaterGard()
    {
        if (ColonyController.GetComponent<ColonyControllerScript>().WaterGardCount < ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable + ColonyController.GetComponent<ColonyControllerScript>().WaterGardCount)
        {
            ColonyController.GetComponent<ColonyControllerScript>().WaterGardCount++;
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable--;
        }
        ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt(); 
    }

    public void AddFireGard()
    {
        if (ColonyController.GetComponent<ColonyControllerScript>().FireGardCount < ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable + ColonyController.GetComponent<ColonyControllerScript>().FireGardCount)
        {
            ColonyController.GetComponent<ColonyControllerScript>().FireGardCount++;
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable--;
        }
        ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt();
    }

    public void MinusGardener()
    {
        if (ColonyController.GetComponent<ColonyControllerScript>().GardenerCount > 0)
        {
            ColonyController.GetComponent<ColonyControllerScript>().GardenerCount--;
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable++; 
        }
        ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt(); 
    }

    public void MinusWaterGard()
    {
        if (ColonyController.GetComponent<ColonyControllerScript>().WaterGardCount > 0)
        {
            ColonyController.GetComponent<ColonyControllerScript>().WaterGardCount--;
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable++;
        }
        ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt();
    }

    public void MinusFireGard()
    {
        if (ColonyController.GetComponent<ColonyControllerScript>().FireGardCount > 0)
        {
            ColonyController.GetComponent<ColonyControllerScript>().FireGardCount--;
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable++;
        }
        ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt();
    }

    public void AddJournalWeek()
    {
        if (UserNoteController.GetComponent<UserNoteScript>().DisplayWeekInt < WeekPanel.GetComponent<DayPropScript>().DayInt-1)
        {
            UserNoteController.GetComponent<UserNoteScript>().DisplayWeekInt++;
            UserNoteController.GetComponent<UserNoteScript>().DisplayJournalEntry();
        }
    }

    public void SubJournalWeek()
    {
        if (UserNoteController.GetComponent<UserNoteScript>().DisplayWeekInt > 1)
        {
            UserNoteController.GetComponent<UserNoteScript>().DisplayWeekInt--;
            UserNoteController.GetComponent<UserNoteScript>().DisplayJournalEntry();
        }
    }

    public void UpgradeWindows()
    {
        if (InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[9] >= 13)
        {
            WindowControllerScript.isBoarded = true;
            WindowControllerScript.updateWindows = true;
            InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[9] -= 13;
            WindowControllerScript.canUpgradeWindow = false; 
        }
        else
        {
            string CraftMessage = "You do not have enough nailed planks to upgrade your windows.";
            print(CraftMessage); 
        }
    }

    public void UpgradeDoors()
    {
        if(InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[10] >= 4)
        {
            WindowControllerScript.isAlarmed = true;
            WindowControllerScript.updateAlarms = true;
            InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[10] -= 4;
            WindowControllerScript.canUpgradeDoors = false; 
        }
    }

    public void DisplayNewColQPanel()
    {
        NewColQPanel.SetActive(true);
        MainCamera.GetComponent<CameraLerpScript>().hasSelected = true;
        NewColMessageTxt.GetComponent<Text>().text = "Will you let " + newColCount + " new addition(s) into your colony?"; 

    }

    public void AddNewColonist()
    {
        ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += newColCount;
        ColonyController.GetComponent<ColonyControllerScript>().ColonistCount += newColCount;
        NewColQPanel.SetActive(false);
        MainCamera.GetComponent<CameraLerpScript>().hasSelected = false;
        string NewColMessage = ">You let " + newColCount + " new colonist(s) join your colony.\n";
        UserNoteScript.UserNote += NewColMessage;
        UserNoteScript.updateNote = true;
        NotePanel.SetActive(true);
    }

    public void BanishNewColonist()
    {
        NewColQPanel.SetActive(false);
        MainCamera.GetComponent<CameraLerpScript>().hasSelected = false;
        string NewColMessage = ">You denied " + newColCount + " new colonist(s) from joining your colony.\n";
        UserNoteScript.UserNote += NewColMessage;
        UserNoteScript.updateNote = true;
        NotePanel.SetActive(true);
    }

    public void OpenCloseUpgradeOptions()
    {
        if(UpgradeOptionsPanel.active == false)
        {
            UpgradeOptionsPanel.SetActive(true); 
        }
        else
        {
            UpgradeOptionsPanel.SetActive(false); 
        }
    }
}
