using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    [SerializeField] InGameManager inGm;
    [SerializeField] ObjectControll objControll;

    [SerializeField] float x = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -1;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
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
            //제대로된 입력
            if ((x == -1 && objControll.Trust) || (x == 1 && !objControll.Trust))
            {
                ChoiceTrue();
                inGm.ComboCount++;
            }
            else if((x == -1 && !objControll.Trust) || (x == 1 && objControll.Trust))
            {
                inGm.ComboCount = 0;
            }
        }
    }

    private void ChoiceTrue()
    {
        objControll.Choice = true;
        inGm.GetScore();
        x = 0;
    }
}
