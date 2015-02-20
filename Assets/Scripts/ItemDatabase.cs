using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();

	void Start(){
		items.Add(new Item("bin",0,"A bin.",Item.ItemType.MATERIAL));
		items.Add(new Item("bottle",1,"A bottle.",Item.ItemType.MATERIAL));
		items.Add(new Item("cloth",2,"A cloth.",Item.ItemType.MATERIAL));
		items.Add(new Item("hammer",3,"A hammer.",Item.ItemType.TOOL));
		items.Add(new Item("molotov",4,"A molotov cocktail.",Item.ItemType.WEAPON));
		items.Add(new Item("nails",5,"A nails.",Item.ItemType.MATERIAL));
		items.Add(new Item("noise alarm",6,"A noise alarm.",Item.ItemType.FORTIFICATION));
		items.Add(new Item("rope",7,"Some rope.",Item.ItemType.MATERIAL));
		items.Add(new Item("wood plank",8,"A wook plank.",Item.ItemType.MATERIAL));
	}
}
