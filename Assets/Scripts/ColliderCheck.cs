using System.Collections;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] ObjectControll objControll;

    [SerializeField] float x = 0;


    private void Start()
    {
        //StartCoroutine(InputRoutin());
    }

    private void FixedUpdate()
    {
        //x = Input.GetAxisRaw("Horizontal");
    }

    IEnumerator InputRoutin()
    {
        WaitForSeconds delay = new WaitForSeconds(0.2f);

        while (true)
        {
            x = Input.GetAxisRaw("Horizontal");
            yield return delay;
        }
    }

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
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            x = 0;
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
            //checkRoutine = StartCoroutine(CheckRoutine());
            if (objControll.First)
            {
                if (x == -1 && objControll.Trust)
                {
                    Debug.Log("11");
                    objControll.Choice = true;
                }
                else if (x == 1 && !objControll.Trust)
                {
                    Debug.Log("22");
                    objControll.Choice = true;
                }
            }
        }
    }

    Coroutine checkRoutine;
    IEnumerator CheckRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(0.2f);

        while (objControll.First)
        {
            if (x == -1 && objControll.Trust)
            {
                Debug.Log("11");
                objControll.Choice = true;
                yield return delay;
            }
            else if (x == 1 && !objControll.Trust)
            {
                Debug.Log("22");
                objControll.Choice = true;
                yield return delay;
            }
        }
    }
}
