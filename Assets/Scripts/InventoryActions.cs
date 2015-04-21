using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class InventoryActions : MonoBehaviour {

    public int Inventory_ID;
    public int ItemCount;
    public GameObject InventoryController;
    public GameObject ColorPanel; 

    public enum ItemType { Material, Tool, Item, Upgrade };
    public ItemType item_type;

    public GameObject InfoPanel; 
    

    
    // Use this for initialization
	void Start () {

        Color PanelColor; 

	    if(item_type == ItemType.Material)
        {
            PanelColor = Color.red; 
            PanelColor.a = .2f;
            ColorPanel.GetComponent<Image>().color = PanelColor;    
        }
        else if (item_type == ItemType.Tool)
        {

            PanelColor = Color.blue;
            PanelColor.a = .2f;
            ColorPanel.GetComponent<Image>().color = PanelColor; 
        }
        else if (item_type == ItemType.Item)
        {
            PanelColor = Color.green;
            PanelColor.a = .2f;
            ColorPanel.GetComponent<Image>().color = PanelColor; 
        }
        else if (item_type == ItemType.Upgrade)
        {
            PanelColor = Color.yellow;
            PanelColor.a = .2f;
            ColorPanel.GetComponent<Image>().color = PanelColor; 
        }
        else
        {
            PanelColor = Color.black;
            PanelColor.a = .2f;
            ColorPanel.GetComponent<Image>().color = PanelColor;  
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        SubItemCount();
        OpenWindow(); 
    }

    public void SubItemCount()
    {
        if (InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[Inventory_ID] > 0)
        {
            InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[Inventory_ID]--;
            InventoryController.GetComponent<InventoryInteractScript>().UpdateInventory(); 
        }
    }

    public void OpenWindow()
    {
        //GetComponent(RectTransform).anchoredPosition3D = Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        InfoPanel.SetActive(true); 
        InfoPanel.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(Input.mousePosition.x - (float)(Screen.width - InfoPanel.GetComponent<RectTransform>().rect.width*1.3), Input.mousePosition.y - (float)(InfoPanel.GetComponent<RectTransform>().rect.height * 1.3), -60); 
    }
}
