using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransformation : Transformation {

    public float focalLength = 1;
    public bool orthographicMode = false; //Toggle Perspective or Orthographic view in the inspector;

    //Apply the new postion to grid by overriding Matrix property;
    public override Matrix4x4 Matrix {
        get {
            Matrix4x4 matrix = new Matrix4x4();
            matrix.SetRow(0, new Vector4(focalLength, 0f, 0f, 0f));
            matrix.SetRow(1, new Vector4(0f, focalLength, 0f, 0f));
            if (orthographicMode) {
                matrix.SetRow(2, new Vector4(0f, 0f, 0f, 0f)); //Drop Z dimension for rendering in Orthographic mode;
            } else {
                matrix.SetRow(2, new Vector4(0f, 0f, focalLength, 0f)); //Drop Z dimension for rendering in Orthographic mode;
            }
            matrix.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
            return matrix;
        }
    }
}
