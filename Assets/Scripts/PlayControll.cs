using UnityEngine;

public class PlayControll : MonoBehaviour
{
    [SerializeField] Transform leftWing;
    [SerializeField] Transform rightWing;

    [SerializeField] float speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rightWing.rotation = Quaternion.Lerp(rightWing.rotation, Quaternion.Euler(0, -90, 0), speed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            rightWing.rotation = Quaternion.identity;
        }

        if (Input.GetKey(KeyCode.D))
        {
            leftWing.rotation = Quaternion.Lerp(leftWing.rotation, Quaternion.Euler(0, 90, 0), speed * Time.deltaTime);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            leftWing.rotation = Quaternion.identity;
        }
    }
}
