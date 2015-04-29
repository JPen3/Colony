using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class UserNoteScript : MonoBehaviour {

    public static string UserNote;
    public static bool updateNote = false; 
    public GameObject NoteTxt;

    public GameObject JournalWeekTxt; 
    public GameObject JournalNoteTxt;
    public ArrayList JournalNotes = new ArrayList();  
    public int DisplayWeekInt; 
    
    // Use this for initialization
	void Start () {
        //UserNote = "-User Note \n-UserNote";
        JournalNotes.Add("None...YET!!!");
        print("Journal 0: " + JournalNotes[0]); 
         
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
        //JournalNotes.Add(UserNote);
        //print("List " + JournalNotes[0]); 
    }

    public void WriteJournal()
    {
        JournalNotes.Add(UserNote);
    }

    public void DisplayJournalEntry()
    {
        JournalWeekTxt.GetComponent<Text>().text = ""; 
        JournalNoteTxt.GetComponent<Text>().text = JournalNotes[DisplayWeekInt].ToString();
        JournalWeekTxt.GetComponent<Text>().text = "Journal Week: " + DisplayWeekInt.ToString(); 
    }
}
