using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour {

    public float shootMagnitude;
    public GameObject ball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Fire();
        }
	}

    private void Fire() {
        GameObject clone = Instantiate(ball, transform.position, Quaternion.identity);
        float shootAngle = this.transform.localEulerAngles.z;
        shootAngle += 90;
        Vector3 startForce = CircleUtility.PointOnCircle(shootMagnitude, shootAngle);

        clone.GetComponent<Rigidbody>().AddForce(startForce);
    }
}
