using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class CanvasScaleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("Screen Width: " + Screen.width + " Screen Height: " + Screen.height); 
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        this.GetComponent<RectTransform>().anchoredPosition3D = new Vector3((float)0, (float)0, (float)Screen.height / 235); 
	}
}
