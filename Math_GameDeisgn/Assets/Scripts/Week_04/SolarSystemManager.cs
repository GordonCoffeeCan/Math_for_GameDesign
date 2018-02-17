using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemManager : MonoBehaviour {
    [SerializeField]
    private Transform sun;
    [SerializeField]
    private List<GameObject> planetList = new List<GameObject>();

    [SerializeField][Range(1, 15)]
    private float earthspeedScale = 1;

    private float earthRadius = 5.5f;

    private float speed = 20;
    private float seftRotationSpeed = 80;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        planetList[0].transform.position = PlanetPosOnOrbit(earthRadius * 3 / earthRadius, Time.time * earthspeedScale / 0.25f * speed);
        planetList[1].transform.position = PlanetPosOnOrbit(earthRadius * 4 / earthRadius, Time.time * earthspeedScale / 0.6f * speed);
        planetList[2].transform.position = PlanetPosOnOrbit(earthRadius, Time.time * earthspeedScale * speed);
        planetList[3].transform.position = PlanetPosOnOrbit(earthRadius * 7 / earthRadius, Time.time * earthspeedScale / 2f * speed);
        planetList[4].transform.position = PlanetPosOnOrbit(earthRadius * 11 / earthRadius, Time.time * earthspeedScale / 10f * speed);
        planetList[5].transform.position = PlanetPosOnOrbit(earthRadius * 17 / earthRadius, Time.time * earthspeedScale / 15f * speed);
        planetList[6].transform.position = PlanetPosOnOrbit(earthRadius * 23 / earthRadius, Time.time * earthspeedScale / 25f * speed);
        planetList[7].transform.position = PlanetPosOnOrbit(earthRadius * 26 / earthRadius, Time.time * earthspeedScale / 50f * speed);
        planetList[8].transform.position = PlanetPosOnOrbit(earthRadius * 30 / earthRadius, Time.time * earthspeedScale / 85f * speed);

        for (int i = 0; i < planetList.Count; i++) {
            planetList[i].transform.GetChild(0).localEulerAngles = new Vector3(planetList[i].transform.GetChild(0).localEulerAngles.x, planetList[i].transform.GetChild(0).localEulerAngles.y + -seftRotationSpeed * Time.deltaTime, planetList[i].transform.GetChild(0).localEulerAngles.z);
        }

        sun.transform.localEulerAngles = new Vector3(sun.transform.localEulerAngles.x, sun.transform.localEulerAngles.y + -seftRotationSpeed / 2 * Time.deltaTime, sun.transform.localEulerAngles.z);
    }
    

    private Vector3 PlanetPosOnOrbit(float _radius, float _angle) {
        float _angleInRadius = _angle * Mathf.Deg2Rad;
        return new Vector3(_radius * Mathf.Cos(_angleInRadius), 0, _radius * Mathf.Sin(_angleInRadius));
    }
}
