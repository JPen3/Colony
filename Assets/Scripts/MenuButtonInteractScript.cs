using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class MenuButtonInteractScript : MonoBehaviour {

    public GameObject Text; 

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseOver()
    {
        print("i'm over you!!!"); 
        Text.GetComponent<Text>().color = Color.cyan; 
    }
    
    public void OnMouseExit()
    {
        print("I must go"); 
        Text.GetComponent<Text>().color = Color.white; 
    }
}
