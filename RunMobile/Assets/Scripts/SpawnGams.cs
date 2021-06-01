using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGams : MonoBehaviour
{
    public float Speed = 10;
    public float Amplitude = 5.5f;
    public Vector3 Target = new Vector3(0, 0.5f, Mathf.Infinity);
    public Transform gem;

    Vector3 point;

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        point = gameObject.transform.position;
        StartCoroutine(Spawn());

        while (true)
        {
            point = Vector3.MoveTowards(point, Target, Time.deltaTime * Speed);
            transform.position = point + transform.right * Mathf.Sin(Time.time) * Amplitude;
            yield return null;
        }
    }

    IEnumerator Spawn()
    {
        Instantiate(gem, transform.position,Quaternion.identity);
        yield return new WaitForSeconds(5.0f);
        StartCoroutine(Spawn());
    }
}
