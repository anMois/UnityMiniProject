using UnityEngine;

public class WingControll : MonoBehaviour
{
    [SerializeField] Transform leftWing;
    [SerializeField] Transform rightWing;

    [SerializeField] float speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rightWing.rotation = Quaternion.Lerp(rightWing.rotation, Quaternion.Euler(0, -90, 0), speed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rightWing.rotation = Quaternion.identity;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            leftWing.rotation = Quaternion.Lerp(leftWing.rotation, Quaternion.Euler(0, 90, 0), speed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            leftWing.rotation = Quaternion.identity;
        }
    }
}
