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
        ColNumTxt.GetComponent<Text>().text = ":" + ColonyController.GetComponent<ColonyControllerScript>().ColonistCount.ToString();
        FoodNumTxt.GetComponent<Text>().text = ":" + ConsumerController.GetComponent<ConsumptionScript>().ColFoodInt.ToString();
        WaterNumTxt.GetComponent<Text>().text = ":" + ConsumerController.GetComponent<ConsumptionScript>().ColWaterInt.ToString();
        //WeekTxt.GetComponent<Text>().text = WeekObj.GetComponent<DayPropScript>().DayInt.ToString(); 
    }
}
