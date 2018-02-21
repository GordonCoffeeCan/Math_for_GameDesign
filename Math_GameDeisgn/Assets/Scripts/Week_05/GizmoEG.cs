using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoEG : MonoBehaviour {

    public Transform bodyA, bodyB;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, bodyA.position);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, bodyB.position);

        Gizmos.color = Color.magenta;
        float dotProd = Vector3.Dot(bodyA.position, bodyB.position);
        Gizmos.DrawRay(transform.position, Vector3.up * dotProd);

    }

    private void OnDrawGizmosSelected() {
        
    }
}
