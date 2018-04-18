using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rando : MonoBehaviour {

    public int randCalls = 50;
    List<float> normalVals = new List<float>();
    List<float> randomVals = new List<float>();
    List<float> subrandomVals = new List<float>();
    List<float> curveVals = new List<float>();

    public AnimationCurve randDistro;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < randCalls; i++) {
            normalVals.Add((float)i / (float)randCalls);
        }

        for (int i = 0; i < randCalls; i++) {
            randomVals.Add(Random.value);
        }

        //Subrandom
        float subregions = 16;
        float subrange = 1f / subregions;

        
        for (int i = 0; i < randCalls; i++) {
            subrandomVals.Add(Random.value * subrange);
            Debug.Log("#" + i.ToString() + ": " + subrandomVals[i].ToString() + " plus " + (((float)i % subregions) / subregions).ToString());
            subrandomVals[i] += ((float)i % subregions) / subregions;
        }

        //Curved Randomness
        for (int i = 0; i < randCalls; i++) {
            curveVals.Add(randDistro.Evaluate(Random.value));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos() {
        if (Application.isPlaying) {
            for (int i = 0; i < randCalls; i++) {
                float offset = 25f;
                Vector3 from = new Vector3(normalVals[i] * 100f, offset - 3f, 0);
                Vector3 to = new Vector3(from.x, offset + 3, 0);
                Gizmos.DrawLine(from, to);

                offset = 15f;
                from = new Vector3(randomVals[i] * 100f, offset - 3f, 0);
                to = new Vector3(from.x, offset + 3f, 0);
                Gizmos.DrawLine(from, to);

                offset = 0;
                from = new Vector3(subrandomVals[i] * 100f, offset - 3f, 0);
                to = new Vector3(from.x, offset + 3f, 0);
                Gizmos.DrawLine(from, to);

                //curved random
                offset = -5;
                from = new Vector3(curveVals[i] * 100f, offset - 3f, 0);
                to = new Vector3(from.x, offset + 3f, 0);
                Gizmos.DrawLine(from, to);
            }
        }
    }
}
