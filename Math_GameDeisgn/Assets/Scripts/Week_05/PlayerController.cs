using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float speed = 10;

    private const string COLLISION_PREFIX = "CollisionObjects";

    private Rigidbody2D rig;

    private Vector2 movingVector;

    private void Awake() {
        rig = this.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.cameraAlert == false) {
            movingVector = new Vector2(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical"));
        } else {
            movingVector = Vector2.zero;
        }
    }

    private void FixedUpdate() {
        rig.MovePosition(new Vector2(this.transform.position.x + movingVector.x * Time.deltaTime, this.transform.position.y + movingVector.y * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == COLLISION_PREFIX) {
            if (collision.gameObject.name == "SafeBox") {
                GameManager.instance.gotSafeBox = true;
            }else if (collision.gameObject.name == "Switch") {
                GameManager.instance.cameraOff = true;
            }
        }
    }
}
