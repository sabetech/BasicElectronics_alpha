using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    #region Events

    public static UnityAction OnTouchpadUp = null;
    public static UnityAction OnTouchpadDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> OnControllerSource = null;


    #endregion

    #region Anchors
    public GameObject m_LeftAnchor;
    public GameObject m_RightAnchor;
    public GameObject m_HeadAnchor;

    #endregion

    #region Input
    private Dictionary<OVRInput.Controller, GameObject> m_ControllerSets = null;
    private OVRInput.Controller m_InputSource = OVRInput.Controller.None;
    private OVRInput.Controller m_Controller = OVRInput.Controller.None;
    private bool m_InputActive = true;

    #endregion


    private void Awake(){
        
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

        m_ControllerSets = CreateControllerSets();
    }  

    private void OnDestroy(){

    }

    
    
    
    private void Update()
    {

        if (!m_InputActive)
            return;

        CheckForController();

        //check for active input
        CheckInputSource();

        //check if controller exist    
        Input();
    }

    private void CheckForController(){
        OVRInput.Controller controllerCheck = m_Controller;

        // Right Remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote)){
            controllerCheck = OVRInput.Controller.RTrackedRemote;
        }

        // Left Remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote)){
            controllerCheck = OVRInput.Controller.LTrackedRemote;
        }

        // If no contrller then headset
        if (! OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) &&
            ! OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote)){
            controllerCheck = OVRInput.Controller.Touchpad;
        }

        // update
        m_Controller  = UpdateSource(controllerCheck, m_Controller);



    }
    private void CheckInputSource(){

        m_InputSource = UpdateSource(OVRInput.GetActiveController(), m_InputSource);


    }

    private void Input(){

        // touchpad down
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
            if (OnTouchpadDown != null){
                OnTouchpadDown();
            }
        }

        // touchpad up
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)){
            if (OnTouchpadUp != null){
                OnTouchpadUp();
            }
        }

    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous){

        // if values are the same ...
        if (check == previous){
            return previous;
        }

        // get controller object ...
        GameObject controllerObject = null;
        m_ControllerSets.TryGetValue(check, out controllerObject);

        // if no controller, set to headset
        if (controllerObject == null){
            controllerObject = m_HeadAnchor;
        }

        // send out event
        if (OnControllerSource != null){
            OnControllerSource(check, controllerObject);
        }
        //return new value
        return check;
    }

    private void PlayerFound(){
        m_InputActive = true;
    }

    private void PlayerLost(){
        m_InputActive = false;
    }

    private Dictionary<OVRInput.Controller, GameObject> CreateControllerSets(){
        Dictionary<OVRInput.Controller, GameObject> newsets = new Dictionary<OVRInput.Controller, GameObject>(){
            { OVRInput.Controller.LTrackedRemote, m_LeftAnchor },
            { OVRInput.Controller.RTrackedRemote, m_RightAnchor },
            { OVRInput.Controller.Touchpad, m_HeadAnchor } 
        };
        return newsets;
    }








}
