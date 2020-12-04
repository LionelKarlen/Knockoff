using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public Transform player;
    public Transform pivot;
    public Vector3 offset;
    public float rotationSpeed;
    public GameObject Gun;
    public Transform GunPivot;
    public Transform Camera;
    private Quaternion rotation2;
    // Start is called before the first frame update
    void Start()
    {
        pivot.transform.position = player.transform.position;
       pivot.transform.parent = player.transform;
       Cursor.lockState = CursorLockMode.Locked;
       Vector3 GunSize = Gun.GetComponent<Renderer>().bounds.size;
       float a = GunSize.z;
       Gun.transform.position -= new Vector3(0, 0, a/2);
    }

    // Update is called once per frame
    void Update()
    {
        /*float horizontal = Input.GetAxis("Mouse X")*rotationSpeed;
        pivot.Rotate(horizontal, 0, 0);
        float vertical = Input.GetAxis("Mouse Y")*rotationSpeed;
        pivot.Rotate(0, -vertical, 0);
        float desiredX = pivot.eulerAngles.x;
        float desiredY = pivot.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(desiredX, desiredY, 0);
        transform.position = player.position - (rotation*offset);
        Vector3 LookAtTarget = player.position;
        transform.LookAt(LookAtTarget);*/
        rotation2.eulerAngles = new Vector3(0,Camera.transform.rotation.eulerAngles.y - 90, 90);
        GunPivot.transform.rotation = rotation2;
    }
}
