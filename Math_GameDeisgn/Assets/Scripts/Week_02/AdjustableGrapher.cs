using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustableGrapher : MonoBehaviour {

    public enum FunctionSettings {
        Circle,
        Ellipse,
        Hyperbola
    }

    private delegate float FunctionDelegate(float _x);

    private static FunctionDelegate[] functionDelegates = {
        Circle,
        Ellipse,
        Hyperbola
    };

    public FunctionSettings function;

    [SerializeField] [Range(20, 40000)] private int resolution = 20;
    [SerializeField] [Range(1, 5)] private float radius = 1;
    [SerializeField] [Range(1, 6)] private float a = 5;
    [SerializeField] [Range(1, 6)] private float b = 2;

    private static float currentRadius;
    private static float currentA;
    private static float currentB;

    private int currentResolution;
    private ParticleSystem.Particle[] points;
    private ParticleSystem graphParticle;

    // Use this for initialization
    void Start() {
        graphParticle = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update () {
        CreatePoints();

        FunctionDelegate _f = functionDelegates[(int)function];
        for (int i = 0; i < resolution; i++) {
            Vector3 _p = points[i].position;
            if (i % 2 == 0) { 
                _p.y = _f(_p.x); // y offsite based on music spectrum value;
                
            } else {
                _p.y = -_f(_p.x); // y offsite based on music spectrum value;
            }
            points[i].position = _p;
        }

        currentRadius = radius;
        currentA = a;
        currentB = b;

        graphParticle.SetParticles(points, points.Length);

    }

    private void CreatePoints() {
        currentResolution = resolution;
        points = new ParticleSystem.Particle[resolution];
        //float _offeSite = 2f;
        float _increment = currentRadius / currentResolution;
        for (int i = 0; i < resolution; i++) {
            float _x = i * _increment - currentRadius / 2; // x offsite based on music spectrum value;
            points[i].position = new Vector3(_x, 0, 0);
            points[i].startSize = 0.065f;
            points[i].startColor = new Color(_x + 0.12f, 0.65f, 0.8f);
        }
    }

    private static float Sine(float _x) {
        return 0.5f + 0.5f * Mathf.Sin(2 * Mathf.PI * _x + Time.timeSinceLevelLoad);
    }

    private static float Circle(float _x) {
        return Mathf.Sqrt(currentRadius - Mathf.Pow(_x, 2));
    }

    private static float Ellipse(float _x) {
        return Mathf.Sqrt((Mathf.Pow(currentA, 2) * Mathf.Pow(currentB, 2) * currentRadius - Mathf.Pow(currentB, 2) * Mathf.Pow(_x, 2)) / Mathf.Pow(currentA, 2));
    }

    private static float Hyperbola(float _x) {
        return Mathf.Sqrt((Mathf.Pow(currentA, 2) * Mathf.Pow(currentB, 2) * currentRadius + Mathf.Pow(currentB, 2) * Mathf.Pow(_x, 2)) / Mathf.Pow(currentA, 2));
    }
}
