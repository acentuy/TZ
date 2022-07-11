using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public static float side;

    [SerializeField] private float sensetive = 2f;
    private void Update()
    {
        if(HeroController.press)
        MouseMove();
    }
    void MouseMove()
    {
        side = Input.GetAxis("Mouse X")* sensetive;
    }
}
