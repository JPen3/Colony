using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Events{
	public string eventName;
	public int eventID;
	public string eventDesc;
	
	public Events(string name, int id, string desc){
		eventName = name;
		eventID = id;
		eventDesc = desc;
	}
	
	public Events(){
		
	}
}
