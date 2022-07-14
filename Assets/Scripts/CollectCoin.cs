using UnityEngine.UI;
using UnityEngine;
class CollectCoin : MonoBehaviour
{
    [SerializeField] private Text coinsText;

    [SerializeField] private GameObject effectStars;
    [SerializeField] private GameObject effectYellowBalls;

    [SerializeField] private AudioSource coinSound;

    private Vector3 deltaPos = new Vector3(0, 1, 0);

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            HeroController.coins += 5;
            coinsText.text = "Coins: " + HeroController.coins.ToString();
            Instantiate(effectStars, transform.position + deltaPos, Quaternion.identity);
            Instantiate(effectYellowBalls, transform.position + deltaPos, Quaternion.identity);
            coinSound.Play();
            Destroy(this.gameObject);
        }
    }
}
