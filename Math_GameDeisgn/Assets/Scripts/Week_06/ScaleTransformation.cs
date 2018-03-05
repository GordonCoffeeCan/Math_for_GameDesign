using UnityEngine;

public class ScaleTransformation : Transformation {

    //Set new postion in the inspector;
    public Vector3 scale;

    //Apply the new postion to grid by overriding Matrix property;
    public override Matrix4x4 Matrix {
        get {
            Matrix4x4 _matrix = new Matrix4x4();
            _matrix.SetRow(0, new Vector4(scale.x, 0f, 0f, 0f));
            _matrix.SetRow(1, new Vector4(0f, scale.y, 0f, 0f));
            _matrix.SetRow(2, new Vector4(0, 0f, scale.z, 0f));
            _matrix.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
            return _matrix;
        }
    }
}
