using UnityEngine;
using System.Collections;

public class OnRoomSelectScript : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject LerpPoint;
    
    // Use this for initialization
	void Start () {
        if (GameObject.Find("Main Camera"))
        {
            MainCamera = GameObject.Find("Main Camera");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        MainCamera.GetComponent<CameraLerpScript>().targetPoint = LerpPoint;
        MainCamera.GetComponent<CameraLerpScript>().isLerpin = true;
        MainCamera.GetComponent<CameraLerpScript>().LerpTimer = 0.0f; 
    }
}
