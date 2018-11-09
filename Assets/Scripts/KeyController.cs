﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	private int local;
	public int killed = 0;
	public int onda = 0;
	public GameObject esqueleto;
	public GameObject lobo;

	private void Awake()
	{
		local = Random.Range(1, 5);
	}

	// Use this for initialization
	void Start () {
		switch(local){
			case 1:
				this.gameObject.transform.position = new Vector3(-39.3f, 27.9f, -0.278f);
				break;
			case 2:
				this.gameObject.transform.position = new Vector3(10.58f, 12.08f, -0.278f);
				break;
			case 3:
				this.gameObject.transform.position = new Vector3(-40.14f, 0.88f, -0.278f);
				break;
			case 4:
				this.gameObject.transform.position = new Vector3(9.5f, 29.4f, -0.278f);
				break;
			case 5:
				this.gameObject.transform.position = new Vector3(17.2f, -8.6f, -0.278f);
				break;
		}
	}
	//-39.3, 27.9, -0.278
	//10.58, 12.08, -0.278
	//-40.14, 0.88, -0.278
	//9.5, 29.4, -0.278
	//17.2, -8.6, -0.278

	// Update is called once per frame
	void Update () {
		if (killed == 0 && onda == 1)
		{
			Instantiate(esqueleto, new Vector3(-19.43f, 12.46f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-29.26f, 6.94f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-24.1f, -1.39f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-22.23f, 0.33f, -0.278f), Quaternion.identity);
			onda = 2;
		}
		if (killed == 4 && onda == 2)
		{
			Instantiate(esqueleto, new Vector3(-1.87f, 27.35f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(9.24f, 21.91f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-1.87f, 17.6f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(10.37f, 18.13f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-7.01f, 15.79f, -0.278f), Quaternion.identity);
			onda = 3;
		}
		if (killed == 9 && onda == 3)
		{
			Instantiate(esqueleto, new Vector3(-12.45f, -6.44f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-17.52f, -1.28f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-23.52f, -7.38f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-0.16f, -8.79f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(1.43f, -4.01f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(8.93f, -7.48f, -0.278f), Quaternion.identity);
			onda = 4;
		}
		if (killed == 15 && onda == 4)
		{
			Instantiate(esqueleto, new Vector3(-28.14f, 32.95f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-24.04f, 22.99f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-38.44f, 19.96f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-39.45f, 24.2f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-36.83f, 27.9f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-26.67f, 33.82f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-12.07f, 23.55f, -0.278f), Quaternion.identity);
			onda = 5;
		}
		if (killed == 22 && onda == 5)
		{
			Instantiate(esqueleto, new Vector3(5.69f, 10.95f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(7.24f, 5.57f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(13.97f, 5.57f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(15.11f, 10.34f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(12.76f, 14.31f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(15.65f, 3.48f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(-2.92f, 9f, -0.278f), Quaternion.identity);
			Instantiate(esqueleto, new Vector3(4.88f, 11.56f, -0.278f), Quaternion.identity);
			onda = 6;
		}
		if (killed == 30 && onda == 6)
		{
			//Abrir Portão
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Player")
		{
            onda = 1;
			this.gameObject.transform.position = new Vector3(99f, 99f, -0.278f);
            SoundManagerScript.PlaySound("pickupkey");
        }
	}
}

//onda 1
//-19.43f, 12.46f, -0.278f
//-29.26f, 6.94f, -0.278f
//-24.1f, -1.39f, -0.278f
//-22.23f, 0.33f, -0.278f

//onda 2
//-1.87f, 27.35f, -0.278f
//9.24f, 21.91f, -0.278f
//-1.87f, 17.6f, -0.278f
//10.37f, 18.13f, -0.278f
//-7.01f, 15.79f, -0.278f

//onda 3
//-12.45f, -6.44f, -0.278f
//-17.52f, -1.28f, -0.278f
//-23.52f, -7.38f, -0.278f
//-0.16f, -8.79f, -0.278f
//1.43f, -4.01f, -0.278f
//8.93f, -7.48f, -0.278f

//onda 4
//-28.14f, 32.95f, -0.278f
//-24.04f, 22.99f, -0.278f
//-38.44f, 19.96f, -0.278f
//-39.45f, 24.2f, -0.278f
//-36.83f, 27.9f, -0.278f
//-26.67f, 33.82f, -0.278f
//-12.07f, 23.55f, -0.278f

//onda 5
//5.69f, 10.95f, -0.278f
//7.24f, 5.57f, -0.278f
//13.97f, 5.57f, -0.278f
//15.11f, 10.34f, -0.278f
//12.76f, 14.31f, -0.278f
//15.65f, 3.48f, -0.278f
//-2.92f, 9f, -0.278f
//4.88f, 11.56f, -0.278f