using UnityEngine;
using System.Collections;

public class MenuUIScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        Application.LoadLevel("TestRoomSelect"); 
    }

    public void ExitGame()
    {
        Application.Quit(); 
    }
}
