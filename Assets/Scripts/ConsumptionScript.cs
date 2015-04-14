using UnityEngine;
using System.Collections;

public class ConsumptionScript : MonoBehaviour {

    public GameObject ColonyController;
    public GameObject ColFoodTxt;
    public GameObject ColWaterTxt; 

    public int ColFoodInt;
    public int ColWaterInt; 

    public int ColonistFoodConsumeINT;
    public int ColonistWaterConsumeINT; 
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ConsumeWater(int days)
    {
        ColWaterInt -= ColonistWaterConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistCount; 

    }

    public void ConsumeFood(int days)
    {
        ColFoodInt -= ColonistFoodConsumeINT * days * ColonyController.GetComponent<ColonyControllerScript>().ColonistCount; 
    }
}
