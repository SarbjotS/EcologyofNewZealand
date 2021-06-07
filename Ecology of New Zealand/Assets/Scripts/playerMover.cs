using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMover : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera MyCamera;
    [SerializeField] float Run = 4f;
    [SerializeField] float Walk = 2f;
    bool Walking;


    float desiredRotation = 0f;
    float desiredAnimationSpeed = 0f;
    float RotationSpeed = 15f;
    float AnimationBlendSpeed = 6f;
    float jumpSpeed = 0f;  //Jumping is disabled
    float SpeedY = 0;
    float gravity = -9.81f;


    Animator MyAnimator;

    private CharacterController controller;
    bool jumping = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        MyAnimator = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(MyCamera);

    }
    private void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump") && !jumping)
        {
            jumping = true;
            MyAnimator.SetTrigger("Jump");
            SpeedY += jumpSpeed;
        } 
        if (!controller.isGrounded) {
        SpeedY += gravity * Time.deltaTime;
        }
        else if (SpeedY < 0)
        {
            SpeedY = 0;
        }
        MyAnimator.SetFloat("SpeedY", SpeedY/jumpSpeed);

        if (jumping && SpeedY < 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, .5f, LayerMask.GetMask("Ground")))
            {
                jumping = false;
                MyAnimator.SetTrigger("Land");
            }
        }
        Walking = Input.GetKey(KeyCode.LeftShift);

        Vector3 movement = new Vector3(x, 0, z).normalized;

        Vector3 rotatedMovement = Quaternion.Euler(0, MyCamera.transform.rotation.eulerAngles.y,0) * movement;
        Vector3 verticalMovement = Vector3.up * SpeedY;


        controller.Move((verticalMovement + (rotatedMovement * (Walking ? Walk : Run) * Time.deltaTime)));

        if (rotatedMovement.magnitude > 0)
        {
            desiredRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
            desiredAnimationSpeed = Walking ? .5f : 1f;
        }
        else
        {
            desiredAnimationSpeed = 0;
        }
        MyAnimator.SetFloat("Speed", Mathf.Lerp(MyAnimator.GetFloat("Speed"),desiredAnimationSpeed, AnimationBlendSpeed *Time.deltaTime));

        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation  = Quaternion.Euler(0, desiredRotation, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, RotationSpeed * Time.deltaTime);


    }


}
