using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;

    public bool useOffSetValues;

    public float mouseSense;

    public Transform pivot;

    public float maxViewAngle;

    public float minViewAngle;

    public bool invertY;
    
    // Start is called before the first frame update
    void Start()
    {
        pivot.parent = null;

        if (!useOffSetValues)
        {
            offset = target.position - transform.position;
        }
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //get x position of mouse and rotate the target
        float horizontal = Input.GetAxis("Mouse X") * mouseSense;
        target.Rotate(0, horizontal, 0);

        //get y position of mouse and rotate the target
        float vertical = Input.GetAxis("Mouse Y") * mouseSense;
        

        if(invertY == true)
        {
            pivot.Rotate(vertical, 0, 0);
        }
        else
        {
            pivot.Rotate(-vertical, 0, 0);
        }

        //limit up/down camera rotation
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }

        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }

        //move camera based on the current rotation of the target & the original offset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y+.2f, transform.position.z);
        }

        transform.LookAt(target);

    }
}
