using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gato : MonoBehaviour
{
    private Rigidbody Rigidbody;
    [SerializeField]
    private float velocity = 10f;
    [SerializeField]
    private float shootingForce = 50f;
    [SerializeField]
    private float jumpForce;
    public bool player1;
    [SerializeField]
    private Transform tipCanyon;
    private Vector2 dir = Vector2.zero;
    private Animator animator;
    private bool canJump;

    [SerializeField]
    private GameObject bala;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
        canJump = true;
    }
    private void Update()
    {
        HandleMovement(Time.deltaTime);
        HandleShooting(player1, transform);
        HandleJump();
    }

    public void HandleMovement(float deltaTime)
    {
        dir = Vector2.zero;
        if (!player1)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * velocity * deltaTime);
                dir.y = 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.right * velocity * deltaTime);
                dir.y = -1;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.right * velocity * deltaTime);
                dir.x = -1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.right * velocity * deltaTime);
                dir.x = 1;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * velocity * deltaTime);
                dir.y = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.right * velocity * deltaTime);
                dir.y = -1;
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.right * velocity * deltaTime);
                dir.x = -1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.right * velocity * deltaTime);
                dir.x = 1;
            }
        }
        if(dir != Vector2.zero)
            transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.y));
        if (dir == Vector2.zero)
            animator.SetBool("Running", false);
        else
            animator.SetBool("Running", true);
    }

    public void HandleShooting(bool player1, Transform origin)
    {
        if (!player1)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                GameObject newBala = Instantiate(bala, tipCanyon.position, tipCanyon.rotation);
                newBala.GetComponent<Rigidbody>().AddForce(origin.right * shootingForce, ForceMode.Impulse);

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject newBala = Instantiate(bala, tipCanyon.position, tipCanyon.rotation);
                newBala.GetComponent<Rigidbody>().AddForce(origin.right * shootingForce, ForceMode.Impulse);
            }
        }
    }

    private void HandleJump()
    {
        if (!player1)
        {
            if (Input.GetKeyDown(KeyCode.RightControl) && canJump)
            {
                canJump = false;
                Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && canJump)
            {
                canJump = false;
                Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    public void KillKat()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cubo"))
            canJump = true;
    }
}
