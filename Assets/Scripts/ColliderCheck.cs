using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] ObjectControll objControll;

    [SerializeField] float x;

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
    }



    private void OnTriggerStay(Collider other)
    {
        if(other.transform.CompareTag("Object"))
        {
            objControll = other.GetComponent<ObjectControll>();
            objControll.First = true;

            if(x == -1 && objControll.Trust)
                objControll.Choice = true;
            else if(x == 1 && !objControll.Trust)
                objControll.Choice = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        objControll = null;
    }
}
