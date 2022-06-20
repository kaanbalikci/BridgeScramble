using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody RB;

    // SerializeField
    [SerializeField] private float speed = 4f;

    private void Awake()
    {
        
    }


    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

   
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        RB.velocity = new Vector3(hori * speed, RB.velocity.y , vert * speed);
    }
}
