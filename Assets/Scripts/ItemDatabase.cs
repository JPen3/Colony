using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();

	void Start(){
		items.Add(new Item("bin",0,"A bin.",Item.ItemType.MATERIAL));
		items.Add(new Item("bottle",1,"A bottle.",Item.ItemType.MATERIAL));
		items.Add(new Item("cloth",2,"Some cloth.",Item.ItemType.MATERIAL));
		items.Add(new Item("hammer",3,"A hammer.",Item.ItemType.TOOL));
		items.Add(new Item("molotov",4,"A molotov cocktail.",new List<int>(new int[]{1,2,9}),Item.ItemType.WEAPON));
		items.Add(new Item("nails",5,"Some nails.",Item.ItemType.MATERIAL));
		items.Add(new Item("noise alarm",6,"A noise alarm.",new List<int>(new int[]{0,1,7}),Item.ItemType.FORTIFICATION));		
		items.Add(new Item("rope",7,"Some rope.",Item.ItemType.MATERIAL));
		items.Add(new Item("wood plank",8,"A wood plank.",Item.ItemType.MATERIAL));
		items.Add(new Item("alcohol",9,"Alcohol.",Item.ItemType.MATERIAL));
		items.Add(new Item("boarded window",10,"A boarded up window.",new List<int>(new int[]{3,5,8}),Item.ItemType.FORTIFICATION));
	}
}
