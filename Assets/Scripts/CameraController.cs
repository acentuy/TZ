using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CameraController : MonoBehaviour
{
    [SerializeField] private Transform hero;

    private Vector3 offset;
    private int nullX = 0;
    void Start()
    {
        offset = transform.position-hero.position;
    }
    void Update()
    {
        transform.position = new Vector3(nullX, (offset+hero.position).y, (offset + hero.position).z);
    }
}
