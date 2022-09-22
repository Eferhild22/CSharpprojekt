using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementYX : MonoBehaviour
{ 
private Rigidbody2D rb;
private Vector2 moveV;
public float speed;
void Start()
{
    rb = GetComponent<Rigidbody2D>();
        speed = 20f;
}

void Update()
{
    Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    moveV = moveInput * speed;
}

void FixedUpdate()
{
    rb.MovePosition(rb.position + moveV * Time.fixedDeltaTime);
}
     
 }