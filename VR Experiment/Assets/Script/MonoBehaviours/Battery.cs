using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public bool flipped = false;
    public bool isActive = false;
    float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (! isActive)
            transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, 0f);
    }

    /*
    public void actionPerformedOnClick()
    {
        Debug.Log("content stage " + BlackBoardModule.getInstance().content_stage);
        if (BlackBoardModule.getInstance().content_stage == 5)
        {
            //the ring around that guy  and a click on that board brings the battery ...
            GameObject ringSelector = GameObject.Find("RingSelector");
            ringSelector.GetComponent<Renderer>().enabled = true;
            
        }
    }

    public void moveToPosition()
    {
        ///move the battery to the board ...
        transform.position = ElectricalCircuitBuildingModule.getInstance().activePositions[0].position;
        transform.rotation = ElectricalCircuitBuildingModule.getInstance().activePositions[0].rotation;

        GameObject ringSelector = GameObject.Find("RingSelector");
        ringSelector.GetComponent<Renderer>().enabled = false;
        isActive = true;
        BlackBoardModule.getInstance().showNextButton();

    }

    float zAxis = 180f;
    public void flipBattery()
    {
        //flip only if battery is active ...
        flipped = !flipped;

        zAxis = -zAxis;
        transform.Rotate(0f, 0f, zAxis, Space.Self);

        ElectricalCircuitBuildingModule.getInstance().onBatteryFlipped();

    }
    */
}
