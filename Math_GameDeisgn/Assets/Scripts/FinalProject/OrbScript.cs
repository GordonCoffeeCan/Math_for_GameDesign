using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour {

    private Transform player;

    private float speed = 0;

    private Color[] colors = new Color[5];

    private bool isScored = false;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = Random.Range(0.015f, 0.05f);

        colors[0] = Color.red;
        colors[1] = Color.gray;
        colors[2] = Color.green;
        colors[3] = Color.yellow;
        colors[4] = Color.white;

        this.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, 5)];
    }
	
	// Update is called once per frame
	void Update () {
        float _dot = 0;
        Vector3 _direction = player.position - this.transform.position;
        float _distance = Vector3.Distance(this.transform.position, player.position);
        _direction.Normalize();
        _dot = Vector3.Dot(_direction, player.up);
        Debug.DrawRay(this.transform.position, _direction, Color.green, Time.deltaTime);

        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed);

        if (_dot < -0.8f && _distance < 0.36f) {
            if (this.GetComponent<SpriteRenderer>().color == player.GetComponent<SpriteRenderer>().color) {
                Debug.Log("Scored");
                ScoreManager.instance.score++;
            } else {
                Debug.Log("Unscored");
                ScoreManager.instance.score--;
            }
            Destroy(this.gameObject);
        } else if(_dot >= -0.8f && _distance < 0.36f) {
            speed = -0.025f;
            if (this.GetComponent<SpriteRenderer>().color == player.GetComponent<SpriteRenderer>().color) {
                if (isScored == false) {
                    ScoreManager.instance.score--;
                    isScored = true;
                }
                
            }
        }

        if(_distance >= 25) {
            Destroy(this.gameObject);
        }
	}
}
