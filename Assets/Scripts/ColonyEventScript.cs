using UnityEngine;
using System.Collections;

public class ColonyEventScript : MonoBehaviour {

    public GameObject ColonyController;
    public GameObject InventoryController; 
    public GameObject UIController; 

    
    //colonyEvent Prob int Vars--------------
    //colony positive events Prob Vars--------
    public int ColKidsState = 50;
    public int ColTravState = 30;
    public int ColColState = 15; 
    //colony negative events Prob Vars-------
    public int ColSickState = 25;
    public int ColBanditState = 25;
    public int ColLeaveState = 15;
    public int ColCivilWarState = 8;
    public int ColChemicalState = 10; 
    //gathering Event Prob in Vars-----------
    //gathering negative events Prob Vars----
    public int GathBearState = 10;
    public int GathWolfState = 15;
    public int GathBanditState = 25; 
    //gathering positive events Prob Vars----
    public int GathRunawayState = 20;
    public int GathFamState = 20;
    public int GathGroupState = 10; 
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
        int ColEventIntGB = Random.Range(0, 100); 
        if(ColEventIntGB <= 50)//positive event
        {
            int ColEventPosInt = Random.Range(0, 100); 
            if (ColEventPosInt <= ColKidsState)//colonists had children
            {
                int GainInt = Random.Range(1, 3);
                string Message = ">Colonists had " + GainInt + " kid(s).\n";
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt;
                UserNoteScript.UserNote += Message;
                print(Message);
            }
            else if (ColEventPosInt <= ColKidsState + ColTravState)//group of travelers came to colony, let them join?
            {
                int GainInt = Random.Range(2, 5);
                string Message = ">A Group of " + GainInt + " travelers have asked to join your colony.\n";
                UserNoteScript.UserNote += Message;
                print(Message);
                RoomUIScript.newColCount += GainInt;
                UIController.GetComponent<RoomUIScript>().DisplayNewColQPanel(); 

            }
            else if (ColEventPosInt <= ColKidsState + ColTravState + ColColState)//local colony wants to join you , let them?
            {
                int GainInt = Random.Range(6, 20);
                string Message = ">A local colony of " + GainInt + " has asked to join your colony\n";
                UserNoteScript.UserNote += Message;
                RoomUIScript.newColCount += GainInt;
                UIController.GetComponent<RoomUIScript>().DisplayNewColQPanel(); 
            }
            else//your colony survived another week
            {
                string message = ">Your Colony has survived another week.\n";
                UserNoteScript.UserNote += message; 
            }
        }
        else//negative event
        {
            int ColEventNegInt = Random.Range(0, 100); 
            if (ColEventNegInt <= ColSickState)//colonists have gotten sick
            {
                int SickCols = Random.Range(1, 1 + (int)(ColonyNum / 10));
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= SickCols;
                ColonyController.GetComponent<ColonyControllerScript>().ColSickCount += SickCols;
                string Message = ""; 
                if (SickCols > 1)
                {
                    Message = ">" + SickCols + " Colonosts have gotten sick!\n";
                }
                else
                {
                    Message = ">" + SickCols + " Colonost has gotten sick!\n";
                }
                UserNoteScript.UserNote += Message;
            }
            else if (ColEventNegInt <= ColSickState + ColBanditState)//bandits attack put in the the upgrade checks
            {
                if(WindowControllerScript.isAlarmed)//checks if alarms are set
                {
                    WindowControllerScript.canUpgradeDoors = true;
                    WindowControllerScript.isAlarmed = false;
                    WindowControllerScript.updateAlarms = true;
                    
                    string Message = ">Bandits have attacked your colony! Thankfully you had noise alarms, the bandits fleed! unfortunatly they destroyed your noise alarms.\n";
                    UserNoteScript.UserNote += Message; 

                }
                else
                {
                    if(WindowControllerScript.isBoarded)//checks if windows are boarded
                    {
                        int LossInt = Random.Range(0, 1);
                        WindowControllerScript.isBoarded = false;
                        WindowControllerScript.canUpgradeWindow = true;
                        WindowControllerScript.updateWindows = true;
                        if(LossInt > 0)
                        {
                            string Message = ">Your colony was attacked by Bandits! Luckily they were protected by boarded windows! There were no losses! Unfortunatly your windows were destroyed.\n";
                            UserNoteScript.UserNote += Message; 
                        }
                        else
                        {
                            if (LossInt > ColonyController.GetComponent<ColonyControllerScript>().ColonistCount)
                            {
                                LossInt = ColonyController.GetComponent<ColonyControllerScript>().ColonistCount; //all colonists were killed Game Over

                            }
                            string Message = ">" + LossInt + " colonist was lost in a Bandit Attack. Your boarded windows were destroyed in the attack.\n";
                            ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= LossInt;
                            ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                            UserNoteScript.UserNote += Message; 
                        }
                    }
                    else
                    {
                        int LossInt = Random.Range(1, 1 + (int)(ColonyNum / 4));
                        string Message = "";
                        if (LossInt > ColonyController.GetComponent<ColonyControllerScript>().ColonistCount)
                        {
                            LossInt = ColonyController.GetComponent<ColonyControllerScript>().ColonistCount; //all colonists were killed Game Over
                            
                        }
                        if (LossInt > 1)
                        {
                            Message = ">" + LossInt + "Colonists were lost in a Bandit Attack. This may have been avoided if you had noise alarms or boarded windows\n";
                        }
                        else
                        {
                            Message = ">1 colonist was lost in a Bandit Attack. This may have been avoided if you had noise alarms or boarded windows.\n"; 
                        }
                        UserNoteScript.UserNote += Message;
                        ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= LossInt;
                        ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                    }
                }
            }
            else if (ColEventNegInt <= ColSickState + ColBanditState + ColLeaveState)//colonists have decided to leave
            {
                int LossInt = Random.Range(1, 1+(int)(ColonyNum / 5));
                if (LossInt > ColonyController.GetComponent<ColonyControllerScript>().ColonistCount)
                {
                    LossInt = ColonyController.GetComponent<ColonyControllerScript>().ColonistCount; //all colonists were killed Game Over

                }
                string Message = ""; 
                if (LossInt > 1)
                {
                    
                    Message = ">" + LossInt + " Colonists have left your colony.\n";
                }
                else
                {
                    Message = ">" + LossInt + " Colonist has left your colony.\n";
                }
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= LossInt;
                ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                UserNoteScript.UserNote += Message;
            }
            else if (ColEventNegInt <= ColSickState + ColBanditState + ColLeaveState + ColCivilWarState)//colony civil war
            {
                int LossInt = Random.Range(1, 1 + (int)(ColonyNum / 3));
                if (LossInt > ColonyController.GetComponent<ColonyControllerScript>().ColonistCount)
                {
                    LossInt = ColonyController.GetComponent<ColonyControllerScript>().ColonistCount; //all colonists were killed Game Over

                }
                string Message = ""; 
                if (LossInt > 1)
                {
                    Message = ">" + LossInt + " Colonists were lost in a civil war that broke out!\n";
                }
                else
                {
                    Message = ">" + LossInt + " Colonist was lost in a civil war that broke out!\n";
                }
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= LossInt;
                ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount += LossInt;
                UserNoteScript.UserNote += Message;
            }
            else if (ColEventNegInt <= ColSickState + ColBanditState + ColLeaveState + ColCivilWarState + ColChemicalState)//chemical accident
            {
                int SickCols = Random.Range(1, 1 + (int)(ColonyNum / 10));
                ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable -= SickCols;
                ColonyController.GetComponent<ColonyControllerScript>().ColSickCount += SickCols;
                string Message = "";
                if (SickCols > 1)
                {
                    Message = ">" + SickCols + " Colonosts have gotten sick from a chemical accident!\n";
                }
                else
                {
                    Message = ">" + SickCols + " Colonost has gotten sick from a chemical accident!\n";
                }
                UserNoteScript.UserNote += Message;
            }
            else//your colony survived another week
            {
                string message = ">Your Colony has survived another week.";
                UserNoteScript.UserNote += message; 
            }
        }
    }
    
    public void GatheringEvent(int GatheringPartyNum, string PartyType)
    {
        int PosNegInt = Random.Range(0, 100); 
        if(PosNegInt <= 50)//Negative Gathering Event
        {
            int GathNegInt = Random.Range(0, 100); 
            if(GathNegInt <= GathBearState)//bear attacked gathering party check for molotov in inventory
            {
                if(InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[7] > 0)
                {
                    string Message = ">You Gathering party was attacked by a bear, but your party had a molotov cocktail to destract it and were able to escape.\n";
                    InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[7]--;
                    UserNoteScript.UserNote += Message; 
                }
                else
                {
                    int LossInt = Random.Range(1, GatheringPartyNum - 1);
                    string Message = "";
                    if (LossInt > 1)
                    {
                        Message = ">Your Gathering party suffered a bear Attack, " + LossInt + " were lost.\n";
                    }
                    else
                    {
                        Message = ">Your Gathering party suffered a bear Attack, " + LossInt + " was lost.\n";
                    }
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
                    UserNoteScript.UserNote += Message; 
                }
            }
            else if(GathNegInt <= GathBearState + GathWolfState)
            {
                if (InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[7] > 0)
                {
                    string Message = ">You Gathering party was attacked by wolves, but your party had a molotov cocktail to destract them and were able to escape.\n";
                    InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[7]--;
                    UserNoteScript.UserNote += Message;
                }
                else
                {
                    int LossInt = Random.Range(1, GatheringPartyNum - 1);
                    string Message = "";
                    if (LossInt > 1)
                    {
                        Message = ">Your Gathering party suffered a wolf Attack, " + LossInt + " were lost. This may have been avoided if your colony had some molotov cocktails to protect them.\n";
                    }
                    else
                    {
                        Message = ">Your Gathering party suffered a wolf Attack, " + LossInt + " was lost. This may have been avoided if your colony had some molotov cocktails to protect them.\n";
                    }
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
                    UserNoteScript.UserNote += Message;
                }
            }
            else if(GathNegInt <= GathBearState + GathWolfState + GathBanditState)
            {
                if (InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[7] > 0)
                {
                    string Message = ">You Gathering party was attacked by bandits, but your party had a molotov cocktail to destract them and were able to escape.\n";
                    InventoryController.GetComponent<InventoryInteractScript>().InventoryCount[7]--;
                    UserNoteScript.UserNote += Message;
                }
                else
                {
                    int LossInt = Random.Range(1, GatheringPartyNum - 1);
                    string Message = "";
                    if (LossInt > 1)
                    {
                        Message = ">Your Gathering party was attacked by bandits, " + LossInt + " were lost. This may have been avoided if your colony had some molotov cocktails to protect them.\n";
                    }
                    else
                    {
                        Message = ">Your Gathering party was attacked by bandits, " + LossInt + " was lost. This may have been avoided if your colony had some molotov cocktails to protect them.\n";
                    }
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
                    UserNoteScript.UserNote += Message;
                }
            }
            else
            {
                string Message = ">Your gathering party has returned safely.\n";
                UserNoteScript.UserNote += Message;
            }
        }
        else//Positive Gathering Event
        {
            int GathPosInt = Random.Range(0, 100); 
            if(GathPosInt <= GathRunawayState)//gathering party found a runaway
            {
                int GainInt = 1;
                string Message = ">Gathering Party found a runaway While they were out.\n";
                //ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt;
                UserNoteScript.UserNote += Message;
                print(Message);
                RoomUIScript.newColCount += GainInt;
                UIController.GetComponent<RoomUIScript>().DisplayNewColQPanel();
            }
            else if (GathPosInt <= GathRunawayState + GathFamState)//gathering party found a family
            {
                int GainInt = Random.Range(2, 6);
                string Message = ">Party found a family of " + GainInt + " While out Gathering.\n";
                //ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt;
                UserNoteScript.UserNote += Message; 
                RoomUIScript.newColCount += GainInt;
                UIController.GetComponent<RoomUIScript>().DisplayNewColQPanel();
            }
            else if (GathPosInt <= GathRunawayState + GathFamState + GathGroupState)//gathering party found a group
            {
                int GainInt = Random.Range(7, 12);
                string Message = ">Party found a group of " + GainInt + " While out Gathering.\n";
                //ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt;
                UserNoteScript.UserNote += Message; 
                RoomUIScript.newColCount += GainInt;
                UIController.GetComponent<RoomUIScript>().DisplayNewColQPanel();
            }
            else
            {
                string Message = ">Your gathering party has returned safely.\n";
                UserNoteScript.UserNote += Message; 
            }
        }
    }

    /*
    public void GatheringEvent(int GatheringPartyNum, string PartyType)
    {
        int PlusOrNeg = Random.Range(0, 100); 
        if(PlusOrNeg <= 50)//Negative Gathering Event
        {
            int EventInt = Random.Range(0, 100);
            if(EventInt <= 50)//Nothing Happens
            {
                print("nothing eventfull Happened\n"); 
            }
            else if(EventInt <= 60)//Bear Attack
            {
                int LossInt = Random.Range(1, GatheringPartyNum - 1);
                string Message = ">Bear Attack, " + LossInt + " were lost.\n";
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
                UserNoteScript.UserNote += Message; 
                print(Message); 
            }
            else if (EventInt <= 75)//wolf Attack
            {
                int LossInt = Random.Range(1, GatheringPartyNum - 1);
                string Message = ">Wolf Attack, " + LossInt + " were lost.\n";
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
                UserNoteScript.UserNote += Message; 
                print(Message);
            }
            else if (EventInt <= 100)//Bandit Attack
            {
                int LossInt = Random.Range(1, GatheringPartyNum - 1);
                string Message = ">Bandits Attack, " + LossInt + " were lost.\n";
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
                UserNoteScript.UserNote += Message; 
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
                string Message = ">Everyone Made it back safe.\n";
                UserNoteScript.UserNote += Message; 
                print(Message); 
            }
            else if(EventInt <= 70)//found 1 runaway
            {
                int GainInt = 1;
                string Message = ">Party found a runaway.\n";
                //ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt;
                UserNoteScript.UserNote += Message; 
                print(Message);
                RoomUIScript.newColCount += GainInt;
                UIController.GetComponent<RoomUIScript>().DisplayNewColQPanel(); 
            }
            else if (EventInt <= 90)//found a family
            {
                int GainInt = Random.Range(2, 6); 
                string Message = ">Party found a family of " + GainInt + " While Gathering.\n";
                //ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt;
                UserNoteScript.UserNote += Message; 
                print(Message);
                RoomUIScript.newColCount += GainInt;
                UIController.GetComponent<RoomUIScript>().DisplayNewColQPanel(); 
            }
            else if (EventInt <= 100)//found a group
            {
                int GainInt = Random.Range(5, 15);
                string Message = ">Party found a group of " + GainInt + " While Gathering.\n";
                //ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable += GainInt;
                UserNoteScript.UserNote += Message; 
                print(Message);
                RoomUIScript.newColCount += GainInt;
                UIController.GetComponent<RoomUIScript>().DisplayNewColQPanel();
            }
            else
            {
                print("ERROR: EventInt Out of Range");
            }
            
        }
    }
    */

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
            //string Message = "> after sickness: " + sickHealedNum + " Colonists were healed | " + sickInfectedNum + " Colonists were infected | " + sickDeathNum + " were lost.\n";
            string Message = ">There are " + ColSickNum + " in the infimary.\n";
            if(sickHealedNum > 0)
            {
                Message += ">" + sickHealedNum + " have recovered from the infirmary.\n"; 
            }
            if(sickInfectedNum > 0)
            {
                Message += ">" + sickInfectedNum + " have also become sick.\n"; 
            }
            if(sickDeathNum > 0)
            {
                Message += ">" + sickDeathNum + " sick colonists have been lost.\n"; 
            }
            UserNoteScript.UserNote += Message; 

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
