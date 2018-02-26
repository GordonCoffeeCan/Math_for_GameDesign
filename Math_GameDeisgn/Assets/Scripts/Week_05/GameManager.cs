using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Sprite switchOff;

    [HideInInspector] public bool cameraOff = false;
    [HideInInspector] public bool cameraAlert = false;
    [HideInInspector] public bool gotSafeBox = false;

    [SerializeField] private SpriteRenderer switchBox;
    [SerializeField] private Text gameStatus;

    public static GameManager instance;

    private void Awake() {
        instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (cameraOff || cameraAlert) {
            switchBox.sprite = switchOff;
        }

        if (cameraAlert) {
            gameStatus.text = "Game Over O_o";
        }

        if (gotSafeBox) {
            gameStatus.text = "You got the Money!";
        }
    }
}
