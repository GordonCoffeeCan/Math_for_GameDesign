using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour {
    private float inputX = 3;
    private float radius = 3;

    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private Transform pointO;

    [SerializeField] private Text pointAText;
    [SerializeField] private Text pointBText;
    [SerializeField] private Text pointCText;
    [SerializeField] private Text sinText;
    [SerializeField] private Text xValueSliderText;
    [SerializeField] private Text radiusSliderText;
    [SerializeField] private Slider xValueSlider;
    [SerializeField] private Slider radiusSlider;
    
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        pointO.transform.position = Vector3.zero;
        pointA.position = new Vector3(inputX, 0, 0);
        pointB.position = new Vector3(radius, 0, 0);
        pointC.position = new Vector3(inputX, radius * G_Sin());

        pointAText.text = "A (" + pointA.position.x + ", " + 0 + ")";
        pointBText.text = "B (" + pointB.position.x + ", " + 0 + ")";
        pointCText.text = "C (" + pointC.position.x + ", " + pointC.position.y + ")";
        sinText.text = "Sin(AOC) = " + G_Sin().ToString();
    }

    private float G_Sin() {
        return Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow(inputX, 2)) / radius;
    }

    public void ChangeX() {
        inputX = xValueSlider.value;
        xValueSliderText.text = "X Value " + xValueSlider.value;
    }

    public void ChangeRadius() {
        radius = radiusSlider.value;
        radiusSliderText.text = "Radius " + radiusSlider.value;
        xValueSlider.maxValue = radiusSlider.value;
        xValueSlider.minValue = -radiusSlider.value;
    }
}
