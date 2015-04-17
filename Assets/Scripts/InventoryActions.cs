using UnityEngine;
using System.Collections;

public class InventoryActions : MonoBehaviour {

    public int Inventory_ID;
    public int ItemCount;
    public GameObject InventoryController; 
    

    
    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        SubItemCount(); 
    }

    public void SubItemCount()
    {
        if (InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[Inventory_ID] > 0)
        {
            InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[Inventory_ID]--;
            InventoryController.GetComponent<InventoryInteractScript>().UpdateInventory(); 
        }
    }
}
