using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuadCube : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3[] vertices = {
            new Vector3 (1, 1, 1),
            new Vector3 (-1, 1, 1),
            new Vector3 (-1, -1, 1),
            new Vector3 (1, -1, 1),
            new Vector3 (-1, 1, -1),
            new Vector3 (1, 1, -1),
            new Vector3 (1, -1, -1),
            new Vector3 (-1, -1, -1),
        };
    
    int[][] faceTriangles = {
        new int[]{0,1,2,3},
        new int[]{5,0,3,6},
        new int[]{4,5,6,7},
        new int[]{1,4,7,2},
        new int[]{5,4,1,0},
        new int[]{3,2,7,6}

    };
    List<Vector3> vertice;
    List<int> triangles;
    Mesh mesh;
    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }
    void Start()
    {
       
       
        MakeCube();
        UpdateMesh();
    }

    void MakeCube()
    {
        vertice = new List<Vector3>();
        triangles = new List<int>();
        for(int i=0;i<6;i++)
        {
            MakeFace(i);
        }

    }

    void MakeFace(int dir)
    {
        vertice.AddRange(faceVertices(dir));
        int vCount = vertice.Count;
        triangles.Add(vCount-4);
        triangles.Add(vCount - 4+1);
        triangles.Add(vCount - 4+2);
        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4+2);
        triangles.Add(vCount - 4+3);
    }

    public Vector3[] faceVertices(int dir)
    {
        Vector3[] fv = new Vector3[4];
        for(int i=0;i<fv.Length;i++)
        {
            fv[i] = vertices[faceTriangles[dir][i]];
        }
        return fv;

    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertice.ToArray();
        mesh.triangles = triangles.ToArray();
        // mesh.Optimize();
        mesh.RecalculateNormals();
    }
}
