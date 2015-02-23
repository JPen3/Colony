using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {
	public string itemName;
	public int itemID;
	public string itemDesc;
	public List<int> itemRecipe;
	public Texture2D itemIcon;
	public ItemType itemType;

	public enum ItemType {
		WEAPON,
		RESOURCE,
		MATERIAL,
		TOOL,
		FORTIFICATION,
		FOOD,
		CONSUMABLE,
		GEAR,
		KEYITEM
	}

	public Item(string name, int id, string desc, ItemType type){
		itemName = name;
		itemID = id;
		itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
		itemDesc = desc;
		itemType = type;
	}

	public Item(string name, int id, string desc, List<int> recipe, ItemType type){
		itemName = name;
		itemID = id;
		itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
		itemDesc = desc;
		itemRecipe = recipe;
		itemType = type;
	}

	public Item(){

	}
}
