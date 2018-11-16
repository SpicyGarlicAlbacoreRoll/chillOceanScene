using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class newTerrain : MonoBehaviour {


	Mesh mesh;
	Vector3[] vertices;
	int[] triangles;

	public int xSize = 20;
	public int zSize = 20;
	public float waveSpeed = 1;
	public float factor;
	// Use this for initialization
	void Start () {
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		factor = Time.deltaTime;
		// myNewColor = new Color[]
		// {
		// 	pointColor
		// };

		//StartCoroutine(CreateShape());
		CreateShape();
	}

	private void Update() {
		UpdateMesh();
	}

	//IEnumerator 
	void CreateShape()
	{
		vertices = new Vector3[(xSize + 1) * (zSize + 1)];

	factor += Time.deltaTime;

	for (int i = 0, z = 0; z <= zSize; z++)
		{
			for (int x = 0; x <= xSize; x++)
			{
				float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2;
				vertices[i] = new Vector3(x, y * Mathf.Sin(factor/waveSpeed), z);
				i++;
			}
		}

	triangles = new int[xSize * zSize * 6];
	int vert = 0;
	int tris = 0;
	for (int z = 0; z < zSize; z++)
	{
	for (int x = 0; x < xSize; x++)
	{
		triangles[tris + 0] = vert + 0;
		triangles[tris + 1] = vert + xSize + 1;
		triangles[tris + 2] = vert + 1;
		triangles[tris + 3] = vert + 1;
		triangles[tris + 4] = vert + xSize + 1;
		triangles[tris + 5] = vert + xSize + 2;
	
		vert++;
		tris += 6;

		//yield return new WaitForSeconds(.1f);
	}
	vert++;
	}
	
	}

	void UpdateMesh()
	{
		mesh.Clear();
		
		//for(int i = 0; i < vertices.Length; i ++)
		//vertices[i] *=  Mathf.Sin(Time.deltaTime);
		
		mesh.vertices = vertices;
		mesh.triangles = triangles;

		mesh.RecalculateNormals();
		CreateShape();

	}

// 	private void OnDrawGizmos() {

// if (vertices == null)
// 	return;

// 		for (int i = 0; i < vertices.Length; i++)
// 		{
// 			Gizmos.DrawSphere(vertices[i], .1f);
// 		}
// 	}
}
