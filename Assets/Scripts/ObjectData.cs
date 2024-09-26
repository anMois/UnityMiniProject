using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    public float[] zPoints;

    [SerializeField] Transform leftPoint;
    [SerializeField] Transform righttPoint;

    public Transform LeftPoint {  get { return leftPoint; } }
    public Transform RighttPoint { get {return righttPoint; } }
}
