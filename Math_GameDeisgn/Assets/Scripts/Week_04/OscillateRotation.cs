using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateRotation : MonoBehaviour {

    public float rotationAmount = 20f;
    public float speed = 10f;

    float startAngle;

	// Use this for initialization
	void Start () {
        startAngle = this.transform.localRotation.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rot = this.transform.localRotation.eulerAngles;
        rot.z = startAngle + Mathf.Sin(Time.time * speed) * rotationAmount;
        this.transform.localRotation = Quaternion.Euler(rot);
	}
}
