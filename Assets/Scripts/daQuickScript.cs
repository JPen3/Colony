using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class daQuickScript : MonoBehaviour {

    public GameObject ColonyController;
    public GameObject ConsumerController;
    public GameObject WeekObj; 

    public GameObject ColNumTxt;
    public GameObject FoodNumTxt;
    public GameObject WaterNumTxt;
    public GameObject WoodNumTxt;
    //public GameObject WeekTxt; 

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        updateDaQuick(); 
	}

    public void updateDaQuick()
    {
        ColNumTxt.GetComponent<Text>().text = ": " + ColonyController.GetComponent<ColonyControllerScript>().ColonistCount.ToString();
        FoodNumTxt.GetComponent<Text>().text = ((int)(ConsumerController.GetComponent<ConsumptionScript>().ColFoodInt / ConsumerController.GetComponent<ConsumptionScript>().ConFoodInt)).ToString();
        WaterNumTxt.GetComponent<Text>().text = ((int)(ConsumerController.GetComponent<ConsumptionScript>().ColWaterInt / ConsumerController.GetComponent<ConsumptionScript>().ConWaterInt)).ToString();
        //WeekTxt.GetComponent<Text>().text = WeekObj.GetComponent<DayPropScript>().DayInt.ToString(); 
    }
}
