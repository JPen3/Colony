using UnityEngine;
using System.Collections;

public class InventoryRotationScript : MonoBehaviour {

    public bool onHover = false;
    public Quaternion old_rot;
    public GameObject IconObj; 

    // Use this for initialization
	void Start () {
        old_rot = IconObj.transform.rotation; 
	}
	
	// Update is called once per frame
	void Update () {
	    if(onHover)
        {
            IconObj.transform.eulerAngles += new Vector3(0, 30 * Time.deltaTime, 0); 
        }
	}

    void OnMouseOver()
    {
        onHover = true; 
    }

    void OnMouseExit()
    {
        onHover = false;
        IconObj.transform.rotation = old_rot; 
    }
}
