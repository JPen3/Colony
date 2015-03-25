using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Event{
	public string eventName;
	public int eventID;
	public string eventDesc;
	
	public Event(string name, int id, string desc){
		eventName = name;
		eventID = id;
		eventDesc = desc;
	}
	
	public Event(){
		
	}
}
