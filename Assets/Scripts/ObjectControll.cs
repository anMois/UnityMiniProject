using UnityEngine;

public class ObjectControll : MonoBehaviour
{

    [SerializeField] Transform leftPoint;
    [SerializeField] Transform righttPoint;
    [SerializeField] bool left;
    [SerializeField] bool right;

    [SerializeField] float speed;
    Vector3 firstPoint;

    private void Start()
    {
        firstPoint = transform.position;
    }

    private void Update()
    {
        if (left)
        {
            transform.position = Vector3.Slerp(transform.position, leftPoint.position, speed * Time.deltaTime);
        }
        else if (right)
        {
            transform.position = Vector3.Slerp(transform.position, righttPoint.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position, firstPoint, speed * Time.deltaTime);
        }
    }
}
