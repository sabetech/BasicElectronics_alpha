using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Terminal : MonoBehaviour
{

    public GameObject ringSelector;
    private GameObject cloneRingSelector;

    private ElectricalComponent electricalComponent;

    void Start()
    {
        electricalComponent = GetComponentInParent<ElectricalComponent>();
    }

    public void actionPerformedOnHover()
    {
        //put a ring around the positive side
        

        if (transform.parent.gameObject.name != ElectricalCircuitBuildingModule.BATTERY+"(Clone)") return;

        if (electricalComponent.componentState == ElectricalComponent.ComponentState.active)
        {
            if (cloneRingSelector == null)
                cloneRingSelector = Instantiate(ringSelector, transform.position, Quaternion.identity) as GameObject;
        }
        

    }

    public void actionPerformedOnHoverOff()
    {
        //remove ring ...
        if (cloneRingSelector != null)
        {
            Destroy(cloneRingSelector);
        }
    }

    public void actionPerformedOnClick()
    {

        //connect a line renderer from here to the end ...
        //the idea is that all the component must be on the board before you connect the wire ...

        //for demonstration 1 ...
        //get wire path ...

        //if switch state is active and its ON
        if (transform.parent.GetComponent<ElectricalComponent>().componentState == ElectricalComponent.ComponentState.active)
        {
            ElectricalCircuitBuildingModule.getInstance().createWireLoop();
        }

    }

    //LineRenderer wireLineRenderer;
    //public void createWire()
    //{
    //    

    //}

    




    /*
    public GameObject ringSelector;
    ElectricalComponent electricalComponent;
    enum TerminalConnectionStates
    {
        notConnected,
        isConnecting,
        isConnected
    }

    public enum TerminalValue{
        positive,
        negative
    }

    public TerminalValue terminalValue;
    public static Vector3 currentCursorHitPoint;

    TerminalConnectionStates terminalState = TerminalConnectionStates.notConnected;

    private LineRenderer wireLineRenderer;
    private const int MAX_POINTS = 8;
    private bool isWireConnected = false;
    private int vertexCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        electricalComponent = GetComponentInParent<ElectricalComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(electricalComponent.componentActiveState == ElectricalComponent.ComponentActiveStates.active)
        //    if (electricalComponent.connection_status == ElectricalComponent.Connection_Statuses.is_connecting) {
        
        //    // try{
        //    //     Debug.Log("Distance between current point and new point "+Vector3.Distance(currentCursorHitPoint, wireLineRenderer.GetPosition(vertexCount - 1)));
        //    //     if (Vector3.Distance(currentCursorHitPoint, wireLineRenderer.GetPosition(this.vertexCount - 1)) > 25f) {
        //    //         return;
        //    //     }

        //    //     if (Vector3.Distance(currentCursorHitPoint, wireLineRenderer.GetPosition(this.vertexCount - 1)) > 0.5f) {
                    
        //    //         wireLineRenderer.positionCount++;
        //    //         wireLineRenderer.SetPosition(this.vertexCount++, currentCursorHitPoint);

        //    //     }
        //    // }catch(NullReferenceException e){
        //    //     //Debug.Log(e.ToString());
        //    // }

        //    }
    }   

    public void actionPerformedOnClick(){
        //based on the state of the electrical component ...

        if ( electricalComponentActive() ) {
            //create the line component and start doing the line magic you had ...

            if (electricalComponent.connection_status == ElectricalComponent.Connection_Statuses.is_connecting){
                //currentCursorHitPoint
                this.createWire();
                this.initiateWireConnection();
                this.completeWireConnection();
                closeWireConnection();
           

                StartCoroutine(clearFirstDemostration());

            }
            
            if (! this.isTerminalConnected()) {
                
                this.terminalState = TerminalConnectionStates.isConnecting;
                electricalComponent.connection_status = ElectricalComponent.Connection_Statuses.is_connecting;
                
                previouslyHoveredOffTerminal = this.gameObject;

            }   
        }
    }

    GameObject myGameobject;
    public void actionPerformedOnHover(){
        
        if (electricalComponentActive()){
            if (this.myGameobject == null){
                this.myGameobject = Instantiate(ringSelector, this.transform.position, Quaternion.identity) as GameObject;
            }else{
                this.myGameobject.SetActive(true);
            }
        }else
        {
            this.myGameobject.SetActive(true);
        }

    }

    IEnumerator clearFirstDemostration()
    {
        yield return new WaitForSeconds(3);
        //wait for 3 secs and then remove everything from screen
        //send battery to original position and remove line renderer and set state to not active and not connected
        GameObject TextInfo = GameObject.Find("TextInfo");
        TextMesh myTextInfo = TextInfo.GetComponent<TextMesh>();

        myTextInfo.text = "Battery Overheating... Explodes!";

        yield return new WaitForSeconds(3);

        GameObject battery = this.transform.parent.gameObject;
        battery.transform.position = GameObject.Find("battery_home").transform.position;
        myTextInfo.text = "";
        Destroy(wireLineRenderer);

        electricalComponent.componentActiveState = ElectricalComponent.ComponentActiveStates.inactive;
        electricalComponent.connection_status = ElectricalComponent.Connection_Statuses.not_connected;

        this.terminalState = TerminalConnectionStates.notConnected;
        previouslyHoveredOffTerminal.GetComponent<Terminal>().terminalState = TerminalConnectionStates.notConnected;

        //get all terminals and reset them
        GameObject[] terminals = GameObject.FindGameObjectsWithTag("Terminal");
        foreach(GameObject terminal in terminals)
        {
            terminal.GetComponent<Terminal>().terminalState = TerminalConnectionStates.notConnected;
        }

        yield return new WaitForSeconds(2);
        myTextInfo.text = "Begin Demostration 2";
        yield return new WaitForSeconds(2);
        myTextInfo.text = "";

        //show the switch component ...
        GameObject switchComponent1 = GameObject.Find("LightSwitch");
        MeshRenderer[] meshRenderers = switchComponent1.GetComponentsInChildren<MeshRenderer>();

        

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.enabled = true;
        }
        
    }

    public Boolean electricalComponentActive(){
        return ElectricalComponent.ComponentActiveStates.active == electricalComponent.componentActiveState;
    }

    public Boolean isTerminalConnected(){
        return this.terminalState == TerminalConnectionStates.isConnected;
    }

    public Boolean isTerminalConnecting(){
        return this.terminalState == TerminalConnectionStates.isConnecting;
    }

    static GameObject previouslyHoveredOffTerminal = null;
    public void actionPerformedOnHoverOff() {
        if (electricalComponentActive()) {
            if (! this.isTerminalConnecting()) {
                if (this.myGameobject != null) {
                    this.myGameobject.SetActive(false);
                }
            }
        }
        
        if (!electricalComponentActive())
        {
            if (this.myGameobject != null)
            {
                this.myGameobject.SetActive(false);
            }
        }

    }

    void createWire(){
        Color c1 = Color.red;
        Color c2 = Color.blue;

        wireLineRenderer = gameObject.AddComponent<LineRenderer>();
        wireLineRenderer.loop = false;
        wireLineRenderer.material = new Material(Shader.Find("Standard"));
        wireLineRenderer.startColor = c1;
        wireLineRenderer.endColor = c2;
        wireLineRenderer.startWidth = 0.25f;
        wireLineRenderer.endWidth = 0.2f;
        
        this.isWireConnected = true; 

    }

    //Start a wire connection from the clicked terminal
    public void initiateWireConnection(){  
        
        electricalComponent.connection_status = ElectricalComponent.Connection_Statuses.is_connecting;

        //Debug.Log("What is position count "+wireLineRenderer.positionCount);
        wireLineRenderer.positionCount = 5;
        wireLineRenderer.SetPosition(0,
                                new Vector3(previouslyHoveredOffTerminal.transform.position.x, 
                                            previouslyHoveredOffTerminal.transform.position.y, 
                                            previouslyHoveredOffTerminal.transform.position.z)
                                    );
        
        wireLineRenderer.SetPosition(1,
                                new Vector3(previouslyHoveredOffTerminal.transform.position.x, 
                                            previouslyHoveredOffTerminal.transform.position.y, 
                                            previouslyHoveredOffTerminal.transform.position.z + 2f)
                                    );

        wireLineRenderer.SetPosition(2,
                                new Vector3(previouslyHoveredOffTerminal.transform.position.x + 2f, 
                                            previouslyHoveredOffTerminal.transform.position.y, 
                                            previouslyHoveredOffTerminal.transform.position.z)
                                    );

        wireLineRenderer.SetPosition(3,
                                new Vector3(previouslyHoveredOffTerminal.transform.position.x + 2f, 
                                            previouslyHoveredOffTerminal.transform.position.y, 
                                            previouslyHoveredOffTerminal.transform.position.z - 4f)
                                  );
        

        //

    }

    public void completeWireConnection(){

        wireLineRenderer.SetPosition(4, currentCursorHitPoint);
        previouslyHoveredOffTerminal.GetComponent<Terminal>().myGameobject.SetActive(false);   

    }

    public void closeWireConnection(){

        //if the initial connection is the object itself, then its connected else unless you have a looped connection its not connected
        if (previouslyHoveredOffTerminal.transform.parent.gameObject.name == this.gameObject.name)
        {
            terminalState = TerminalConnectionStates.isConnected;
            electricalComponent.connection_status = ElectricalComponent.Connection_Statuses.connected;

            //connection complete!!!
            GameObject TextInfo = GameObject.Find("TextInfo");
            TextMesh myTextInfo = TextInfo.GetComponent<TextMesh>();

            myTextInfo.text = "Connected!";
        }
        else
        {




        }
        
        

        
    }

    public void cancelWireConnection(){
        
    }

*/
}
