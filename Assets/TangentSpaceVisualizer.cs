using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangentSpaceVisualizer : MonoBehaviour {

    void OnDrawGizmos()
    {
        MeshFilter filter = GetComponent<MeshFilter>();
        if (filter)
        {
            Mesh mesh = filter.sharedMesh;
            if (mesh)
            {
                ShowTangentSpace(mesh);
            }
        }
    }
    void ShowTangentSpace(Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;
        Vector4[] tangents = mesh.tangents;
        for (int i = 0; i < vertices.Length; i++)
        {
              ShowTangentSpace(transform.TransformPoint(vertices[i]),transform.TransformDirection(normals[i]));
           // ShowTangentSpace(vertices[i],normals[i]);
        }
    }
    public float offset = 0.01f;
    public float scale = 0.1f;
    void ShowTangentSpace(Vector3 vertex, Vector3 normal)
    {
        vertex += normal * offset;
        Gizmos.color=Color.green;
        Gizmos.DrawLine(vertex,vertex+ normal * scale);
        //Debug.Log("vertex=" + vertex + "normal=" + normal + "vertex+normal=" + (vertex + normal));
    }
}
