using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosDrawer : MonoBehaviour
{
    public Transform[] points;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        for (int i = 0; i < points.Length; i++)
        {
            int nextPoint = i + 1;

            if (nextPoint >= points.Length)            
                nextPoint = 0;        

            Gizmos.DrawLine(points[i].position, points[nextPoint].position);
        }
    }
}
