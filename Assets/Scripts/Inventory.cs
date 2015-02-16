using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public List<Item> inventory = new List<Item>();
	private ItemDatabase database;

	// Use this for initialization
	void Start () {
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase>();
		print (inventory.Count);
		inventory.Add(database.items[0]);
		inventory.Add(database.items[1]);
		print (inventory[0].itemName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
