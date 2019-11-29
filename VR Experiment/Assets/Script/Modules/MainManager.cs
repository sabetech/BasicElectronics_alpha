using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class MainManager : MonoBehaviour
{

    public static MainManager instance;
    string response;
    bool data_fetch_done = false;
    public static MainManager getInstance()
    {
        if (instance == null)
        {
            return new MainManager();
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (data_fetch_done)
        {
            //give response to the one that needs it.
            Debug.Log("response _ Ready !!!!");
            Debug.Log(response);
            data_fetch_done = false;
        }
    }

    public void getDataFromServer(string url)
    {
        StartCoroutine(getInfoFromServer(url));
    }

    public void callSampleFunction()
    {
        Debug.Log("Some sample function has been called by a defined object");
    }


    IEnumerator getInfoFromServer(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            response = webRequest.downloadHandler.text;
            data_fetch_done = true;
            
        }
    }
}
