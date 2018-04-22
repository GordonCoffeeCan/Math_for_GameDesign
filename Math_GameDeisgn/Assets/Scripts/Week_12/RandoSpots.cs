using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandoSpots : MonoBehaviour {

    public int randCalls = 10;
    public Transform spot;
    public Text uiText;
    
    public AnimationCurve randDistro;

    private List<float> normalVals = new List<float>();
    private List<float> randomVals = new List<float>();
    private List<float> subrandomVals = new List<float>();
    private List<float> curveVals = new List<float>();

    private List<Transform> spots = new List<Transform>();

    private Vector3[] newPos;

    private float resetPosTimer = 2;
    private int randomIndex = 0;

    // Use this for initialization
    void Start() {
        newPos = new Vector3[randCalls];
        for (int i = 0; i < randCalls; i++) {
            normalVals.Add((float)i / (float)randCalls);
        }

        for (int i = 0; i < randCalls; i++) {
            randomVals.Add(Random.value);
        }

        //Subrandom
        float subregions = 50;
        float subrange = 1f / subregions;


        for (int i = 0; i < randCalls; i++) {
            subrandomVals.Add(Random.value * subrange);
            subrandomVals[i] += ((float)i % subregions) / subregions;
        }

        //Curved Randomness
        for (int i = 0; i < randCalls; i++) {
            curveVals.Add(randDistro.Evaluate(Random.value));
        }

        //---------------------------------------------------------------------------

        for (int i = 0; i < randCalls; i++) {
            newPos[i] = new Vector3(normalVals[i] * 10, 0, 0);
            Transform spotClone = Instantiate(spot, newPos[i], Quaternion.identity);
            spotClone.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1);
            spots.Add(spotClone);
            uiText.text = "Normal Value";
        }
    }

    // Update is called once per frame
    void Update() {
        resetPosTimer -= Time.deltaTime;
        
        if (resetPosTimer <= 0) {
            resetPosTimer = 2;
            switch (randomIndex) {
                case 0:
                    SetNormal();
                    uiText.text = "Normal Value";
                    break;
                case 1:
                    SetRandom();
                    uiText.text = "Random Value";
                    break;
                case 2:
                    SetSumRandom();
                    uiText.text = "SubRandom Value";
                    break;
                case 3:
                    SetCurve();
                    uiText.text = "Random Value on Curve";
                    break;
            }
            randomIndex++;
            if(randomIndex > 3) {
                randomIndex = 0;
            }
        }

        for (int i = 0; i < randCalls; i++) {
            spots[i].position = Vector3.Lerp(spots[i].position, newPos[i], 0.1f);
        }
    }

    private void SetNormal() {
        for (int i = 0; i < randCalls; i++) {
            newPos[i] = new Vector3(normalVals[i] * 10, 0, 0);
        }
        
    }

    private void SetRandom() {
        for (int i = 0; i < randCalls; i++) {
            newPos[i] = new Vector3(randomVals[i] * 10, randomVals[(int)(Random.value * randCalls)] * 3, 0);
        }
        
    }

    private void SetSumRandom() {
        for (int i = 0; i < randCalls; i++) {
            newPos[i] = new Vector3(subrandomVals[i] * 10, subrandomVals[(int)(Random.value * randCalls)] * 3, 0);
        }
        
    }

    private void SetCurve() {
        for (int i = 0; i < randCalls; i++) {
            newPos[i] = new Vector3(curveVals[i] * 10, curveVals[(int)(Random.value * randCalls)] * 3, 0);
        }
    }
}
