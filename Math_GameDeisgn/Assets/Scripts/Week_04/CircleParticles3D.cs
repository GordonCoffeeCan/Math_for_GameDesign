using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class CircleParticles3D : MonoBehaviour {

    public float horizontal;
    public float verticle;

    public float speed = 10;

    [Range(1, 20)]
    public float radius;
    [Range(1, 360)]
    public int numberOfParticles;

    ParticleSystem myParticleSystem;
    ParticleSystem.Particle[] points;

	// Use this for initialization
	void Start () {

        myParticleSystem = this.GetComponent<ParticleSystem>();

        if (points == null) {
            CreatePoints();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(points.Length != numberOfParticles || points == null) {
            CreatePoints();
        }

        for (int i = 0; i < numberOfParticles; i++) {
            Vector3 pos = points[i].position;
            pos = CircleUtility.ParticleOnSphere(radius, (speed * Time.time) + i, (speed * Time.time) + i);
            points[i].position = pos;
        }

        myParticleSystem.SetParticles(points, points.Length);
	}

    private void CreatePoints() {
        points = new ParticleSystem.Particle[numberOfParticles];
        for (int i = 0; i < numberOfParticles; i++) {
            points[i].position = Vector3.zero;
            points[i].startColor = new Color(Random.value, (float)i / numberOfParticles, Random.value);
            points[i].startSize = 0.5f;
        }
    }
}
