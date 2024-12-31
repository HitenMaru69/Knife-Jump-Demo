using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float maxForce;
    [SerializeField] float incressforce;
    [SerializeField] float force;
    [SerializeField] float rotationSpeed;
    [SerializeField] Gamemanager gamemanager;
    [SerializeField] Camera gameCamera;


    private bool ishold;
    private bool isCollidingWithTop = false;

    private void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            ishold = true;
            force = 0f;
        }

        if (Input.GetMouseButton(0) && ishold)
        {
            force += incressforce * Time.deltaTime;
            force = Mathf.Clamp(force, 0, maxForce);
        }

     
        if (Input.GetMouseButtonUp(0) && ishold)
        {
            ishold = false;
            JumpKnife();
        }

        if (!IsGrounded())
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }


    }

    void JumpKnife()
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

      
        if (collision.gameObject.CompareTag("Ground"))
        {
           
            ContactPoint2D contact = collision.contacts[0];

     
            if (contact.normal.y > 0)  
            {


                gamemanager.ScoreUpdate();

                GroundManager.Instance.isSpwan = true;

                isCollidingWithTop = true;

                Gamemanager.instance.isMoveCamera = true;

               
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            if(isCollidingWithTop)
            {
                Destroy(collision.gameObject);
                isCollidingWithTop = false;
            }
        }

    }

    bool IsGrounded()
    {
        return Mathf.Abs(rb.velocity.y) < 0.1f;
    }
}
