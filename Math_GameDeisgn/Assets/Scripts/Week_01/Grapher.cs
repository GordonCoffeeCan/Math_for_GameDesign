using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapher : MonoBehaviour {

    public enum FunctionSettings {
        Linear,
        Exponential,
        Parabola,
        Sine,
        Circle
    }

    private delegate float FunctionDelegate(float _x);

    private static FunctionDelegate[] functionDelegates = {
        Linear,
        Exponential,
        Parabola,
        Sine,
        Circle
    };

    public FunctionSettings function;

    [SerializeField] [Range(20, 200)] private int resolution = 20;
    [SerializeField] [Range(0, 2)] private float offsite = 1;

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
        GetAudioWaveInfo();

        FunctionDelegate _f = functionDelegates[(int)function];
        for (int i = 0; i < resolution; i++) {
            Vector3 _p = points[i].position;
            _p.y = _f(_p.x) - GetAudioWaveInfo() / 10;
            points[i].position = _p;
        }

        graphParticle.SetParticles(points, points.Length);

    }

    private void CreatePoints() {
        currentResolution = resolution;
        points = new ParticleSystem.Particle[resolution];
        //float _offeSite = 2f;
        float _increment = offsite / currentResolution;
        for (int i = 0; i < resolution; i++) {
            float _x = i * _increment - offsite / 2 - GetAudioWaveInfo() / 200;
            points[i].position = new Vector3(_x, 0, 0);
            points[i].startSize = 0.1f;
            points[i].startColor = new Color(_x + 0.12f, 0.65f, 0.8f);
        }
    }

    private float GetAudioWaveInfo() {
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        return Mathf.Log(spectrum[1]);
    }

    private static float Linear(float _x) {
        return _x;
    }

    private static float Exponential(float _x) {
        return _x * _x;
    }

    private static float Parabola(float _x) {
        _x = 2f * _x - 1f;
        return _x * _x;
    }

    private static float Sine(float _x) {
        return 0.5f + 0.5f * Mathf.Sin(2 * Mathf.PI * _x + Time.timeSinceLevelLoad);
    }

    private static float Circle(float _x) {
        return Mathf.Sqrt(1 - (_x * _x));
    }
}
