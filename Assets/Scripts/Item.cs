using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public ItemType itemType;

	public enum ItemType {
		WEAPON,
		RESOURCE,
		MATERIAL,
		TOOL,
		FORTIFICATION,
		FOOD,
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
}
