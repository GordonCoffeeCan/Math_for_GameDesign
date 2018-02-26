using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float speed = 5;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 3);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position += this.transform.up * speed * Time.deltaTime;
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        Destroy(this.gameObject);
    }
}
