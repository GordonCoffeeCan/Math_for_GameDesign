using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationGrid : MonoBehaviour {

    //Get Prefab from the inspector;
    public Transform prefab;

    //Set the initial resolution of grid. Able to adjust in the inspector;
    public int gridResolution = 10;

    //Transform array for store prefabs;
    private Transform[] grid;

    //Transformation Generic list;
    private List<Transformation> transformations;

    private Matrix4x4 transformation;

    private void Awake() {
        //Set size of grid array;
        grid = new Transform[gridResolution * gridResolution * gridResolution];
        transformations = new List<Transformation>();

        //Create prefab on the points of grid. Grid has long, height and depth, so that 3 for-loops is using for creating prefab on each axises;
        for (int i = 0, z = 0; z < gridResolution; z++) {
            for (int y = 0; y < gridResolution; y++) {
                for (int x = 0; x < gridResolution; x++, i++) {
                    grid[i] = CreateGridPoint(x, y, z);
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //this.GetComponents<Transformation>(transformations);
        UpdateTransformation();
        //Transform each point on X, y, Z axis by using 3 for-loops;
        for (int i = 0, z = 0; z < gridResolution; z++) {
            for (int y = 0; y < gridResolution; y++) {
                for (int x = 0; x < gridResolution; x++, i++) {
                    //Change local postion to each grid point;
                    grid[i].localPosition = TransformPoint(x, y, z);
                }
            }
        }
	}

    //Create prefab here
    private Transform CreateGridPoint(int _x, int _y, int _z) {
        Transform point = Instantiate<Transform>(prefab); //Instantiate prefab;
        point.localPosition = GetCoordinates(_x, _y, _z); //Set the prefab local postion to origin point;
        point.GetComponent<MeshRenderer>().material.color = new Color((float)_x / gridResolution, (float)_y / gridResolution, (float)_z / gridResolution); //Set object color along with it local position;
        return point;
    }

    //Set prefab center to origin
    private Vector3 GetCoordinates(int _x, int _y, int _z) {
        return new Vector3(_x -(gridResolution - 1) / 2, _y - (gridResolution - 1) / 2, _z - (gridResolution - 1) / 2);
    }

    //Set each prefab new position along with the original coordinates;
    private Vector3 TransformPoint(int _x, int _y, int _z) {
        Vector3 _coordinates = GetCoordinates(_x, _y, _z); //Get the original cooridnates point;
        return transformation.MultiplyPoint(_coordinates);//Apply new transformations to the original point;
    }

    private void UpdateTransformation() {
        GetComponents<Transformation>(transformations);
        if (transformations.Count > 0) {
            transformation = transformations[0].Matrix;
            for (int i = 0; i < transformations.Count; i++) {
                transformation = transformations[i].Matrix * transformation;
            }
        }
    }
}
