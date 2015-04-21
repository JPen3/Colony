using UnityEngine;
using System.Collections;

public class InventoryRotationScript : MonoBehaviour {

    public bool onHover = false;
    public Quaternion old_rot;
    public Vector3 Icon_Reg_Scale; 
    public GameObject IconObj;
    public GameObject Inv_Panel; 
    public Vector3 ObjPanel_Reg_Scale;
    public Vector3 Inv_Panel_Scale; 

    public float MaxScreenWidth = 1600;
    public float MaxScreenHeight = 900; 

    // Use this for initialization
	void Start () {
        old_rot = IconObj.transform.rotation;
        Icon_Reg_Scale = IconObj.transform.localScale;
        ObjPanel_Reg_Scale = this.GetComponent<BoxCollider>().size;
        Inv_Panel_Scale = Inv_Panel.transform.localScale; 

        /*float ScreenScaleFactor = Screen.width / MaxScreenWidth;
        print(ScreenScaleFactor);
        IconObj.transform.localScale = new Vector3(IconObj.transform.localScale.x * ScreenScaleFactor, IconObj.transform.localScale.y * ScreenScaleFactor, IconObj.transform.localScale.z * ScreenScaleFactor); 
        */
	}
	
	// Update is called once per frame
	void Update () {
	    if(onHover)
        {
            //IconObj.transform.eulerAngles += new Vector3(0, 30 * Time.deltaTime, 0);
            IconObj.transform.Rotate(Vector3.down * Time.deltaTime*30, Space.Self); 
        }
        float ScreenScaleFactor = Screen.width / MaxScreenWidth;
        print(ScreenScaleFactor);
        IconObj.transform.localScale = new Vector3(Icon_Reg_Scale.x * ScreenScaleFactor, Icon_Reg_Scale.y * ScreenScaleFactor, Icon_Reg_Scale.z * ScreenScaleFactor);
        this.GetComponent<BoxCollider>().size = new Vector3(ObjPanel_Reg_Scale.x * ScreenScaleFactor, ObjPanel_Reg_Scale.y * ScreenScaleFactor, ObjPanel_Reg_Scale.z * ScreenScaleFactor);
        //Inv_Panel.transform.localScale = new Vector3(Inv_Panel_Scale.x * ScreenScaleFactor, Inv_Panel_Scale.y * ScreenScaleFactor, Inv_Panel_Scale.z*ScreenScaleFactor);
        //Inv_Panel.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 267 * ScreenScaleFactor); 
        //Inv_Panel.transform.localScale = new Vector3((float)1.2, (float)1.2, (float)1.2);
        //Inv_Panel.transform.localScale = new Vector3(1, 1, 1); 
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
