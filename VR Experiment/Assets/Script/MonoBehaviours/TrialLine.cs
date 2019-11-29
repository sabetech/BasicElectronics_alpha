using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialLine : MonoBehaviour
{
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 2;
    void Start() {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        //lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.SetColors(c1, c2);
        lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(lengthOfLineRenderer);
        lineRenderer.SetPosition(0, new Vector3(-0.8f, 8.2f,15f));
        //lineRenderer.SetPosition(1, new Vector3(-0.8f, 10.5f,15f));
    }
    void Update() {
        // LineRenderer lineRenderer = GetComponent<LineRenderer>();
        // float t = Time.time;
        // int i = 0;
        // while (i < lengthOfLineRenderer) {
        //     Vector3 pos = new Vector3(i * 0.5F, Mathf.Sin(i + t), 0);
        //     lineRenderer.SetPosition(i, pos);
        //     i++;
        // }
    }
}
