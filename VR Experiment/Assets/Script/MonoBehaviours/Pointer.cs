using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pointer : MonoBehaviour
{   
    public float m_Distance = 1000.0f;
    public LineRenderer m_LineRender = null;
    public LayerMask m_EverythingMask = 0;
    public LayerMask m_InteractableMask = 0;

    private Transform m_CurrentOrigin = null;

    public UnityAction<Vector3, GameObject> OnPointerUpdate = null;
    private GameObject m_CurrentObject = null;
    private GameObject m_PrevObject = null;

    private void Awake(){
        PlayerEvents.OnControllerSource += UpdateOrigin;
        PlayerEvents.OnTouchpadDown += ProcessTouchDown;
    }

    private void Start(){
        SetLineColor();
    }

    private void Update() {
        
        Vector3 hitPoint = UpdateLine();
        //Terminal.currentCursorHitPoint = hitPoint;

        m_CurrentObject = UpdatePointerStatus();
        if (OnPointerUpdate != null){
            ProcessHoverOn();
            OnPointerUpdate(hitPoint, m_CurrentObject);

            if(m_CurrentObject != m_PrevObject) {
                ProcessHoverOff();
                m_PrevObject = m_CurrentObject;
            }

        }

    }

    private void OnDestroy(){
        PlayerEvents.OnControllerSource -= UpdateOrigin;
        PlayerEvents.OnTouchpadDown -= ProcessTouchDown;
    }

    private void UpdateOrigin(OVRInput.Controller controller, GameObject controllerObject){
        //set origin of pointer 
        m_CurrentOrigin = controllerObject.transform;

        //is laser visible
        if (controller == OVRInput.Controller.Touchpad){
            m_LineRender.enabled = false;
        }else{
            m_LineRender.enabled = true;
        }

        //
    }

    private GameObject UpdatePointerStatus(){
        //create a ray
        RaycastHit hit = CreateRaycast(m_InteractableMask);

        //check the hit
        if (hit.collider){
            return hit.collider.gameObject;
        }

        return null;
    }

    private Vector3 UpdateLine(){

        // create ray ...
        RaycastHit hit =  CreateRaycast(m_EverythingMask);

        // Default end
        Vector3 endPosition = m_CurrentOrigin.position + (m_CurrentOrigin.forward * m_Distance);

        // chcekc hit
        if (hit.collider != null){
            endPosition = hit.point;
        }

        //set position
        m_LineRender.SetPosition(0, m_CurrentOrigin.position);
        m_LineRender.SetPosition(1, endPosition);


        return endPosition;
    }

    private RaycastHit CreateRaycast(int layer){
        RaycastHit hit;
        Ray ray = new Ray(m_CurrentOrigin.position, m_CurrentOrigin.forward);

        Physics.Raycast(ray, out hit, m_Distance, layer);
        
        return hit;
    }

    private void SetLineColor(){
        if (! m_LineRender)
            return;

        Color endColor = Color.white;
        endColor.a = 0.0f;

        m_LineRender.endColor = endColor;

    }

    private void ProcessTouchDown(){

        if (!m_CurrentObject)
            return;
        
        Interactable interactable =  m_CurrentObject.GetComponent<Interactable>();
        interactable.Pressed();
    }

    private void ProcessHoverOn(){
        //if the object hovered on is not interactable , ignore
        if (!m_CurrentObject)
            return;

        Interactable interactable =  m_CurrentObject.GetComponent<Interactable>();
        interactable.Hovered();

    }

    private void ProcessHoverOff(){
        if (!m_PrevObject)
            return;

        //Debug.Log("Hovered off "+m_PrevObject.name);
        Interactable interactable =  m_PrevObject.GetComponent<Interactable>();
        interactable.HoveredOff();
    }


}
