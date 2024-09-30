using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] ObjectControll objControll;

    [SerializeField] float x = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            x = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            x = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Object"))
        {
            objControll = other.transform.GetComponent<ObjectControll>();
            objControll.First = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Object"))
        {
            //입력했다고 알림
            if (x == -1 && objControll.Trust)
            {
                Debug.Log("11");
                objControll.Choice = true;
                x = 0;
            }
            else if (x == 1 && !objControll.Trust)
            {
                Debug.Log("22");
                objControll.Choice = true;
                x = 0;
            }
        }
    }
}
