using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Main : MonoBehaviour
{

    UnitModule unit_module;
    void Awake()
    {
        
        
    }

    void Start()
    {
        Debug.Log("Main Code has started Running...");
        unit_module = UnitModule.Instance;
        unit_module.init();
        unit_module.begin();

        //Get Users
        //authenticate with pin
        //
        //Get User's progress
        //UserModule user = UserModule.getUserInstance();




        //check the progress of the user and if there's none, start afresh.
        //sync user progress online





    }

    void Begin()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
