using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [SerializeField] private float rotateSpeed = 0.1f;
    [SerializeField] private float timer = 5f;

    private float currentTimer = 0;

    private Color[] colors = new Color[5];

    // Use this for initialization
    void Start () {
        colors[0] = Color.red;
        colors[1] = Color.gray;
        colors[2] = Color.green;
        colors[3] = Color.yellow;
        colors[4] = Color.white;

        this.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, 5)];

        currentTimer = timer;
    }
	
	// Update is called once per frame
	void Update () {

        currentTimer -= Time.deltaTime;

        if (currentTimer <= 0) {
            currentTimer = timer;

            this.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, 5)];
        }

        //Triangluar Calculation
        Rotate();

        Debug.DrawRay(this.transform.position, this.transform.up, Color.red, Time.deltaTime);
    }

    private void Rotate() {
        float _angle = Mathf.Atan2(-Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, 0, _angle)), rotateSpeed);
    }
}
