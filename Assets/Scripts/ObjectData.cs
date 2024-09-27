using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    public float[] zPoints;

    [SerializeField] Transform leftPoint;
    [SerializeField] Transform righttPoint;

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
