using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float playerSpeed;
    public float turnSpeed;
    Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);
        characterController.SimpleMove(movement*Time.deltaTime*playerSpeed);
        anim.SetFloat("Speed",movement.magnitude);
        Quaternion direction = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime * turnSpeed); ;
    }
}
