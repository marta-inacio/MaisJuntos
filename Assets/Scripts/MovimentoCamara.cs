using UnityEngine;

public class MovimentoCamara : MonoBehaviour
{
    public Transform target;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y,transform.position.z);

        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(transform.position.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y);

            transform.position = targetPosition;

        }

    }

}