using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EulerApprox : MonoBehaviour {

    LineRenderer linerend;
    List<Vector3> linePositions = new List<Vector3>();
    public Vector3 initialVeclocity;
    public float hStep = 1f;

    public float airResistance = 1;
    public Vector3 windVelocity;
    

	// Use this for initialization
	void Start () {
        linerend = GetComponent<LineRenderer>();

        //physicsState myState = new physicsState(1f, transform.position, initialVeclocity);
        //myState.t = 1;
    }
	
	// Update is called once per frame
	void Update () {
        DrawLine();

    }

    struct physicsState {
        public float t;
        public Vector3 position;
        public Vector3 velocity;

        public physicsState(float _t, Vector3 _pos, Vector3 _velo) {
            t = _t;
            position = _pos;
            velocity = _velo;

        }
    }

    private void DrawLine() {
        linePositions.Clear();
        linePositions.Add(transform.position);
        Prediction();
        linerend.positionCount = linePositions.Count;
        linerend.SetPositions(linePositions.ToArray());
    }

    private void Prediction() {
        physicsState currentState = new physicsState(0, transform.position, initialVeclocity);
        physicsState nextState = currentState;

        while (currentState.position.y >= 0) {
            nextState = EulerFunction(hStep, currentState);
            linePositions.Add(nextState.position);
            currentState = nextState;
        }

        /*for (int i = 0; i < 10; i++) {
            nextState = EulerFunction(hStep, currentState);
            linePositions.Add(nextState.position);
            currentState = nextState;
        }*/
    }

    physicsState EulerFunction(float h, physicsState state0) {
        physicsState state1;
        Vector3 accel = Physics.gravity;
        accel *= airResistance;

        if (state0.position.x >= 3f) {
            state0.velocity += windVelocity;
        }

        state1.t = state0.t + h;
        state1.velocity = state0.velocity + (accel * h);
        state1.position = state0.position + (h * state0.velocity);
        return state1;
    }
}
