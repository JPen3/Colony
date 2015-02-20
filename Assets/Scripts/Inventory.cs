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

	// Use this for initialization
	void Start () {
		for(int i = 0; i < (slotsX*slotsY); i++){
			slots.Add(new Item());
			inventory.Add (new Item());
		}
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase>();
		AddItem(5);
		AddItem(1);
	}

	void Update(){
		if(Input.GetButtonDown("Inventory")){
			showInventory = !showInventory;
		}
	}
	
	void OnGUI() {
		GUI.skin = skin;
		if(showInventory){
			DrawInventory();
		}
	}

	void DrawInventory(){
		int i = 0;
		for(int y = 0; y < slotsY ; y++){
			for(int x = 0; x < slotsX ; x++){
				Rect slotRect = new Rect(x*60,y*60,50,50);
				GUI.Box(slotRect, "",skin.GetStyle("Slot"));
				slots[i] = inventory[i];
				if(slots[i].itemName != null){
					GUI.DrawTexture(slotRect,slots[i].itemIcon);
				}

				i++;
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
}
