using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;

    private CharacterController characterController;
    private Vector3 moveStep;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dz = Input.GetAxis("Vertical");
        if (Mathf.Abs(dx) > 0f && Mathf.Abs(dz) > 0f)   // 
        {
            dx /= Mathf.Sqrt(2f);
            dz /= Mathf.Sqrt(2f);
        }
        if (!Input.GetKey(KeyCode.LeftAlt))
        {
            moveStep =  // new Vector3(dx, 0, dz);
                    (dx * Camera.main.transform.right + dz * Camera.main.transform.forward);
        }
        characterController.SimpleMove(Time.deltaTime * speed * moveStep);
    }
}