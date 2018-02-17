using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemManager : MonoBehaviour {

    [SerializeField]
    private List<GameObject> planetList = new List<GameObject>();

    [SerializeField][Range(1, 15)]
    private float earthspeedScale = 1;

    private float earthRadius = 7;

    private float speed = 20;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        planetList[0].transform.position = PlanetPosOnOrbit(earthRadius * 3 / earthRadius, Time.time * earthspeedScale / 0.25f * speed);
        planetList[1].transform.position = PlanetPosOnOrbit(earthRadius * 5 / earthRadius, Time.time * earthspeedScale / 0.6f * speed);
        planetList[2].transform.position = PlanetPosOnOrbit(earthRadius, Time.time * earthspeedScale * speed);
        planetList[3].transform.position = PlanetPosOnOrbit(earthRadius * 10 / earthRadius, Time.time * earthspeedScale / 2f * speed);
        planetList[4].transform.position = PlanetPosOnOrbit(earthRadius * 16 / earthRadius, Time.time * earthspeedScale / 10f * speed);
        planetList[5].transform.position = PlanetPosOnOrbit(earthRadius * 22 / earthRadius, Time.time * earthspeedScale / 15f * speed);
        planetList[6].transform.position = PlanetPosOnOrbit(earthRadius * 30 / earthRadius, Time.time * earthspeedScale / 25f * speed);
        planetList[7].transform.position = PlanetPosOnOrbit(earthRadius * 36 / earthRadius, Time.time * earthspeedScale / 50f * speed);
        planetList[8].transform.position = PlanetPosOnOrbit(earthRadius * 39 / earthRadius, Time.time * earthspeedScale / 85f * speed);
    }
    

    private Vector3 PlanetPosOnOrbit(float _radius, float _angle) {
        float _angleInRadius = _angle * Mathf.Deg2Rad;
        return new Vector3(_radius * Mathf.Cos(_angleInRadius), 0, _radius * Mathf.Sin(_angleInRadius));
    }
}
