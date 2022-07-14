using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class CallFinishScreen : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private AudioSource winSound;

    [SerializeField] private GameObject winScreen;

    [SerializeField] private Animator anim;

    private Vector3 finishPos = new Vector3(0, -0.6f, 100);
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            winSound.Play();
            anim.SetTrigger("Finish");

            rb.transform.position = finishPos;
            HeroController.control = false;
            winScreen.SetActive(true);
        }
    }
}
