using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
    public static bool press = false;

    [SerializeField] private float speed = 50f;
    [SerializeField] private float horizontalMultiplier = 2;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private Animator anim;

    [SerializeField] private CoinController controller;

    [SerializeField] private AudioSource coinSound;

    [SerializeField] private Text coinsText;

    [SerializeField] private GameObject effectStars;
    [SerializeField] private GameObject effectYellowBalls;

    private Vector3 deltaPos = new Vector3(0, 1, 0);

    private float horizontalInput;
    private int borderX = 8;
    private int coins = 110;

    private Vector3 forwardMove, horizontalMove, move;

    private void Start() {

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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Gold")
        {            
            coins += 5;
            coinsText.text = "Coins: " + coins.ToString();
            Instantiate(effectStars, transform.position + deltaPos, Quaternion.identity);
            Instantiate(effectYellowBalls, transform.position + deltaPos, Quaternion.identity);
            coinSound.Play();
            controller.Destroy(collision);
        }

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
