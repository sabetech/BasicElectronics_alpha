using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    //public string button_name;
    public GameObject responseText;

    private static int buttonCompletionCheckSum = 0;
    ElectricalCircuitBuildingModule electricalCircuitModule;
    Material correctMat, incorrectMat, hoveredMat, regularMat;
    Material correctPanel, incorrectPanel;
    /*
    void Start()
    {
        //in the future refactoring this has to be done in runtime/main.cs file
        correctMat = (Material)Resources.Load("Materials/Buttons/possible_answers_correct");
        incorrectMat = (Material)Resources.Load("Materials/Buttons/possible_answers_incorrect");
        hoveredMat = (Material)Resources.Load("Materials/Buttons/possible_answers_hovered");
        regularMat = (Material)Resources.Load("Materials/Buttons/possible_answers_regular");

        correctPanel = (Material)Resources.Load("Materials/Panels/correct_panel");
        incorrectPanel = (Material)Resources.Load("Materials/Panels/incorrect_panel");
        
    }
    */
    public void actionPerformedClick()
    {
      /*  string buttonName = this.gameObject.name;
        switch (buttonName)
        {
            case "ClickForNext":
                responseText.GetComponent<TextMesh>().text = "";
                responseText.SetActive(false);
                
                BlackBoardModule bbm = BlackBoardModule.getInstance();
                //bbm.hideNextButton();
                //bbm.nextDemo();

                return;

            case "ToggleSwitch":
                //switch clicked on ...
                //find the switch in the scene ...

                //check if battery is in there ...

                GameObject lightswitch = GameObject.Find(ElectricalCircuitBuildingModule.LIGHTSWITCH+"(Clone)");
                lightswitch.GetComponent<LightSwitch>().onSwitchToggle();

                return;

            case "flip_battery":
                if (BlackBoardModule.getInstance().content_stage >= 5)
                {
                    GameObject myBattery = GameObject.Find(ElectricalCircuitBuildingModule.BATTERY + "(Clone)");
                    //myBattery.GetComponent<Battery>().flipBattery();
                }

                return;

            case "flip_diode":

                //get the diode likewise ...
                if (BlackBoardModule.getInstance().content_stage >= 5)
                {
                    GameObject diode = GameObject.Find(ElectricalCircuitBuildingModule.DIODE+ "(Clone)");
                    diode.GetComponent<Diode>().flipDiode();

                    if (BlackBoardModule.getInstance().content_stage == 5)
                        BlackBoardModule.getInstance().showNextButton();

                }

                return;
        }


        //check to see what kinda buttons these are ...

        if (BlackBoardModule.getInstance().content_stage == 0)
        {
            if ((this.gameObject.name == "btn_resistor_q1")
            ||
           (this.gameObject.name == "btn_battery_q1"))
            {

                Renderer rend = GetComponent<Renderer>();
                Material m_Btn_mat = rend.material;
                m_Btn_mat.color = Color.red;
                
            }
            else
            {
                //get what was clicked on ...
                BlackBoardModule.getInstance().clickOnWhichCompoent(this.gameObject);

                //set color to green ...
                Renderer rend = GetComponent<Renderer>();
                Material m_Btn_mat = rend.material;
                m_Btn_mat.color = Color.green;
                buttonCompletionCheckSum++;


            }

            if (buttonCompletionCheckSum == 4)
            {
                //show the next button ...
                BlackBoardModule.getInstance().showNextButton();

            }
        }

        if (BlackBoardModule.getInstance().content_stage == 2)
        {
            responseText.SetActive(true);
            resetButtonMaterial();

            if (this.gameObject.name == "add_battery_q3")
            {

                //set the yellow correct response material to the response panel
                this.swapToCorrectMaterial();
                this.showCorrectAnswerResponse("Correct, a battery will \nprovide the current required \nto power the circuit");

                GameObject nextButton = GameObject.Find("ClickForNext");
                MeshRenderer[] meshrenderers = nextButton.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer mr in meshrenderers)
                {
                    mr.enabled = true;
                }
                BlackBoardModule.getInstance().showNextButton();
            }
            else 

            if (this.gameObject.name == "add_resistor_q3")
            {
                this.swapToIncorrectMaterial();
                this.showIncorrectAnswerResponse("Incorrect, a resistor is \nused to reduce the current \nflow in a circuit");
                
            }else

            if (this.gameObject.name == "add_capacitor_q3")
            {
                this.swapToIncorrectMaterial();
                this.showIncorrectAnswerResponse("Incorrect, a capacitor is \nused to store current flow \nin a circuit");
            }
            else
            {
                //responseText.GetComponent<TextMesh>().text = "Incorrect!";
            }
        }

        if (BlackBoardModule.getInstance().content_stage == 7)
        {
            responseText.SetActive(true);
            resetButtonMaterial();

            if (this.gameObject.name == "terminal_wrong_q8")
            {
                //set the yellow correct response material to the response panel
                this.swapToCorrectMaterial();
                this.showCorrectAnswerResponse("Correct, a battery will provide \nthe current required to power \nthe circuit");

                GameObject nextButton = GameObject.Find("ClickForNext");
                MeshRenderer[] meshrenderers = nextButton.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer mr in meshrenderers)
                {
                    mr.enabled = true;
                }

                BlackBoardModule.getInstance().showNextButton();

            }
            else
            if (this.gameObject.name == "wrong_battery_q8")
            {
                this.swapToIncorrectMaterial();
                this.showIncorrectAnswerResponse("Incorrect, a 3 volts battery generates \nenough electricity to light up \na 2 volts bulb");

            }
            else
            if (this.gameObject.name == "switch_off_q8")
            {
                this.swapToIncorrectMaterial();
                this.showIncorrectAnswerResponse("Incorrect, remember you turned on \nthe switch to activate the circuit.");
            }
        }

        if (BlackBoardModule.getInstance().content_stage == 8)
        {
            responseText.SetActive(true);
            resetButtonMaterial();

            if (this.gameObject.name == "blue_button_press_q9")
            {
                this.swapToCorrectMaterial();
                this.showCorrectAnswerResponse("Correct, flipping the terminal \nwill allow the current flow");

                BlackBoardModule.getInstance().showNextButton();
            }
            else
           if (this.gameObject.name == "removing_battery_q9")
            {
                this.swapToIncorrectMaterial();
                this.showIncorrectAnswerResponse("Incorrect, that will remove the \nsource of electrical energy");
                
            }
            else
           if (this.gameObject.name == "turn_off_switch_q9")
            {
                this.swapToIncorrectMaterial();
                this.showIncorrectAnswerResponse("Incorrect, turning off the switch\n will prevent current from flowing \nin the circuit");
            }
        }
        */
    }

    public void swapToCorrectMaterial()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = correctMat;
        
    }

    public void swapToIncorrectMaterial()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = incorrectMat;
    }

    public void resetButtonMaterial()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = regularMat;
    }

    public void showCorrectAnswerResponse(string response)
    {
        responseText.GetComponent<TextMesh>().text = response;

        GameObject responsePanel = responseText.transform.parent.gameObject;
        responsePanel.SetActive(true);
        MeshRenderer meshRenderer = responsePanel.GetComponent<MeshRenderer>();
        meshRenderer.material = correctPanel;
        
    }

   /*

    public void showIncorrectAnswerResponse(string response)
    {
        responseText.GetComponent<TextMesh>().text = response;
        GameObject responsePanel = responseText.transform.parent.gameObject;
        responsePanel.SetActive(true);
        MeshRenderer meshRenderer = responsePanel.GetComponent<MeshRenderer>();
        meshRenderer.material = incorrectPanel;

    }
    */
}
