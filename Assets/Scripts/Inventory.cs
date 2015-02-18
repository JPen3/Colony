using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public List<Item> inventory = new List<Item>();
	private ItemDatabase database;

	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase>();
		inventory.Add(database.items[0]);
		inventory.Add(database.items[1]);
	}
	
	void OnGUI() {
		for(int i = 0; i < inventory.Count; i++){
			GUI.Label(new Rect(10,i*20,200,50), inventory[i].itemName);
		}
	}
}
