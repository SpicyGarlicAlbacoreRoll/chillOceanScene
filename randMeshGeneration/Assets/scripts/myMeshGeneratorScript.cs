using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class myMeshGeneratorScript : MonoBehaviour {

	Mesh mesh;
	Vector3[] vertices;
	int[] triangles;

	Vector3 triangleIndex1;
	Vector3 triangleIndex2; 
	Vector3 triangleIndex3;

float x, z = 0;
 public float duration = 1.0F;
Color pointColor;
Color oldColor;
	Vector3 nextTriangleIndex = new Vector3 (1, 0, 1);
	Color[] myNewColor;
Material newMaterial;
	// Use this for initialization
	void Start () {
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		GetComponent<MeshRenderer>().material = newMaterial;
		triangleIndex1 = new Vector3 (0,0,0);
		triangleIndex2 = new Vector3 (0,0,Random.value * 10f);
		triangleIndex3 = new Vector3 (Random.value * 10f,0,0);
		pointColor = new Color(x, 0, z);
		
		// myNewColor = new Color[]
		// {
		// 	pointColor
		// };
		CreateShape();
		UpdateMesh();
	}

	void CreateShape()
	{
		vertices = new Vector3[]
		{
			triangleIndex1,
			triangleIndex2,
			triangleIndex3
		};

		triangles = new int[]
		{
			0, 1, 2
		};
	}

	void UpdateMesh()
	{
		mesh.Clear();

		mesh.vertices = vertices;
		mesh.triangles = triangles;
		newMaterial.color =  pointColor;

	}

	private void Update() {
		
		oldColor = newMaterial.color;
		x = Random.value;
		z = Random.value;

		
		triangleIndex1 = new Vector3 (0,0,0);
		triangleIndex2 = new Vector3 (0,0,z);
		triangleIndex3 = new Vector3 (x,0,0);

         float lerp = Mathf.PingPong(Time.time, duration) / duration;
        newMaterial.color = Color.Lerp(Color.red, Color.blue, lerp);
		//newMaterial.color = pointColor;
		CreateShape();
		UpdateMesh();
	}


}
