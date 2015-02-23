using UnityEngine;
using System.Collections;

public class CameraLerpScript : MonoBehaviour {

    public GameObject targetPoint;
    public GameObject MainLerpPoint;
    public bool isLerpin = false;
    public float LerpTimer = 0.0f;
    public float LerpsUpTime = 1.5f; 
    public float speed = 3.0F;
    private float startTime;
    private float journeyLength;
    public float smooth = 3.0F;
    
    // Use this for initialization
	void Start () {
        targetPoint = MainLerpPoint;
	}
	
	// Update is called once per frame
	void Update () {
        if(isLerpin)
        {
            SelectRoom(targetPoint);
            LerpTimer += Time.deltaTime; 
            if(LerpTimer >= LerpsUpTime)
            {
                endLerp();
            }
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            targetPoint = MainLerpPoint;
            isLerpin = true;
            LerpTimer = 0.0f; 
        }
	}

    public void SelectRoom(GameObject RoomCenter)
    {
        PositionLerp(RoomCenter);
    }

    public void PositionLerp(GameObject NewTarget)
    {
        transform.position = Vector3.Lerp(transform.position, NewTarget.transform.position, smooth*Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, NewTarget.transform.rotation, Time.deltaTime * speed);
    }
    public void endLerp()
    {
        isLerpin = false; 
    }
}
