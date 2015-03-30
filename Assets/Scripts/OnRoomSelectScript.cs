using UnityEngine;
using System.Collections;

public class OnRoomSelectScript : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject LerpPoint;
    public GameObject UIPanel01;
    public GameObject UIPanel02; 

	private Inventory inventory;
    
    // Use this for initialization
	void Start () {
        if (GameObject.Find("Main Camera"))
        {
            MainCamera = GameObject.Find("Main Camera");
        }

		inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
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
				//print (UIPanel01);
                MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel.SetActive(false);
                UIPanel01.SetActive(true);
                MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = UIPanel01;

				if(UIPanel01 == GameObject.Find("InventoryPanel"))
				{
					inventory.SetShowInventory(true);
				}
				if(UIPanel01 == GameObject.Find("CraftingPanel"))
				{
					inventory.SetShowInventory(true);
					inventory.SetShowCraft(true);
				}
            }
			//print ("inventory");

        }
    }
}
