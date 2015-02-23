using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public int slotsX, slotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	private bool showInventory;
	private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;

	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;

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
		AddItem(6);
	}

	void Update(){
		if(Input.GetButtonDown("Inventory")){
			showInventory = !showInventory;
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
		if (draggingItem) {
			GUI.DrawTexture(new Rect(e.mousePosition.x, e.mousePosition.y, 50, 50), draggedItem.itemIcon);
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
							if(item.itemRecipe != null){
								for(int j = 0; j<item.itemRecipe.Count; j++){
									print (item.itemRecipe[j]);
								}
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

	/*private void UseConsumable(int id, int slot, bool deleteItem){
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
