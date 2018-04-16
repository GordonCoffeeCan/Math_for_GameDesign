using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRandomRotate : MonoBehaviour {
    private float valueTimer = 0;
    private Vector3 randomRotation = Vector3.zero;

	// Use this for initialization
	void Start () {
        valueTimer = Random.Range(1f, 2f);
        randomRotation = new Vector3(Random.value * Random.Range(-45f, 45f), 0, Random.value * Random.Range(-45f, 45f));
    }
	
	// Update is called once per frame
	void Update () {
        valueTimer -= Time.deltaTime;
        if (valueTimer <= 0) {
            valueTimer = Random.Range(1f, 2f);
            randomRotation = new Vector3(Random.value * Random.Range(-30f, 30f), 0, Random.value * Random.Range(-30f, 30f));
        }

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(randomRotation), 0.05f);
	}
}
