using UnityEngine;
using System.Collections;

public class ColonyEventScript : MonoBehaviour {

    public GameObject ColonyController;

    //sickEvent Prob int Vars----------------
    public int SickHealState = 50;
    public int SickInfectState = 10;
    public int SickDieState = 7;
    //sickEvent result Vars-----------------
    public int sickHealedNum = 0;
    public int sickInfectedNum = 0;
    public int sickDeathNum = 0; 

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ColonyEvent(int ColonyNum)
    {
        int ColEventInt01 = Random.Range(0, 100); 
        if(ColEventInt01 <= 50)//Nothing Happens
        {
            string Message = "Your Colony has survived another week.";
            print(Message); 
        }
        else if(ColEventInt01 <= 75)//Positive Event
        {
            int ColEventInt02 = Random.Range(0, 100); 
            if(ColEventInt02 <= 50)//children
            {
                int GainInt = Random.Range(1, 3);
                string Message = "A Colonist had " + GainInt + "Kid(s).";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt; 
                print(Message); 
            }
            else if(ColEventInt02 <= 80)//people found your colony
            {
                int GainInt = Random.Range(2, 4);
                string Message = GainInt + " travelers have asked to join your colony";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt; 
                print(Message); 
            }
            else if(ColEventInt02 <= 100)//joined neighbor colony
            {
                int GainInt = Random.Range(10, 20);
                string Message = "A neighbor Colony of " + GainInt + " has decided to join yours";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt; 
                print(Message); 
            }
        }
        else if(ColEventInt01 <= 100)//Negative Event
        {
            int ColEventInt02 = Random.Range(0, 100); 
            if(ColEventInt02 <= 25)//sickness
            {
                int SickCols = Random.Range(1, (int)(1+(ColonyNum/10)));
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= SickCols; 
                ColonyController.GetComponent<ColonyControllerScript>().ColSickCount += SickCols; 
                string Message = SickCols + " Colonost(s) have gotten sick!";

                print(Message); 
            }
            else if(ColEventInt01 <= 50)//Bandit Attack!
            {
                int LossInt = Random.Range(1, (int)(ColonyNum / 2));
                string Message = LossInt + "Colonist(s) were lost in a Bandit Attack!";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= LossInt;
                ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                print(Message); 
            }
            else if (ColEventInt01 <= 70)//Colonists left
            {
                int LossInt = Random.Range(1, (int)(ColonyNum / 5));
                string Message = LossInt + "Colonist(s) have left your colony.";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= LossInt;
                ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                print(Message); 
            }
            else if (ColEventInt01 <= 80)//civil war!
            {
                int LossInt = Random.Range(1, (int)(ColonyNum / 3));
                string Message = LossInt + "Colonist(s) were lost in a civil war that broke out!";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= LossInt;
                ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                print(Message); 
            }
            else if (ColEventInt01 <= 50)//Chemical Accident!
            {
                int LossInt = Random.Range(1, 3);
                string Message = LossInt + "Colonist(s) were lost in a chemical Accident!";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= LossInt;
                ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                print(Message); 
            }
        }
    }
    
    public void GatheringEvent(int GatheringPartyNum, string PartyType)
    {
        int PlusOrNeg = Random.Range(0, 100); 
        if(PlusOrNeg <= 50)//Negative Gathering Event
        {
            int EventInt = Random.Range(0, 100);
            if(EventInt <= 50)//Nothing Happens
            {
                print("nothing eventfull Happened"); 
            }
            else if(EventInt <= 60)//Bear Attack
            {
                int LossInt = Random.Range(1, GatheringPartyNum - 1);
                string Message = "Bear Attack, " + LossInt + " were lost.";
                if(PartyType == "Mat")
                {
                    ColonyController.GetComponent<ColonyControllerScript>().ColResourceAway -= LossInt;
                    ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                }
                else if(PartyType == "Supply")
                {
                    ColonyController.GetComponent<ColonyControllerScript>().ColSupplyAway -= LossInt;
                    ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                }
                print(Message); 
            }
            else if (EventInt <= 75)//wolf Attack
            {
                int LossInt = Random.Range(1, GatheringPartyNum - 1);
                string Message = "Wolf Attack, " + LossInt + " were lost.";
                if (PartyType == "Mat")
                {
                    ColonyController.GetComponent<ColonyControllerScript>().ColResourceAway -= LossInt;
                    ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                }
                else if (PartyType == "Supply")
                {
                    ColonyController.GetComponent<ColonyControllerScript>().ColSupplyAway -= LossInt;
                    ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                }
                print(Message);
            }
            else if (EventInt <= 100)//Bandit Attack
            {
                int LossInt = Random.Range(1, GatheringPartyNum - 1);
                string Message = "Bandits Attack, " + LossInt + " were lost.";
                if (PartyType == "Mat")
                {
                    ColonyController.GetComponent<ColonyControllerScript>().ColResourceAway -= LossInt;
                    ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                }
                else if (PartyType == "Supply")
                {
                    ColonyController.GetComponent<ColonyControllerScript>().ColSupplyAway -= LossInt;
                    ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                }
                print(Message);
            }
            else
            {
                print("ERROR: EventInt Out of Range"); 
            }
        }
        else if(PlusOrNeg <= 100)//positive Gathering Event
        {
            int EventInt = Random.Range(0, 100); 
            if(EventInt <= 50)//Nothing Happens
            {
                string Message = "Everyone Made it back safe.";
                print(Message); 
            }
            else if(EventInt <= 70)//found 1 runaway
            {
                int GainInt = 1;
                string Message = "Party found a runaway.";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt; 
                print(Message); 
            }
            else if (EventInt <= 90)//found a family
            {
                int GainInt = Random.Range(2, 6); 
                string Message = "Party found a family of " + GainInt + " While Gathering.";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt; 
                print(Message);
            }
            else if (EventInt <= 100)//found a group
            {
                int GainInt = Random.Range(5, 15);
                string Message = "Party found a group of " + GainInt + " While Gathering.";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt; 
                print(Message);
            }
            else
            {
                print("ERROR: EventInt Out of Range");
            }
            
        }
    }

    public void SickEvent(int ColSickNum)
    {
        print("COlSickNum: " + ColSickNum); 
        if(ColSickNum > 0)
        {
            sickHealedNum = 0;
            sickInfectedNum = 0;
            sickDeathNum = 0; 
            
            for (int i = 0; i < ColSickNum; i++)
            {
                print("SickNum: " + i);
                int RandSick = Random.Range(0, 100);
                if (RandSick <= SickHealState)
                {
                    sickHealedNum++;
                }
                else if (RandSick <= SickHealState + SickInfectState)
                {
                    //sickColonist has spread sickness to another if there are any more colonists present to get sick
                    if (ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable > 0)
                    {
                        sickInfectedNum++;
                    }
                }
                else if (RandSick <= SickHealState + SickInfectState + SickDieState)
                {
                    sickDeathNum++;
                }
                else
                {
                    //all the sick peeps are still sick!!!
                }
            }
            print("after sickness: " + sickHealedNum + " Colonists were healed | " + sickInfectedNum + " Colonists were infected | " + sickDeathNum + " were lost.");

            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += sickHealedNum;
            ColonyController.GetComponent<ColonyControllerScript>().ColSickCount -= sickHealedNum;
            ColonyController.GetComponent<ColonyControllerScript>().ColSickCount += sickInfectedNum;
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= sickInfectedNum;
            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= sickDeathNum;
            ColonyController.GetComponent<ColonyControllerScript>().ColSickCount -= sickDeathNum;
            ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += sickDeathNum; 
        }
    }
}
