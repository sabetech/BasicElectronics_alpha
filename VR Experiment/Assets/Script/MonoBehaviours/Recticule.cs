using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recticule : MonoBehaviour
{
    public Pointer m_Pointer;
    public SpriteRenderer m_CircleRenderer;

    public Sprite m_OpenSprite;
    public Sprite m_ClosedSprite;

    private Camera m_Camera = null;

    //reticle can display the names of the items on the board ...
    private void Awake(){
        m_Pointer.OnPointerUpdate += UpdateSprite;
        m_Camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_Camera.gameObject.transform);
    }

    private void OnDestory(){
        m_Pointer.OnPointerUpdate -= UpdateSprite;
    }

    public void UpdateSprite(Vector3 point, GameObject hitObject){
        transform.position = point;
        if (hitObject){
            m_CircleRenderer.sprite = m_ClosedSprite;
        }else{
            m_CircleRenderer.sprite = m_OpenSprite;
        }
    }

    // public void UpdateOnHoverText(Vector3 point, GameObject hitObject){
        
    // }
}
