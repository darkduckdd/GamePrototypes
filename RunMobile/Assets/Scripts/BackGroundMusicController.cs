﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicController : MonoBehaviour
{
    [Header("Tags")]
    [SerializeField] private string createdTag;

    private void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag(this.createdTag);
        if(obj != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.gameObject.tag = createdTag;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
