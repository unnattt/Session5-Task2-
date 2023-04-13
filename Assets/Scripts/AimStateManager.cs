using UnityEngine;
using UnityEngine.EventSystems;

    public class AimStateManager : MonoBehaviour
{
    public float xAxis, yAxis;
    [SerializeField] float mouseSense = 1;
    [SerializeField] Transform cam;

    void Start()
    {

    }

    
    void Update()
    {
        var eventSystem = EventSystem.current;

        for (int i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            if (eventSystem.IsPointerOverGameObject(touch.fingerId))
            {
                continue;
            }
            else
            {
                ConnectPlayerToCamera();
                break;
            }
        }

        ConnectPlayerToCamera();
    }

    private void LateUpdate()
    {
          cam.localEulerAngles = new Vector3(yAxis, cam.localEulerAngles.y, cam.localEulerAngles.z);
          transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }


    void ConnectPlayerToCamera()
    {
        if (Input.GetMouseButton(0))
        {
            xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
            yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSense;
            yAxis = Mathf.Clamp(yAxis, -80, 80);
        }
         
    }
}
