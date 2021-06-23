using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDesapier : MonoBehaviour
{
    public void StartDesapier()
    {
        StartCoroutine(Desapier(transform.gameObject));
    }

    IEnumerator Desapier(GameObject obj)
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(3f);
        obj.SetActive(true);
    }
}
