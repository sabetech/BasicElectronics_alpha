 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{   
    /*
        There are different types of interactable ... 
        - Table
        - Electrical Component like Battery, Bulb Etc
        - Wire?
        - Terminals are interactable
     */
     
     private Camera m_Camera = null;

    private void Awake(){
        m_Camera = Camera.main;
    }
    private void OnDestroy(){
        
    }

    private void Start() {
        
    }

    public void Pressed() {
        // Do action here ...   
        //find what was pressed actually ...

        GameObject objectPressed = this.gameObject;

        switch(objectPressed.tag){
            case "ElectricalComponent":
            
                ElectricalComponent electricComponent =  objectPressed.GetComponent<ElectricalComponent>();
                electricComponent.actionPerformedOnClick();
            
            break;
            
            case "Terminal":
                
                Terminal terminal = objectPressed.GetComponent<Terminal>();
                //terminal.actionPerformedOnClick(); remember to uncomment this back ..
            
            break;

            case "Switch":
                
                if (BlackBoardModule.getInstance().content_stage == 0)
                {
                    LightSwitch lightSwitch = gameObject.GetComponent<LightSwitch>();
                    lightSwitch.actionPerformedOnClick();
                }
                

            break;

            case "Position":
                /*
                if (BlackBoardModule.getInstance().content_stage == 4)
                {
                    //GameObject responseText = GameObject.Find("response_text");
                    //responseText.SetActive(true);
                    if (this.gameObject.name == "battery_active_position")
                    {
                        ElectricalCircuitBuildingModule.getInstance().textInfo.text = "Correct, we can place a battery there";
                        BlackBoardModule.getInstance().showNextButton();
                    }
                    else
                    {
                        ElectricalCircuitBuildingModule.getInstance().textInfo.text = "Incorrect, a component is already there";
                    }
                }

                if (BlackBoardModule.getInstance().content_stage == 5)
                {

                    if (this.gameObject.name == "battery_active_position")
                    {

                        ClickToAddBatteryToPosition position = objectPressed.GetComponent<ClickToAddBatteryToPosition>();
                        position.addToPosition();

                    }

                }
                */
                break;

            case "ButtonInteraction":
                
                //NextDemo nextDemo = objectPressed.GetComponent<NextDemo>();
                //nextDemo.actionPerformedClick();

                ButtonClick btnClicked = objectPressed.GetComponent<ButtonClick>();
                btnClicked.actionPerformedClick();

                break;
        }
        

    }   

    public void Hovered() {

        //determine what was hovered on ...

        //do something based on the object and the state of it
        GameObject objectPressed = this.gameObject;
        switch(objectPressed.tag){
            case "ElectricalComponent":
                
                ElectricalComponent electricComponent =  objectPressed.GetComponent<ElectricalComponent>();
                electricComponent.actionPerformedOnHover();
                
            break;
            
            case "Terminal":
                
                Terminal terminal = objectPressed.GetComponent<Terminal>();
                terminal.actionPerformedOnHover();
                
            break;
        }
        
    }

    public void HoveredOff() {
        
        //Debug.Log("game object off hover "+ this.gameObject.name);
        GameObject objectPressed = this.gameObject;
        switch(objectPressed.tag){
            case "ElectricalComponent":
                
                ElectricalComponent electricComponent =  objectPressed.GetComponent<ElectricalComponent>();
                electricComponent.actionPerformedOnHoverOff();
                
            break;
            
            case "Terminal":
                
                Terminal terminal = objectPressed.GetComponent<Terminal>();
                terminal.actionPerformedOnHoverOff();
                
            break;
        }

    }


}
