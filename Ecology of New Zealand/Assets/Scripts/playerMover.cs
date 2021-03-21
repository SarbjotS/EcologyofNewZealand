using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMover : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;

    private CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();

    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, -moveZ);
        
        if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }else if (moveDirection == Vector3.zero){
            Idle();
        }
        moveDirection *= moveSpeed;
        controller.Move(moveDirection* Time.deltaTime);
        
    }

    void Idle()
    {

    }

    void Walk()
    {
        moveSpeed = walkSpeed;

    }

    void Run()
    {
        moveSpeed = runSpeed;
    }

}
