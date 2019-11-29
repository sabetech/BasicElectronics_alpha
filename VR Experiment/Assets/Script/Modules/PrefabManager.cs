using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PrefabManager : MonoBehaviour
{
    public GameObject titlePrefab;
    public GameObject infoPrefab;
    public GameObject video2D;
    public GameObject mcq_regular;
    public GameObject mcq_SATA;
    public GameObject mcq_TrueFalse;

    public static PrefabManager instance;
    public static PrefabManager getInstance()
    {
        if (instance == null)
        {
            return new PrefabManager();
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

    public void callSomeFunction()
    {
        Debug.Log("Some sample function from prefab manager has been called");
    }

    public void showTitle(string titleMain, 
                          string unitTitle, 
                          string unitDescription
                         ) 
    {
        if (titlePrefab != null)
        {
            GameObject lessonname = titlePrefab.transform.GetChild(0).gameObject;
            lessonname.GetComponent<TextMesh>().text = titleMain;
        
            GameObject unit_title = titlePrefab.transform.GetChild(1).gameObject;
            unit_title.GetComponent<TextMesh>().text = unitTitle;

            GameObject unit_description = titlePrefab.transform.GetChild(2).gameObject;
            unit_description.GetComponent<TextMesh>().text = unitDescription;

            Instantiate(titlePrefab);
        }
        else
        {
            Debug.Log("Title Prefab does exist??");
        }

    }

}

