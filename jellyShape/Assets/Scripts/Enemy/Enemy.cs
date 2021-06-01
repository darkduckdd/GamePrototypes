using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed=10;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(DestroyGameObject(gameObject));
    }
 
    private void FixedUpdate()
    {
        Move(transform.up);
    }

    public virtual void Move(Vector3  direction)
    {
        _rb.MovePosition(transform.position + (direction * Time.deltaTime * speed));
    }

    IEnumerator DestroyGameObject(GameObject obj)
    {
        yield return new WaitForSeconds(15f);
        Destroy(obj); 
    }

    protected static void GameOver()
    {
        ScoreManager.SaveMoney();
        SceneTransition.SwitchToScene(2);
    }
}
