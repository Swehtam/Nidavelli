﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int health;
    public int currentHealth;
    private SpriteRenderer m_SpriteRenderer;
    private Color m_NewColor;
    private Color buffer;

    // Use this for initialization
    void Start ()
    {
        currentHealth = health;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        buffer = m_SpriteRenderer.color;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (currentHealth <= 0)
            Destroy(gameObject);
	}

    public void HurtEnemy(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(Wait(0.5f));
    }

    public IEnumerator Wait(float time)
    {
        m_SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(time);
        m_SpriteRenderer.color = buffer;
    }
}
