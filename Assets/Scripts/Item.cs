using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public ItemType itemType;

	public enum ItemType {
		WEAPON,
		RESOURCE,
		TOOL,
		FORTIFICATION
	}
}
