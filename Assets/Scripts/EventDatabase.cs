using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventDatabase : MonoBehaviour {
	public List<Events> events = new List<Events>();
	
	void Start(){
		events.Add(new Events("nothing",0,"Your colony has survived another week."));
		events.Add(new Events("birth",1,"A colonist has given birth."));
		events.Add(new Events("traveler",2,"Travelers have asked to join the colony."));
		events.Add(new Events("merger",3,"Neighboring colony asked to join."));

		events.Add(new Events("outbreak",4,"Colonist have gotten sick!"));
		events.Add(new Events("bandits",5,"Bandits have attacked your camp."));
		events.Add(new Events("civilWar",6,"A civil war has broken out."));
		events.Add(new Events("exodus",7,"Colonist(s) have left your colony"));
		events.Add(new Events("chemAccid",8,"There was a chemical accident!"));

		events.Add(new Events("bear",9,"A bear attacked your scouting party."));
		events.Add(new Events("wolf",10,"A wolf pack attacked your scouting party."));
		events.Add(new Events("bandits",11,"Bandits attacked your scouting party."));
		events.Add(new Events("return",12,"Scouting party made it back safely."));
	}
}
