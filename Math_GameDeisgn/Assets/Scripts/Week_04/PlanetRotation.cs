using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour {

    [HideInInspector]
    public float speed = 0;
    [HideInInspector]
    public float radius = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 _planetPos = PointOnCircle(radius, Time.time * speed);

        this.transform.position = _planetPos;
	}

    private Vector3 PointOnCircle(float _radius, float _angle) {
        float _angleInRadius = _angle * Mathf.Deg2Rad;
        return new Vector3(radius * Mathf.Cos(_angleInRadius), 0, radius * Mathf.Sin(_angleInRadius));
    }
}
