using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class MenuUIScript : MonoBehaviour {

    public GameObject StartTxt;
    public GameObject QuitTxt; 
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        StartTxt.GetComponent<Text>().color = Color.yellow; 
        Application.LoadLevel("RyanTestScene01"); 
    }

    public void ExitGame()
    {
        QuitTxt.GetComponent<Text>().color = Color.yellow;
        Application.Quit(); 
    }
}
