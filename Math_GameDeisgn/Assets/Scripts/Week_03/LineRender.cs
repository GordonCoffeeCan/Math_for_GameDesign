using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour {
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Color32 color;

    private LineRenderer lineRender;

    private void Awake() {
        lineRender = this.GetComponent<LineRenderer>();
    }

    // Use this for initialization
    void Start () {
        lineRender.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        lineRender.SetPosition(0, startPoint.position);
        lineRender.SetPosition(1, endPoint.position);
        lineRender.material.color = color;
    }
}
