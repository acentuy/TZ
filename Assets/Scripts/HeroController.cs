using UnityEngine;

class HeroController : MonoBehaviour
{
    public static bool press = false;
    public static bool control = true;

    public static int coins;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float horizontalMultiplier = 2;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private Animator anim;

    private Vector3 forwardMove, horizontalMove, move;

    private float horizontalInput;
    private int borderX = 8;

    private void Start()
    { 
        control = true;
        anim = GetComponent<Animator>();
        coins = 110;
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
        if (control)
        {
            if (press)
            {
                Run();
                horizontalInput = Controller.side;
                return;
            }
            anim.SetTrigger("Idle");
        }
    }
    private void Run()
    {
        anim.SetTrigger("Run");

        move = CountMove();
        rb.MovePosition(move);
    }
    private Vector3 CountMove()
    {
        forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        move = rb.position + forwardMove + horizontalMove;
        move.x = Flip(move.x);

        return move;
    }
    private float Flip(float x)
    {
        if (x > borderX) x = borderX;
        else if (x < -borderX) x = -borderX;

        return x;
    }
}
