using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [SerializeField] private PlayerController player;
    [SerializeField][Range(-1, 1)] private float camDirection = 1;
    [SerializeField] private GameObject visionCone;

    private Vector3 distanceVector = Vector3.zero;
    private float distance = 0;
    private float bulletTimer = 0.2f;
    private float currentBulletTimer = 0;

    private enum CameraState {
        Idle,
        Alart,
        Disabled
    }

    [SerializeField] private CameraState cameraState;
    [SerializeField] private Bullet bullet;

	// Use this for initialization
	void Start () {
        if (player == null) {
            Debug.LogError("No Player reference assgined");
        }
	}
	
	// Update is called once per frame
	void Update () {
        float _dot = 0;
        distanceVector = this.transform.position - player.transform.position;
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        distanceVector.Normalize();

        _dot = Vector3.Dot(this.transform.up, distanceVector);

        //Debug.Log(_dot);

        if (cameraState != CameraState.Disabled) {
            if (Mathf.Abs(_dot) > 0.866f && distance < 3.89f) {
                Debug.Log("Camera Saw");
                cameraState = CameraState.Alart;
                GameManager.instance.cameraAlert = true;
            }
        }

        if (GameManager.instance.cameraOff) {
            cameraState = CameraState.Disabled;
            visionCone.gameObject.SetActive(false);
        }

        if (cameraState == CameraState.Idle) {
            CameraRotation();
        } else if (cameraState == CameraState.Alart) {
            FacingToPlayer();
        }

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(this.transform.position, player.transform.position);
    }

    private void CameraRotation() {
        this.transform.rotation = Quaternion.Euler(0, 0, this.transform.eulerAngles.z - Mathf.Sin(Time.time) * camDirection);
    }

    private void FacingToPlayer() {
        this.transform.up = -distanceVector;
        currentBulletTimer -= Time.deltaTime;

        if (currentBulletTimer <= 0) {
            Instantiate(bullet, transform.position + Vector3.forward * 0.5f, this.transform.rotation);
            currentBulletTimer = bulletTimer;
        }
    }
}
