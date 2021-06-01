
using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    public GameObject explosion;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerTouch();
        }
        ScoreManager.instance.Score = 10;
    }

    private void PlayerTouch()
    {
        if (explosion != null)
        {
            var particles = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(particles, 1.0f);
        }

        Destroy(this.gameObject);
    }
}
