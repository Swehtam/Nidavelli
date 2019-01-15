﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (player)
        {
            if (player.gameObject.GetComponent<PlayerHealthManager>().died == true)
            {
                LoadingScreenManager.LoadScene("DeathScene");
            }
        }
    }
}