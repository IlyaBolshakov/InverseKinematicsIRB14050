using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 100.0f;
    float speedRot = 150.0f;
    //float leftVec;
    private void Update()
    {
        float LeftRight = Input.GetAxis("Horizontal");
        float ForwardBack = Input.GetAxis("Vertical");
        float UDrot = Input.GetAxis("Mouse X");
        float LRrot = Input.GetAxis("Mouse Y");
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(LeftRight, 0, ForwardBack) * Time.deltaTime * speed, Space.Self);
            transform.Rotate(Vector3.up * Time.deltaTime * UDrot * speedRot, Space.World);
            transform.Rotate(Vector3.left * Time.deltaTime * LRrot * speedRot, Space.Self);
        }

    }
}
