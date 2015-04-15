using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class ConsumptionScript : MonoBehaviour {

    public GameObject ColonyController;
    public GameObject ColFoodTxt;
    public GameObject ColWaterTxt;
    public GameObject ConFoodTxt;
    public GameObject ConWaterTxt; 

    public double TotalColFoodInt;
    public double TotalColWaterInt; 

    public double ColFoodInt;
    public double ColWaterInt; 

    public double ColFoodConsumeINT;
    public double ColWaterConsumeINT;

    public int NoFoodWeek = 0; 
    
    // Use this for initialization
	void Start () {
        //UpdateConsumerTxt();
	}
	
	// Update is called once per frame
	void Update () {
         
	}

    public void ConsumeWater(int days)
    {
        if (ColWaterConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable <= ColWaterInt)
        {
            print("ColCountWater: " + ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable); 
            ColWaterInt -= ColWaterConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable;
            print("water consumption: " + ColWaterConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable); 
        }
        else
        {
            print("not enough water for current residence");
            int waterStarvedInt = 0;
            int ColCheckCount = ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable;
            for(int i = 0; i < ColCheckCount; i++)
            {
                if(ColWaterInt - (ColWaterConsumeINT * days) >= 0)
                {
                    ColWaterInt -= (ColWaterConsumeINT * days); 
                }
                else
                {
                    waterStarvedInt++; 
                    ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable--;
                    ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount++; 
                }
            }
            string message = ">" + waterStarvedInt + " Colonists have left because you ran out of water.\n";
            UserNoteScript.UserNote += message; 
        }

    }

    public void ConsumeFood(int days)
    {
        if (ColFoodConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistCount <= ColFoodInt)
        {
            print("ColCountFood: " + ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable);
            ColFoodInt -= ColFoodConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable;
            print("food consumption: " + ColFoodConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable);
        }
        else
        {
            print("not enough Food for for current residence");
            int starvationDeathInt = 0;
            NoFoodWeek++; 
            int ColCheckCount = ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable;
            for (int i = 0; i < ColCheckCount; i++)
            {
                if (ColFoodInt - (ColFoodConsumeINT * days) >= 0)
                {
                    ColFoodInt -= (ColFoodConsumeINT * days);
                    print("ColFood: " + ColFoodInt); 
                }
                else
                {
                    if(NoFoodWeek >= 3)
                    {
                        starvationDeathInt++;
                        ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable--;
                        ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount++;
                    }
                }
                print("col Check Count:" + i); 
            }
            if(NoFoodWeek >= 3)
            {
                NoFoodWeek = 0; 
                string message = ">" + starvationDeathInt + "Colonists have left because you ran out of food.\n";
                print(message);
                UserNoteScript.UserNote += message;
            }
            if(NoFoodWeek > 0)
            {
                string message = ">Your Colony has gone " + NoFoodWeek + " week(s) without food. " + (3 - NoFoodWeek) + " more week(s) and colonists will start to leave.\n";
                UserNoteScript.UserNote += message; 
            }

        }
    }

    public void UpdateConsumerTxt()
    {
        ColFoodTxt.GetComponent<Text>().text = ":" + ColFoodInt + " lbs";
        ColWaterTxt.GetComponent<Text>().text = ColWaterInt + " gal:";
        ConFoodTxt.GetComponent<Text>().text = ColFoodConsumeINT * 7 * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable + " lbs/week";
        print("FoodCon: " + ColFoodConsumeINT * 7 * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable); 
        ConWaterTxt.GetComponent<Text>().text = ColWaterConsumeINT * 7 * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable + " gal/week";
        print("WaterCon: " + ColWaterConsumeINT * 7 * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable); 

        
    }

    public void ConsumptionUpdate()
    {
        print("Colonists Available: " + ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable);
        ConsumeWater(7);
        if (ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable > 0)
        {
            ConsumeFood(7);
        }
        //UpdateConsumerTxt(); 
    }
}
