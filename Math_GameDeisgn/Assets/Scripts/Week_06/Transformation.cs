using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transformation : MonoBehaviour {

    //Retrieve the trasformation matrix;
    public abstract Matrix4x4 Matrix {
        get;
    }

    //Apply matrix value;
    public Vector3 Apply(Vector3 _point) {
        return Matrix.MultiplyPoint(_point);
    }
}
