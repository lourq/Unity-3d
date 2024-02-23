using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject cameraAnchor;

    private Vector3 cameraOffset;   //     
    private Vector3 initialOffset;  // --   (  )
    private Vector3 cameraAngles;   //   
    private Vector3 initialAngles;  // --   (  )

    void Start()
    {
        initialOffset = cameraOffset =
            this.transform.position - cameraAnchor.transform.position;
        initialAngles = cameraAngles =
            this.transform.eulerAngles;
    }

    private void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        cameraAngles.y += mx;
        cameraAngles.x -= my;
        if (Input.GetKeyUp(KeyCode.V))
        {
            cameraOffset = (cameraOffset == Vector3.zero)
                ? initialOffset
                : Vector3.zero;
        }
    }

    void LateUpdate()
    {
        this.transform.position = cameraAnchor.transform.position +
            Quaternion.Euler(0, cameraAngles.y - initialAngles.y, 0) * cameraOffset;
        this.transform.eulerAngles = cameraAngles;
    }
}