using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalComponent : MonoBehaviour
{
    public Transform activeTransform;

    public enum ComponentState
    {
        active,
        inactive
    }

    public ComponentState componentState = ComponentState.inactive;

    //you need to know where to go when you are clicked on ...
    public void actionPerformedOnClick()
    {
        /*
        Debug.Log("Electrical component clicked "+ this.gameObject.name);
        //transform.position = activeTransform.position;
        //transform.localRotation = activeTransform.localRotation;

        if (gameObject.name == ElectricalCircuitBuildingModule.BATTERY + "(Clone)")
        {
            GetComponent<Battery>().actionPerformedOnClick();
        }

        if (gameObject.name ==  ElectricalCircuitBuildingModule.LIGHTSWITCH + "(Clone)")
        {
          // GetComponent<LightSwitch>().actionPerformedOnClick();
        }

        if (gameObject.name == ElectricalCircuitBuildingModule.DIODE + "(Clone)")
        {
            GetComponent<Diode>().actionPerformedOnClick();
        }

        //check which stage u at ...
        if (BlackBoardModule.getInstance().content_stage == 0)
        {

            //what is expected ...
            bool isCorrect = false;
            if (this.gameObject.name == BlackBoardModule.getInstance().currentResponseExpected+"(Clone)")
            {
                //correct ...
                isCorrect = true;
                
            }

            if (this.gameObject.name == BlackBoardModule.getInstance().currentResponseExpected)
            {
                //correct ...
                isCorrect = true;

            }

            if (isCorrect == true)
            {
                BlackBoardModule.getInstance().getBacktoBoardContent1();
            }
            else
            {
                ElectricalCircuitBuildingModule.getInstance().textInfo.text = "Try Again";
            }
            
        }


        //componentState = ComponentState.active;
        */
        
    }

    public void actionPerformedOnHover()
    {
        //Debug.Log("Do you get Hovered on?");
    }

    public void actionPerformedOnHoverOff()
    {
        //Debug.Log("Do I get Hovered off");
    }




        /*
        public Transform[] workspacePositions;
        public enum ComponentActiveStates{
            inactive,
            active
        }
        public ComponentActiveStates componentActiveState = ComponentActiveStates.inactive;

        public enum Connection_Statuses{
            not_connected,
            is_connecting,
            connected
        }

        public Connection_Statuses connection_status;  


        private bool positiveConnected = false;
        private bool negativeConnected = false;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // if (Connection_Statuses.is_connecting == connection_status){

            // }
        }

        void OnGUI(){

        }


        public void actionPerformedOnClick(){

            //if the object is inactive, send the object to the board ...
            if (componentActiveState == ComponentActiveStates.inactive){
                Debug.Log("Send to the Board");

                transform.position = this.workspacePositions[0].position;
                this.componentActiveState = ComponentActiveStates.active;

            }

        }

        public void actionPerformedOnHover(){
            //Debug.Log("I am hovering on an Electrical Component called "+gameObject.name);



            if (this.componentActiveState == ComponentActiveStates.inactive){



                // GameObject textInfoObject = GameObject.Find("TextInfo");
                // TextMesh tmInfo = textInfoObject.GetComponent<TextMesh>();
                // tmInfo.text = this.gameObject.name + "\nClick to Place on Table";

            }

        }

        public void actionPerformedOnHoverOff(){

            //Debug.Log("I am hovering on an Electrical Component called "+gameObject.name);

            if (this.componentActiveState == ComponentActiveStates.inactive){

                // GameObject textInfoObject = GameObject.Find("TextInfo");
                // TextMesh tmInfo = textInfoObject.GetComponent<TextMesh>();
                // tmInfo.text = "";

            }

        }
    */
    }
