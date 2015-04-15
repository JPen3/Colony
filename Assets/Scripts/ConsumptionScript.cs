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
    
    // Use this for initialization
	void Start () {
        UpdateConsumerTxt();
	}
	
	// Update is called once per frame
	void Update () {
         
	}

    public void ConsumeWater(int days)
    {
        if (ColWaterConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable <= ColWaterInt)
        {
            ColWaterInt -= ColWaterConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable;
            //print("water consumption: " + ColWaterConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistCount); 
        }
        else
        {
            print("not enough water for current residence"); 
            for(int i = 0; i < ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable; i++)
            {
                if(ColWaterInt - (ColWaterConsumeINT * days) >= 0)
                {
                    ColWaterInt -= (ColWaterConsumeINT * days); 
                }
                else
                {
                    ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable--;
                    ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount++; 
                }
            }
        }

    }

    public void ConsumeFood(int days)
    {
        if (ColFoodConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistCount <= ColFoodInt)
        {
            ColFoodInt -= ColFoodConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistCount;
        //print("food consumption: " + ColFoodConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistCount);
        }
        else
        {
            print("not enough Food for for current residence");
            for (int i = 0; i < ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable; i++)
            {
                if (ColFoodInt - (ColFoodConsumeINT * days) >= 0)
                {
                    ColFoodInt -= (ColFoodConsumeINT * days);
                    print("ColFood: " + ColFoodInt); 
                }
                else
                {
                    ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable--;
                    ColonyController.GetComponent<ColonyControllerScript>().ColDeathCount++;
                }
            }
        }
    }

    public void UpdateConsumerTxt()
    {
        ColFoodTxt.GetComponent<Text>().text = ":" + ColFoodInt + " lbs";
        ColWaterTxt.GetComponent<Text>().text = ColWaterInt + " gal:";
        ConFoodTxt.GetComponent<Text>().text = "Food Consumption:" + ColFoodConsumeINT * 7 * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable + " lbs/week";
        print("FoodCon: " + ColFoodConsumeINT * 7 * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable); 
        ConWaterTxt.GetComponent<Text>().text = "Water Consumption:" + ColWaterConsumeINT * 7 * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable + " gal/week";
        print("WaterCon: " + ColWaterConsumeINT * 7 * ColonyController.GetComponent<ColonyControllerScript>().ColonistsAvailable); 

        
    }

    public void ConsumptionUpdate()
    {
        ConsumeFood(7);
        ConsumeWater(7);
        UpdateConsumerTxt(); 
    }
}
