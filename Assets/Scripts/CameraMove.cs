using UnityEngine;
class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform hero;

    private Vector3 offset;

    private int nullX = 0;
    private int nullY = 2;
    void Start()
    {
        offset = transform.position - hero.position;
    }
    void Update()
    {
        Move();
    }
    private void Move() => transform.position = new Vector3(nullX, nullY, (offset + hero.position).z);
}
