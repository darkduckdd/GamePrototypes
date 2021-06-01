using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObstacleBehaviour : MonoBehaviour
{
    [Tooltip("Как долго ждать перезапуска сцены")]
    public float waitTime = 11.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CarMovement>())
        {
            collision.gameObject.transform.SendMessage("PlaySmoke");
        }
        Invoke("ResetGame", waitTime);

    }

    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
