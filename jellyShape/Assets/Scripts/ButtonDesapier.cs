using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDesapier : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    public void StartDesapier()
    {
        StartCoroutine(Desapier());
    }

    IEnumerator Desapier()
    {
        obj.SetActive(false);
        yield return new WaitForSeconds(3f);
        obj.SetActive(true);
    }
}
