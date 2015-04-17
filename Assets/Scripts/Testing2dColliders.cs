using UnityEngine;
using System.Collections;

public class Testing2dColliders : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseOver()
    {
        print("I'm not clicking on you"); 
    }
    public void OnMouseExit()
    {
        print("I'm gone!!!"); 
    }
}
