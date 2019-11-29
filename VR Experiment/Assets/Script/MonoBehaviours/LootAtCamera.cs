using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootAtCamera : MonoBehaviour
{
    // Start is called before the first frame update
    Transform m_Camera;
    void Awake()
    {
        m_Camera = Camera.main.transform;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(m_Camera);
        
    }
}
