using System;
using UnityEngine;

namespace Scrips
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BaseMesh : MonoBehaviour
    {
        public bool useCoroutine;
        public float waitTime = 0.05f;
        protected WaitForSeconds Wait;
    
        public Mesh mesh;
        public Vector3[] vertices;
        public Vector3[] normals;
        public Color32[] cubeUV;

        private void Awake()
        {
            Wait = new WaitForSeconds(waitTime);
        }
    }
}
