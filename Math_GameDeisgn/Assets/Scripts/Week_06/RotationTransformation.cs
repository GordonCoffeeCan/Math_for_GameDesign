using UnityEngine;

public class RotationTransformation : Transformation {

    //Set new postion in the inspector;
    public Vector3 rotation;

    //Apply the new postion to grid by overriding Matrix property;
    public override Matrix4x4 Matrix {
        get {
            float _radX = rotation.x * Mathf.Deg2Rad; //Convert rotation value from angle to radians.
            float _radY = rotation.y * Mathf.Deg2Rad; //Convert rotation value from angle to radians.
            float _radZ = rotation.z * Mathf.Deg2Rad; //Convert rotation value from angle to radians.

            float _sinX = Mathf.Sin(_radX);
            float _cosX = Mathf.Sin(_radX);

            float _sinY = Mathf.Sin(_radY);
            float _cosY = Mathf.Sin(_radY);

            float _sinZ = Mathf.Sin(_radZ);
            float _cosZ = Mathf.Cos(_radZ);

            Matrix4x4 _matrix = new Matrix4x4();
            _matrix.SetColumn(0, new Vector4(_cosY * _cosZ, _cosX * _sinZ + _sinX * _sinY * _cosZ, _sinX * _sinZ - _cosX * _sinY * _cosZ, 0f));
            _matrix.SetColumn(1, new Vector4(-_cosY * _sinZ, _cosX * _cosZ - _sinX * _sinY * _sinZ, _sinX * _cosZ + _cosX * _sinY * _sinZ, 0f));
            _matrix.SetColumn(2, new Vector4(_sinY, -_sinX * _cosY, _cosX * _cosY, 0f));
            _matrix.SetColumn(3, new Vector4(0f, 0f, 0f, 1f));
            return _matrix;
        }
    }
}
