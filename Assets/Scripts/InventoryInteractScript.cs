using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class InventoryInteractScript : MonoBehaviour {

    public int CraftNode01_ID = 51;
    public int CraftNode02_ID = 51;
    public int CraftNode03_ID = 51;

    public GameObject[] Inv_Obj;
    public GameObject[] Craft_Obj;

    public int SelectedItem_ID = 51; 
    public GameObject ItemInfoPanel;
    public GameObject ItemNameTxt; 
    public GameObject ItemDescriptionTxt; 

    public int[] InventoryCount = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
    public string[] Inv_name = { "Glass Bottle", "Wood Plank", "Nails", "Cloth", "Rope", "Bin", "Alcahol", "Junk", "Molotov Coctail", "Nailed Plank", "Sound Alarm", "Hammer" }; 
    public string[] Inv_description = { "An empty glass bottle.", "A simple plank of wood.", "Some nails to hammer with.", "Some plain cloth used for crafting.", "Some simple rope used for crafting.", "A simple bin used for crafting.", "Some alcahole used for crafting.", "Bits of this and that used for crafting.", "A Molotov cocktail used for when out gathering.", "A simple plank of week with nails embeded in it.", "A simple noise alarm system to alarm you when unwanted guests arrive.", "A Hammer used when crafting items." }; 
    public int[] CraftCount = { 0, 0, 0 };

    
    // Use this for initialization
	void Start () {
        
        
        //Inv_Obj[0] = GameObject.Find("ObjPanel01"); 
            //Inv_Obj = GameObject.FindGameObjectsWithTag("InventoryIcon"); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SelectInv(string methodString)
    {
        string methodName = methodString; 
        System.Type thisType = this.GetType();
        System.Reflection.MethodInfo theMethod = thisType.GetMethod(methodName);
        theMethod.Invoke(this, null);
    }

    public void testMethod()
    {
        print("the test has worked!!!!!!!");
    }

    public void DisplayInventory()
    {
        Inv_Obj = new GameObject[12];
        Craft_Obj = new GameObject[4];

        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("InventoryIcon");
        GameObject[] tempArray1 = GameObject.FindGameObjectsWithTag("CraftIcon");

        for (int i = 0; i < 12; i++)
        {
            Inv_Obj[i] = GameObject.Find(("ObjPanel" + (i + 1)).ToString());
        }

        for (int j = 0; j < Craft_Obj.Length; j++)
        {
            Craft_Obj[j] = GameObject.Find(("CraftNode" + j).ToString());
        }

        UpdateInventory();
        UpdateCraft(); 
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < 12; i++)
        {
            Inv_Obj[i].GetComponentInChildren<Text>().text = InventoryCount[i].ToString();
            Inv_Obj[i].GetComponent<InventoryActions>().Inventory_ID = i;
            Inv_Obj[i].GetComponent<InventoryActions>().ItemCount = InventoryCount[i];
        }
    }

    public void UpdateCraft()
    {
        for (int i = 0; i < 4; i++)
        {
            //Craft_Obj[i].GetComponentInChildren<Text>().text = InventoryCount[i].ToString();
            //Craft_Obj[i].GetComponent<InventoryActions>().Inventory_ID = i;
            //Craft_Obj[i].GetComponent<InventoryActions>().ItemCount = InventoryCount[i];
        }
    }

    public void setUpCanClick(GameObject clickedPanel, bool value)
    {
        for(int i = 0; i < Inv_Obj.Length; i++)
        {
            Inv_Obj[i].GetComponent<InventoryActions>().canClick = value; 
        }
        if(value == false)
        {
            clickedPanel.GetComponent<InventoryActions>().canClick = true; 
        }
    }

    public void CloseItemInfoPanel()
    {
        SelectedItem_ID = 51; 
        setUpCanClick(null, true);
        ItemInfoPanel.SetActive(false); 
    }

    public void setCraftItem()
    {
        if(InventoryCount[SelectedItem_ID] > 0)
        {
            if (CraftNode01_ID > 50)
            {
                CraftNode01_ID = SelectedItem_ID;
                Inv_Obj[SelectedItem_ID].GetComponent<InventoryActions>().SubItemCount();
            }
            else if (CraftNode02_ID > 50)
            {
                CraftNode02_ID = SelectedItem_ID;
                Inv_Obj[SelectedItem_ID].GetComponent<InventoryActions>().SubItemCount();
            }
            else if (CraftNode03_ID > 50)
            {
                CraftNode03_ID = SelectedItem_ID;
                Inv_Obj[SelectedItem_ID].GetComponent<InventoryActions>().SubItemCount();
            }
            else
            {
                print("There are already items in both crafting nodes, click on one to deselect them.");
            }
        }
        else
        {
            print("You don't have enough of that item."); 
        }
        
        
    }

    public void Craft(){
        if ((CraftNode01_ID != 51) && (CraftNode02_ID != 51) && (CraftNode03_ID != 51)) {
            print("You can craft.");
            CraftAlarm();
            CraftMolotov();
        }
        print("You cannot craft.");
    }

    void CraftAlarm()
    {
        if (CraftContains(0) && CraftContains(4) && CraftContains(5))
        {
            Inv_Obj[10].GetComponent<InventoryActions>().AddItemCount();
            CraftNode01_ID = 51;
            CraftNode02_ID = 51;
            CraftNode03_ID = 51;
        }
    }

    void CraftMolotov()
    {
        if (CraftContains(0) && CraftContains(3) && CraftContains(6))
        {
            Inv_Obj[8].GetComponent<InventoryActions>().AddItemCount();
            CraftNode01_ID = 51;
            CraftNode02_ID = 51;
            CraftNode03_ID = 51;
        }
    }

    public bool CraftContains(int id){
        bool result = false;
        if(CraftNode01_ID == id){
            result = true;
        }
        else if(CraftNode02_ID == id){
            result = true;
        }
        else if (CraftNode03_ID == id){
            result = true;
        }
        return result;
    }


    public void useSelectItem()
    {
        Inv_Obj[SelectedItem_ID].GetComponent<InventoryActions>().SubItemCount(); 
    }
}
