using UnityEngine;
using UnityEngine.SceneManagement;

class FinishController : MonoBehaviour
{
    public void ButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
