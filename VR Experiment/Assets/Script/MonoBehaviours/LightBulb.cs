using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{

    public TextMesh ledState;
    public enum LightState
    {
        on,
        off
    }

    public LightState lightState = LightState.off;

    public void turnOnOff(LightSwitch.SwitchState switchState)
    {        
        if (switchState == LightSwitch.SwitchState.on)
        {
            lightState = LightState.on;
            turnOn();
            //BlackBoardModule.getInstance().showNextButton();
        }
        else
        {
            lightState = LightState.off;
            turnOff();
        }
    }

    private void turnOn()
    {
        ledState.text = "ON";
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        Material m_BulbMat = GetComponent<MeshRenderer>().material;
        m_BulbMat.SetColor("_EmissionColor", Color.white);

    }

    private void turnOff()
    {
        ledState.text = "OFF";
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        Material m_BulbMat = GetComponent<MeshRenderer>().material;
        m_BulbMat.SetColor("_EmissionColor", Color.black);

    }

}
