using UnityEngine;
using System.Collections;

public class OnRoomSelectScript : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject LerpPoint;
    public GameObject UIPanel01;
    public GameObject UIPanel02;

    public bool FirstVisit = true;

    public GameObject HelpPanel; 

	private Inventory inventory;

    public GameObject RoomUIController; 
    public GameObject WeekCounter; 
    public GameObject ConsumptionController;
    public GameObject ColonyController;
    public GameObject InventoryController;
    public GameObject UserNoteController; 
    
    // Use this for initialization
	void Start () {
        if (GameObject.Find("Main Camera"))
        {
            MainCamera = GameObject.Find("Main Camera");
        }

		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
        ConsumptionController = GameObject.Find("ConsumptionController");
        ColonyController = GameObject.Find("ColonistController");
        InventoryController = GameObject.Find("TestingInventory");
        UserNoteController = GameObject.Find("UserNoteController");
        WeekCounter = GameObject.Find("WeekPanel");
        //InventoryController.GetComponent<InventoryInteractScript>().DisplayInventory();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if(MainCamera.GetComponent<CameraLerpScript>().hasSelected == false)
        {
            MainCamera.GetComponent<CameraLerpScript>().hasSelected = true; 
            MainCamera.GetComponent<CameraLerpScript>().targetPoint = LerpPoint;
            MainCamera.GetComponent<CameraLerpScript>().isLerpin = true;
            MainCamera.GetComponent<CameraLerpScript>().LerpTimer = 0.0f;
            if (UIPanel01 != null)
            {
                Invoke("printPanel", (float)0.5);
                MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel.SetActive(false);

				if(UIPanel01.name == "InventoryPanel")
				{
					
                    
                    inventory.SetShowInventory(true);
                    print("You're in the Inventory");
                    print("Inventory is true");
				}
				if(UIPanel01.name == "CraftingPanel")
				{
					inventory.SetShowInventory(true);
					inventory.SetShowCraft(true);
                    print("You're in the Crafting");
                    print("Inventory is true");
                    print("Craft is true");
				}
                if(UIPanel01.name == "CafeteriaPanel")//when you click on cafateria room
                {
                    ConsumptionController.GetComponent<ConsumptionScript>().UpdateConsumerTxt();
                    ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt(); 
                }
                if(UIPanel01.name == "QuartersPanel")
                {
                    ColonyController.GetComponent<ColonyControllerScript>().UpdateQuartersStats();
                    print("You're in the Quarters");
                }
                if (UIPanel01.name == "GardenPanel")
                {
                    ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt();
                    print("You're in the Garden");
                }
                
            }
			//print ("inventory");

        }
    }

    public void CloseHelpPanel()
    {
        HelpPanel.SetActive(false); 
    }
    
    public void printPanel()
    {
        //print (UIPanel01);
        print(UIPanel02);
        
        UIPanel01.SetActive(true);

        if (UIPanel02 != null) { 
            UIPanel02.SetActive(true);
            MainCamera.GetComponent<CameraLerpScript>().SecondUIPanel = UIPanel02;
        }
        
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = UIPanel01;

        if(FirstVisit)
        {
            FirstVisit = false; 
            if(HelpPanel != null)
            {
                HelpPanel.SetActive(true); 
            }
        }

        if (UIPanel01.name == "TestInventoryPanel02")
        {
            InventoryController.GetComponent<InventoryInteractScript>().DisplayInventory();
        }
        if(UIPanel01.name == "EntryPanel")
        {
            print("Journal Access"); 
            UserNoteController.GetComponent<UserNoteScript>().DisplayWeekInt = WeekCounter.GetComponent<DayPropScript>().DayInt-1; 
            UserNoteController.GetComponent<UserNoteScript>().DisplayJournalEntry(); 
        }
        if (UIPanel01.name == "QuartersPanel" || UIPanel01.name == "InfirmaryPanel")
        {
            ColonyController.GetComponent<ColonyControllerScript>().UpdateQuartersStats();
            //print("You're in the Quarters");
        }
    }
}
