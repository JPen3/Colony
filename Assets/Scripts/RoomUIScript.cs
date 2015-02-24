using UnityEngine;
using System.Collections;

public class RoomUIScript : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject ResourcesPanel; 
    public GameObject ResourcesSendPanel;
    public GameObject ResourcesSendCountTxt; 
    public GameObject MaterialSendPanel;
    public GameObject MaterialSendCountTxt; 

    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackToTop()
    {
        MainCamera.GetComponent<CameraLerpScript>().back2Top();
    }

    public void SelectResources()
    {
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel.SetActive(false);
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = ResourcesSendPanel;
        ResourcesSendPanel.SetActive(true);

    }

    public void Back2ResourcesPanel()
    {
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel.SetActive(false);
        MainCamera.GetComponent<CameraLerpScript>().CurrentUIPanel = ResourcesPanel;
        ResourcesPanel.SetActive(true);
    }
}
