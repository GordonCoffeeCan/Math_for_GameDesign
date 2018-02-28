using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformEdit : MonoBehaviour {

    public Vector3 translation;
    public Vector3 eulerAngles;
    public Vector3 scale = Vector3.one;

    private MeshFilter myMesh;
    private Vector3[] originalVert;
    private Vector3[] newVerts;

    // Use this for initialization
    void Start () {
        myMesh = GetComponent<MeshFilter>();
        originalVert = myMesh.mesh.vertices;
        newVerts = new Vector3[originalVert.Length];
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion _rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        Matrix4x4 _m = Matrix4x4.identity;
        _m.SetTRS(translation, _rotation, scale);

        for (int i = 0; i < originalVert.Length; i++) {
            newVerts[i] = _m.MultiplyPoint3x4(originalVert[i]);
        }

        myMesh.mesh.vertices = newVerts;
	}
}
