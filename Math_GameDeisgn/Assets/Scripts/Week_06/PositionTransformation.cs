using UnityEngine;

public class PositionTransformation : Transformation {

    //Set new postion in the inspector;
    public Vector3 position;


    //Apply the new postion to grid by overriding Matrix property;
    public override Matrix4x4 Matrix {
        get {
            Matrix4x4 _matrix = new Matrix4x4();
            _matrix.SetRow(0, new Vector4(1f, 0f, 0f, position.x));
            _matrix.SetRow(1, new Vector4(0f, 1f, 0f, position.y));
            _matrix.SetRow(2, new Vector4(0f, 0f, 1f, position.z));
            _matrix.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
            return _matrix;
        }
    }
}
