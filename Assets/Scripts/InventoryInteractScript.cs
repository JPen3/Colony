using UnityEngine;
using System.Collections;

public class InventoryInteractScript : MonoBehaviour {

    public int CraftNode01_ID = 0;
    public int CraftNode02_ID = 0;

    public GameObject[] Inv_Obj; 

    public int[] InventoryCount = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

    
    // Use this for initialization
	void Start () {
        Inv_Obj = new GameObject[12]; 
        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("InventoryIcon");
        for (int i = 0; i < 12; i++ )
        {
            Inv_Obj[i] = GameObject.Find(("ObjPanel" + (i + 1)).ToString()); 
        }
        //Inv_Obj[0] = GameObject.Find("ObjPanel01"); 
            //Inv_Obj = GameObject.FindGameObjectsWithTag("InventoryIcon"); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SelectInv(string methodString)
    {
        string methodName = methodString; 
        System.Type thisType = this.GetType();
        System.Reflection.MethodInfo theMethod = thisType.GetMethod(methodName);
        theMethod.Invoke(this, null);
    }

    public void testMethod()
    {
        print("the test has worked!!!!!!!");
    }
}
