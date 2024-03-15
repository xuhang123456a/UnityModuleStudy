using System.Collections;
using UnityEngine;

namespace Scrips
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class Grid : MonoBehaviour
    {
        public int xSize, ySize;

        public Vector3[] verticles;

        private Mesh mesh;

        private void Awake()
        {
            // StartCoroutine();
            Generate();
        }

        private void Generate()
        {
            GetComponent<MeshFilter>().mesh = mesh = new Mesh();
            mesh.name = "Procedural Grid";

            verticles = new Vector3[(xSize + 1) * (ySize + 1)];
            Vector2[] uv = new Vector2[verticles.Length];
            Vector4[] tangents = new Vector4[verticles.Length];
            Vector4 tangent = new Vector4(1, 0, 0, -1);
            for (int i = 0, y = 0; y <= ySize; y++)
            {
                for (int x = 0; x <= xSize; x++, i++)
                {
                    verticles[i] = new Vector3(x, y);
                    uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
                    tangents[i] = tangent;
                }
            }
            mesh.vertices = verticles;
            mesh.uv = uv;
            mesh.tangents = tangents;

            int[] triangles = new int[xSize * ySize * 6];
            for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
            {
                for (int x = 0; x < xSize; x++, ti += 6, vi++)
                {
                    triangles[ti] = vi;
                    triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                    triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                    triangles[ti + 5] = vi + xSize + 2;
                }
            }
            mesh.triangles = triangles;
            mesh.RecalculateNormals();
        }

        private void OnDrawGizmos()
        {
            if (verticles == null)
                return;

            foreach (var verticle in verticles)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(verticle, 0.1f);
            }
        }
    }
}