using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class InventoryInteractScript : MonoBehaviour {

    public int CraftNode01_ID = 51;
    public int CraftNode02_ID = 51;
    public int CraftNode03_ID = 51;

    public string CraftNode01_Name = "";
    public string CraftNode02_Name = "";
    public string CraftNode03_Name = "";

    public GameObject[] Inv_Obj;
    public GameObject[] Craft_Obj;

    public int SelectedItem_ID = 51;
    public string SelectedItem_Name = "";

    public GameObject ItemInfoPanel;
    public GameObject ItemNameTxt; 
    public GameObject ItemDescriptionTxt; 

    public int[] InventoryCount = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
    public string[] Inv_name = { "Glass Bottle", "Wood Plank", "Nails", "Cloth", "Rope", "Bin", "Alcohol", "Molotov Coctail", "Nailed Plank", "Boarded Window", "Sound Alarm", "Hammer" }; 
    public string[] Inv_description = { "An empty glass bottle.", "A simple plank of wood.", "Some nails to hammer with.", "Some plain cloth used for crafting.", "Some simple rope used for crafting.", "A simple bin used for crafting.", "Some alcohole used for crafting.", "A Molotov cocktail used for when out gathering.", "A simple plank of week with nails embeded in it.", "Boards to be nailed over your windows to prevent intruders.", "A simple noise alarm system to alarm you when unwanted guests arrive.", "A Hammer used when crafting items." }; 

    public int[] CraftCount = { 0, 0, 0 };

    public string resourceName = "Item Icons/";
    public Sprite[] icons = new Sprite[12];

    void Awake()
    {
        //icons = Resources.LoadAll<Sprite>(resourceName);
    }

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
        print("SelectInv called");
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
        print("I'm in DisplayInventory!");
        Inv_Obj = new GameObject[12];
        Craft_Obj = new GameObject[4];

        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("InventoryIcon");
        GameObject[] tempArray1 = GameObject.FindGameObjectsWithTag("CraftIcon");

        for (int i = 0; i < 12; i++)
        {
            Inv_Obj[i] = GameObject.Find(("ObjPanel" + (i + 1)).ToString());
        }

       
        for (int j = 0; j < 4; j++)
        {
            print("Craft_Node0" + (j + 1));
            Craft_Obj[j] = GameObject.Find(("Craft_Node0" + (j + 1)).ToString());
            print(Craft_Obj[j]);

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
        for (int i = 0; i < 3; i++)
        {
            //Craft_Obj[i].GetComponentInChildren<Text>().text = InventoryCount[i].ToString();
            //Craft_Obj[i].GetComponent<InventoryActions>().Inventory_ID = i;
            //Craft_Obj[i].GetComponent<InventoryActions>().ItemCount = InventoryCount[i];
            //print(Craft_Obj[i].GetComponent<Image>().sprite.ToString());
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
        print("In Set Craft Item");
        if(InventoryCount[SelectedItem_ID] > 0)
        {
            if (CraftNode01_ID > 50)
            {
                //print("CraftNode01_ID is " + CraftNode01_ID);
                CraftNode01_ID = SelectedItem_ID;
                CraftNode01_Name = Inv_name[SelectedItem_ID];
                print("CraftNode01_ID is " + CraftNode01_ID);
                Craft_Obj[0].GetComponent<Image>().sprite = icons[CraftNode01_ID];
                Inv_Obj[SelectedItem_ID].GetComponent<InventoryActions>().SubItemCount();
            }
            else if (CraftNode02_ID > 50)
            {
                print("CraftNode02_ID is " + CraftNode02_ID);
                CraftNode02_ID = SelectedItem_ID;
                CraftNode02_Name = Inv_name[SelectedItem_ID];
                Craft_Obj[1].GetComponent<Image>().sprite = icons[CraftNode02_ID];
                Inv_Obj[SelectedItem_ID].GetComponent<InventoryActions>().SubItemCount();
            }
            else if (CraftNode03_ID > 50)
            {
                print("CraftNode03_ID is " + CraftNode03_ID);
                CraftNode03_ID = SelectedItem_ID;
                CraftNode03_Name = Inv_name[SelectedItem_ID];
                Craft_Obj[2].GetComponent<Image>().sprite = icons[CraftNode03_ID];
                Inv_Obj[SelectedItem_ID].GetComponent<InventoryActions>().SubItemCount();
            }
            else
            {
                print("There are already items in both crafting nodes, click on one to deselect them.");
            }
            CloseItemInfoPanel();
        }
        else
        {
            print("You don't have enough of that item."); 
        }

        if ((CraftNode01_ID != 51) && (CraftNode02_ID != 51) && (CraftNode03_ID != 51))
        {
            if (CraftContains(0) && CraftContains(4) && CraftContains(5))
            {
                Craft_Obj[3].GetComponent<Image>().sprite = icons[10];
            }
            if (CraftContains(0) && CraftContains(3) && CraftContains(6))
            {
                Craft_Obj[3].GetComponent<Image>().sprite = icons[7];
            }
            if (CraftContains(1) && CraftContains(2) && CraftContains(11))
            {
                Craft_Obj[3].GetComponent<Image>().sprite = icons[8];
            }
            if (CraftContains(2) && CraftContains(8) && CraftContains(11))
            {
                Craft_Obj[3].GetComponent<Image>().sprite = icons[9];
            }
        }
    }

    public void Craft(){
        if ((CraftNode01_ID != 51) && (CraftNode02_ID != 51) && (CraftNode03_ID != 51)) {
            print("You can craft.");
            CraftAlarm();
            CraftMolotov();
            CraftNailBoard();
            CraftBoardWindow();
        }
        print("You cannot craft.");
    }

    public void resetCraft()
    {
        CraftNode01_ID = 51;
        CraftNode02_ID = 51;
        CraftNode03_ID = 51;
        for (int i = 0; i < 4; i++)
        {
            Craft_Obj[i].GetComponent<Image>().sprite = icons[12];
        }
    }

    void CraftAlarm()
    {
        if (CraftContains(0) && CraftContains(4) && CraftContains(5))
        {
            Inv_Obj[10].GetComponent<InventoryActions>().AddItemCount();
            resetCraft();
        }
    }

    void CraftMolotov()
    {
        if (CraftContains(0) && CraftContains(3) && CraftContains(6))
        {
            Inv_Obj[7].GetComponent<InventoryActions>().AddItemCount();
            resetCraft();
        }
    }

    void CraftNailBoard()
    {
        if (CraftContains(1) && CraftContains(2) && CraftContains(11))
        {
            Inv_Obj[8].GetComponent<InventoryActions>().AddItemCount();
            resetCraft();
        }
    }

    void CraftBoardWindow()
    {
        if (CraftContains(2) && CraftContains(8) && CraftContains(11))
        {
            Inv_Obj[9].GetComponent<InventoryActions>().AddItemCount();
            resetCraft();
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
