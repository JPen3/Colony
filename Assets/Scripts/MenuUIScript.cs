using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class MenuUIScript : MonoBehaviour {

    public GameObject StartTxt;
    public GameObject QuitTxt;
    public GameObject CreditsTxt; 

    public GameObject CreditsPanel;
    public GameObject StartScreenPanel;
    
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

    public void OpenCredits()
    {
        CreditsTxt.GetComponent<Text>().color = Color.yellow; 
        StartScreenPanel.SetActive(false);
        CreditsPanel.SetActive(true); 
    }

    public void BackFromCredits()
    {
        CreditsTxt.GetComponent<Text>().color = Color.white; 
        StartScreenPanel.SetActive(true);
        CreditsPanel.SetActive(false); 
    }
}
