using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public static bool press = false;

    [SerializeField] private float speed = 50f;
    [SerializeField] private float horizontalMultiplier = 2;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator anim;

    private float horizontalInput;
    private int borderX = 8;

    private Vector3 forwardMove, horizontalMove, move;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            press = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            press = false;
        }

        if (press)
        {
            Run();
            horizontalInput = MouseController.side;
        }
        else anim.SetTrigger("Idle");
    }
    private void Run()
    {
        anim.SetTrigger("Run");
        forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        move = rb.position + forwardMove + horizontalMove;
        if (move.x>borderX) move.x=borderX;
        else if(move.x<-borderX) move.x=-borderX;
        rb.MovePosition(move);
    }
}
