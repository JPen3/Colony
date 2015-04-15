using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class UserNoteScript : MonoBehaviour {

    public static string UserNote;
    public static bool updateNote = false; 
    public GameObject NoteTxt; 
    
    // Use this for initialization
	void Start () {
        //UserNote = "-User Note \n-UserNote";
         
	}
	
	// Update is called once per frame
	void Update () {
	    if(updateNote)
        {
            updateNote = false; 
            SendNote();
            print("Note Sent"); 
        }
	}

    public void SendNote()
    {
        NoteTxt.GetComponent<Text>().text = UserNote;
        print(UserNote); 
    }
}
