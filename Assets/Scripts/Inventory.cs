using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	public List<Item> craft = new List<Item>(new Item[]{new Item(),new Item(),new Item()});
	private bool showInventory;
	private bool showCraft;
	private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;

	private bool draggingItem;
	private bool draggingItemCraft;
	private Item draggedItem;
	private Item draggedItemCraft;
	private int prevIndex;
	private int prevIndexCraft;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < (slotsX*slotsY); i++){
			slots.Add(new Item());
			inventory.Add (new Item());
		}
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase>();
		AddItem(0);
		AddItem(1);
		AddItem(7);
		AddItem(1);
		AddItem(2);
		//AddItem(7);
		//AddItem(6);
	}

	void Update(){
		if(Input.GetButtonDown("Inventory")){
			if(showCraft){
				showCraft = !showCraft;
			}
			showInventory = !showInventory;
			print (showCraft);
		}
		if(Input.GetButtonDown("Craft")){
			/*if(!showCraft && showInventory){
				showCraft = !showCraft;
			}
			else{
				showCraft = !showCraft;
				showInventory = !showInventory;
			}*/
			CraftAlarm();
			CraftMolotov();
		}
	}

	void CraftAlarm(){
		if(CraftContains(0) && CraftContains(1) && CraftContains(7)){
			//RemoveItem(0);
			//RemoveItem(1);
			//RemoveItem(7);
			RemoveItemCraft(0);
			RemoveItemCraft(1);
			RemoveItemCraft(7);
			AddItem(6);
		}
	}

	void CraftMolotov(){
		if(CraftContains(0) && CraftContains(1)){
			//RemoveItem(0);
			//RemoveItem(1);
			//RemoveItem(7);
			RemoveItemCraft(1);
			RemoveItemCraft(2);
			AddItem(4);
		}
	}
	
	void OnGUI() {
		tooltip = "";
		Event e = Event.current;
		GUI.skin = skin;
		if(showInventory){
			DrawInventory();
			if (showTooltip) {
				GUI.Box(new Rect(e.mousePosition.x + 15f, e.mousePosition.y, 200, 200), tooltip, skin.GetStyle("Tooltip"));
			}
		}
		if(showCraft){
			DrawCraft();
		}
		if (draggingItem) {
			GUI.DrawTexture(new Rect(e.mousePosition.x, e.mousePosition.y, 50, 50), draggedItem.itemIcon);
		}
	}

	void DrawCraft(){
		Event e = Event.current;
		//int i = 0;
		for (int x = 0; x < 3; x++) {
			Rect slotRect = new Rect (x * 60, slotsY * 60, 50, 50);
			GUI.Box(slotRect, "",skin.GetStyle("Slot"));
			Item item = craft[x];
			
			if(item.itemName != null){
				GUI.DrawTexture(slotRect,item.itemIcon);
				if(slotRect.Contains(e.mousePosition)){
					tooltip = CreateTooltip(item);
					showTooltip = true;
					if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem){
						draggingItem = true;
						prevIndexCraft = x;
						print(prevIndexCraft);
						draggedItem = item;
						inventory[x] = new Item();
					}
					/*if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItemCraft){
						draggingItemCraft = true;
						prevIndexCraft = x;
						draggedItemCraft = item;
						craft[x] = new Item();
					}*/
					if(e.type == EventType.mouseUp){
						if(draggingItem){
							craft[prevIndexCraft] = craft[x];
							craft[x] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
						else if(draggingItemCraft){
							craft[prevIndexCraft] = craft[x];
							craft[x] = draggedItemCraft;
							draggingItemCraft = false;
							draggedItemCraft = null;
						}
					}
				}
			}
			else{
				if(slotRect.Contains(e.mousePosition)){
					if(e.type == EventType.mouseUp){
						if(draggingItem){
							craft[x] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
						if(draggingItemCraft){
							craft[x] = draggedItemCraft;
							draggingItemCraft = false;
							draggedItemCraft = null;
						}
					}
				}
			}
			if(tooltip == ""){
				showTooltip = false;
			}
			
			//i++;
		}
	}

	void DrawInventory(){
		Event e = Event.current;
		int i = 0;
		for(int y = 0; y < slotsY ; y++){
			for(int x = 0; x < slotsX ; x++){
				Rect slotRect = new Rect(x*60,y*60,50,50);
				GUI.Box(slotRect, "",skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				Item item = slots[i];

				if(item.itemName != null){
					GUI.DrawTexture(slotRect,item.itemIcon);
					if(slotRect.Contains(e.mousePosition)){
						tooltip = CreateTooltip(item);
						showTooltip = true;
						if(e.button == 0 && e.type == EventType.mouseDrag && !draggingItem){
							draggingItem = true;
							prevIndex = i;
							draggedItem = item;
							inventory[i] = new Item();
						}
						if(e.type == EventType.mouseUp && draggingItem){
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
						if(e.isMouse && e.type == EventType.mouseDown && e.button == 1){
							print ("Clicked " + i);
							if(item.itemType == Item.ItemType.MATERIAL){
								print ("Material");
							}
						}
						if(item.itemRecipe != null){
							for(int j = 0; j<item.itemRecipe.Count; j++){
								int k = item.itemRecipe[j];
								//RemoveItem(k);
								print(InventoryContains(k));
								//print (item.itemID);
							}
						}
					}
				}
				else{
					if(slotRect.Contains(e.mousePosition)){
						if(e.type == EventType.mouseUp && draggingItem){
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
					}
				}
				if(tooltip == ""){
					showTooltip = false;
				}

				i++;
			}
		}
	}

	string CreateTooltip(Item item){
		tooltip = "<color=#ffffff>" + item.itemName + "</color>\n\n" + item.itemDesc;
		return tooltip;
	}

	void RemoveItem(int id){
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory[i].itemID == id){
				inventory[i] = new Item();
				break;
			}
		}
	}

	void RemoveItemCraft(int id){
		for (int i = 0; i < craft.Count; i++) {
			if (craft[i].itemID == id){
				craft[i] = new Item();
				break;
			}
		}
	}

	void AddItem(int id){
		for (int i = 0; i < inventory.Count; i++) {
			if(inventory[i].itemName == null){
				inventory[i] = database.items[id];
				for(int j = 0; j < database.items.Count; j++){
					if(database.items[j].itemID == id){
						inventory[i] = database.items[j];
					}
				}
				break;
			}
		}
	}

	bool InventoryContains(int id){
		bool result = false;
		for(int i = 0; i < inventory.Count; i++){
			result = inventory[i].itemID == id;
			if(result){
				break;
			}
		}
		return result;
	}

	bool CraftContains(int id){
		bool result = false;
		for(int i = 0; i < craft.Count; i++){
			result = craft[i].itemID == id;
			if(result){
				break;
			}
		}
		return result;
	}

	public void SetShowInventory(bool show){
		showInventory = show;
	}

	public bool GetShowInventory(){
		return showInventory;
	}
	public void SetShowCraft(bool show){
		showCraft = show;
	}
	
	public bool GetShowCraft(){
		return showCraft;
	}

	/*private void UseConsumable(Item item, int slot, bool deleteItem){
		switch (id) 
		{
		case 0:
		{
			break;
		}
		
		}
		if(deleteItem)
		{
			inventory[slot] = new Item();
		}
	}*/
}
