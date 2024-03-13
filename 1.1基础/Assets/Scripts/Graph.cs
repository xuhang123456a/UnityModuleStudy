using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;
    Transform[] points;

    [Range(10, 100)]
    public int resolution = 10;

    bool needRefresh = false;

    private void Awake()
    {
        needRefresh = true;
    }

    private void OnInit()
    {
        points = new Transform[resolution];
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        position.y = 0f;
        position.z = 0f;
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            //position.y = position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    private void Update()
    {
        if (points != null)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Transform point = points[i];
                Vector3 position = point.localPosition;
                position.y = Mathf.Sin(Mathf.PI * (position.x) + Time.time);
                point.localPosition = position;
            }
        }
    }

    private void OnApplicationQuit()
    {
        needRefresh = false;
    }

#if UNITY_EDITOR
    private void RemoveAllChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    private void OnValidate()
    {
        RemoveAllChildren(); 
        if (needRefresh)
        {
            OnInit();
        }
    }
#endif
}
