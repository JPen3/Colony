using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayPropScript : MonoBehaviour {

    public int DayInt = 1;
    public GameObject DayTxt; 
    
    // Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        DayTxt.GetComponent<Text>().text = "Week: " + DayInt; 
	}
}
