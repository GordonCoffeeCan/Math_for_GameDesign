using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEG : MonoBehaviour {

    public float radius;

    [Range(0, 2 * Mathf.PI)]
    public float angle;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = PointOnCircle(radius, Time.time);

        //newPos.x = radius * Mathf.Cos(angle);
        //newPos.y = radius * Mathf.Sin(angle);

        this.transform.position = newPos;
	}

    private Vector3 PointOnCircle(float radius, float angle) {
        float angleInRadius = angle * Mathf.Deg2Rad;
        return new Vector3(radius * Mathf.Cos(angleInRadius), radius * Mathf.Sin(angleInRadius), 0);
    }
}
