using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    public float[] zPoints;

    [Header("Throw Position")]
    [SerializeField] Transform leftPoint;
    [SerializeField] Transform righttPoint;

    [SerializeField, Space] int size;

    public int Size { get { return size; } set { size = value; } }

    public Vector3 GetPosition(bool trust)
    {
        if(trust)
        {
            return leftPoint.position;
        }
        else
        {
            return righttPoint.position;
        }
    }
}
