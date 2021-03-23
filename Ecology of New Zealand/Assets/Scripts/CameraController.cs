/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    private Transform parent;

     void Start()
    {
        parent = transform.parent;
    }
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        //parent.Rotate(Vector3.up, mouseX);
       // parent.Rotate(Vector3.up, mouseX);
    }
} 
*/