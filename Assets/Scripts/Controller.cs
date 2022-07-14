using UnityEngine;
class Controller : MonoBehaviour
{
    [SerializeField] private float sensetive = 2f;

    public static float side;
    private void Update()
    {
        if (HeroController.press) MouseMove();
    }
    private void MouseMove() => side = Input.GetAxis("Mouse X") * sensetive;
}
