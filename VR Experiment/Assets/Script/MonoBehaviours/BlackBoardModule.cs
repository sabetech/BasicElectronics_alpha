using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoardModule : MonoBehaviour
{
    public GameObject[] boardContent;
    string[] componentsOnTable = { "Diode", "Switch", "2V Bulb" };
    public string currentResponseExpected = "";
    GameObject previousBoard;
    public int content_stage = 0;

    public static BlackBoardModule instance;

    public static BlackBoardModule getInstance()
    {
        if (instance == null)
        {
            return new BlackBoardModule();
        }
        else
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
    }

    //In the beginning, everything is inactive ...
    // Start is called before the first frame update
    void Start()
    {
        //boardContent[content_stage].SetActive(true);
        //previousBoard = boardContent[content_stage];
        
    }

    /*
    public void nextDemo()
    {
        content_stage++;
        if (content_stage == 1)
        {
            content_stage++;
        }
        previousBoard.SetActive(false);
        boardContent[content_stage].SetActive(true);

        //the stage where you loop to put all items on table ...
        if (content_stage == 1)
        {
            string textmeshtext = "Point to the " + componentsOnTable[0] + " in the circuit";
            boardContent[1].GetComponentInChildren<TextMesh>().text = textmeshtext;

            textmeshtext = "Point to the " + componentsOnTable[1] + " in the circuit";
            textmeshtext = "Point to the " + componentsOnTable[2] + " in the circuit";
        }

        if (content_stage == 3)
        {
            StartCoroutine(showNextAfter2Secs());
        }


        if (content_stage == 4)
        {
            //put rings around the active positions ...
            //Transform batterypos, switchPos, diodePoc, bulb;
            //batterypos = GameObject.Find("BatteryActive_pos").transform;

            //at this point ... 
            

        }
        
        previousBoard = boardContent[content_stage];
    }

    IEnumerator showNextAfter2Secs()
    {
        yield return new WaitForSeconds(2);
        showNextButton();
    }

    public void showNextButton()
    {
        //show the next button ...
        GameObject nextButton = GameObject.Find("ClickForNext");
        MeshRenderer[] meshrenderers = nextButton.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mr in meshrenderers)
        {
            mr.enabled = true;
        }
    }

    public void hideNextButton()
    {
        //hide Next button ...
        GameObject nextButton = GameObject.Find("ClickForNext");
        MeshRenderer[] meshrenderers = nextButton.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mr in meshrenderers)
        {
            mr.enabled = false;
        }
    }

    public void clickOnWhichCompoent(GameObject buttonComponent)
    {
        //hide the previous board content and show next board back and forth ...
        boardContent[0].SetActive(false);
        boardContent[1].SetActive(true);
        //what object are you expect the user to click on ...
        if (buttonComponent.name == "btn_light_bulb_q1")
        {
            currentResponseExpected = ElectricalCircuitBuildingModule.LIGHTBULB;
        }

        if (buttonComponent.name == "btn_switch_q1")
        {
            currentResponseExpected = ElectricalCircuitBuildingModule.LIGHTSWITCH;
        }

        if (buttonComponent.name == "btn_diode_q1")
        {
            currentResponseExpected = ElectricalCircuitBuildingModule.DIODE;
        }

        if (buttonComponent.name == "btn_wire_q1")
        {
            currentResponseExpected = ElectricalCircuitBuildingModule.WIRE;
        }

        string textmeshtext = "Point to the " + currentResponseExpected + " in the circuit";
        boardContent[1].GetComponentInChildren<TextMesh>().text = textmeshtext;
        

        
    }

    public void getBacktoBoardContent1()
    {
        //hide the previous board content and show next board back and forth ...
        boardContent[0].SetActive(true);
        boardContent[1].SetActive(false);




    }
   */
}
