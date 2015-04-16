using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory2 : MonoBehaviour {

    private RectTransform inventoryRect;

    private float inventoryWidth, inventoryHeight;

    public int slots, rows;

    public float slotPaddingLeft, slotPaddingTop;

    public float slotSize;

    public GameObject slotPrefab;

    private List<GameObject> allSlots;



    // Use this for initialization
	void Start () {
        CreateLayout();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CreateLayout()
    {
        allSlots = new List<GameObject>();

    }
}
