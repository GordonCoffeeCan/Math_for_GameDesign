using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpownScript : MonoBehaviour {

    [SerializeField] private OrbScript orb;
    [SerializeField] private float timer = 5f;

    private float currentTimer = 0;

    // Use this for initialization
    void Start () {
        currentTimer = timer;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 _screenPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        int randomIndex = Random.Range(0, 4);

        currentTimer -= Time.deltaTime;

        if (currentTimer <= 0) {
            currentTimer = timer;

            if (randomIndex == 0) {
                OrbScript _orbClone = Instantiate(orb, new Vector3(-_screenPos.x - 0.1f, Random.Range(-_screenPos.y, _screenPos.y), 0), Quaternion.identity);
            }else if (randomIndex == 1) {
                OrbScript _orbClone = Instantiate(orb, new Vector3(_screenPos.x + 0.1f, Random.Range(-_screenPos.y, _screenPos.y), 0), Quaternion.identity);
            } else if (randomIndex == 2) {
                OrbScript _orbClone = Instantiate(orb, new Vector3(Random.Range(-_screenPos.x, _screenPos.x), -_screenPos.y - 0.1f, 0), Quaternion.identity);
            } else if (randomIndex == 3) {
                OrbScript _orbClone = Instantiate(orb, new Vector3(Random.Range(-_screenPos.x, _screenPos.x), _screenPos.y + 0.1f, 0), Quaternion.identity);
            }
        }
	}
}
