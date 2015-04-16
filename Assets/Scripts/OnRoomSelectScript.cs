using UnityEngine;
using System.Collections;

public class OnRoomSelectScript : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject LerpPoint;
    public GameObject UIPanel01;
    public GameObject UIPanel02; 

	private Inventory inventory;

    public GameObject ConsumptionController;
    public GameObject ColonyController; 
    
    // Use this for initialization
	void Start () {
        if (GameObject.Find("Main Camera"))
        {
            MainCamera = GameObject.Find("Main Camera");
        }

		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
        ConsumptionController = GameObject.Find("ConsumptionController");
        ColonyController = GameObject.Find("ColonistController"); 
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

				if(UIPanel01 == GameObject.Find("InventoryPanel"))
				{
					inventory.SetShowInventory(true);
				}
				if(UIPanel01 == GameObject.Find("CraftingPanel"))
				{
					inventory.SetShowInventory(true);
					inventory.SetShowCraft(true);
				}
                if(UIPanel01.name == "CafeteriaPanel")//when you click on cafateria room
                {
                    ConsumptionController.GetComponent<ConsumptionScript>().UpdateConsumerTxt();
                    ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt(); 
                }
                if(UIPanel01.name == "QuartersPanel")
                {
                    ColonyController.GetComponent<ColonyControllerScript>().UpdateQuartersStats(); 
                }
                if (UIPanel01.name == "GardenPanel")
                {
                    ConsumptionController.GetComponent<ConsumptionScript>().UpdateProductionTxt(); 
                }
            }
			//print ("inventory");

        }
    }

    public void printPanel()
    {
        //print (UIPanel01);
        
        UIPanel01.SetActive(true);
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = UIPanel01;
    }
}
