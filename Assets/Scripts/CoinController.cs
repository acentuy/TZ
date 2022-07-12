using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
class CoinController : MonoBehaviour
{   
    [SerializeField] private float deltaYPos = 0.15f;
    [SerializeField] private float levitationSpeed = 0.3f;

    private bool moveUp = true;

    private float yPos;

    private Vector3 VectorToMove;
    private void Start()
    {
        yPos = transform.localPosition.y;
    }

    private void FixedUpdate()
    {
        LevitationEffect();
    }
    private void LevitationEffect()
    {
        VectorToMove = transform.position;
        if (moveUp)
        {
            VectorToMove.y += levitationSpeed * Time.deltaTime;
        }
        else
        {
            VectorToMove.y -= levitationSpeed * Time.deltaTime;
        }
        transform.position = VectorToMove;
        if (transform.position.y > yPos + deltaYPos || transform.position.y < yPos - deltaYPos)
        {
            moveUp = !moveUp;
        }
    }
    public void Destroy(Collider collision)=> Destroy(collision.gameObject);
    
}