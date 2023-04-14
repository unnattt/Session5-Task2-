using UnityEngine;

    public class AimStateManager : MonoBehaviour
{
    public Transform target;
    public float sensitivity = 1.0f;
    public float minYAngle = -20.0f;
    public float maxYAngle = 20.0f;
    public float distance = 5.0f;
    private float currentX;
    public float heightOffset = 1.0f;
    private float currentY;

    //for mouse Control
    //void Update()
    //{
    //    currentX += Input.GetAxis("Mouse X") * sensitivity;
    //    currentY -= Input.GetAxis("Mouse Y") * sensitivity;
    //    currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
    //}
    void Update()
    {
        if (Input.touchCount == 1 ) // if only one finger is touching the screen
        {
            Touch touch = Input.GetTouch(0);// get the first touch

            // Check if touch is on the right side of the screen
            if (touch.position.x > Screen.width / 2 )
            {
                if (touch.phase == TouchPhase.Moved)// if the touch has moved
                {
                    currentX += touch.deltaPosition.x * sensitivity;
                    currentY -= touch.deltaPosition.y * sensitivity;
                    currentY = Mathf.Clamp(currentY, minYAngle, maxYAngle);
                }
            }
        }
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = target.position + rotation * dir + Vector3.up * heightOffset;
        transform.rotation = rotation;

        if (Input.anyKey)
        {
            target.transform.rotation = Quaternion.AngleAxis(currentX, Vector3.up);
        }
    }
}
