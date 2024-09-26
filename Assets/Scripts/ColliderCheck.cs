using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Object"))
        {
            ObjectControll objControll = other.GetComponent<ObjectControll>();
            objControll.First = true;
        }
    }
}
