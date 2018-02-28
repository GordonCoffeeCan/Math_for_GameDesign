using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTranslate : MonoBehaviour {

    public Vector3 angularMomentum;

    private Matrix4x4 inertiaMatrix;

	// Use this for initialization
	void Start () {
        inertiaMatrix = Matrix4x4.Scale(GetComponent<Rigidbody>().inertiaTensor);
	}
	
	// Update is called once per frame
	void Update () {
        CalcRotation();
    }

    private void CalcRotation() {
        Matrix4x4 _rotationMatrix = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
        Matrix4x4 _inertialMatrixLocal = _rotationMatrix * inertiaMatrix * _rotationMatrix.inverse;
        Vector3 _angularVelocity = _inertialMatrixLocal.inverse * angularMomentum;
        Vector3 _axis = _angularVelocity.normalized;
        float _speed = _angularVelocity.magnitude;
        float _degreesThisFrame = Time.deltaTime * Mathf.Rad2Deg;
        transform.RotateAround(transform.position, _axis, _speed * _degreesThisFrame);
    }
}
