﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlaceInfrastructure3 : MonoBehaviour {

	public GameObject infra4;
	GameObject newInfra1;
	Vector3 amountInfra1;
	int contInfra1;
	public bool flagInfra4;
	public PlaceInfrastructure2 scriptinfra3;
	public GameObject sliderMineral;
	public GameObject sliderBioplastic;

	// Use this for initialization
	void Start ()
	{
		sliderMineral = GameObject.Find ("SliderMineral");
		sliderBioplastic = GameObject.Find ("SliderBioplastico");
		scriptinfra3 = gameObject.GetComponent<PlaceInfrastructure2> ();
		flagInfra4 = false;
		contInfra1 = 0;
		amountInfra1 = new Vector3 (-0.5f, 0.5f, 10f);
	}

	// Update is called once per frame
	void Update ()
	{
		if(!flagInfra4 && scriptinfra3.flagInfra3)
		{
			if(SixenseInput.Controllers[0].GetButton(SixenseButtons.BUMPER) && SixenseInput.Controllers[1].GetButton(SixenseButtons.BUMPER))
			{
				contInfra1++;
				if(contInfra1 == 1)
				{
					newInfra1 = (GameObject)Instantiate (infra4, gameObject.transform.position + amountInfra1, Quaternion.identity);
					newInfra1.gameObject.transform.Rotate (-90f, 90f, 0f);
					newInfra1.gameObject.transform.parent = gameObject.transform;
				}
				if(newInfra1)
				{
					//		newInfra1.gameObject.transform.position = gameObject.transform.position + amountInfra1;
					newInfra1.GetComponent<Rigidbody> ().useGravity = false;
					newInfra1.GetComponent<Rigidbody> ().isKinematic = true;
				}
			}
			if(SixenseInput.Controllers[0].GetButtonUp(SixenseButtons.BUMPER) && SixenseInput.Controllers[1].GetButtonUp(SixenseButtons.BUMPER))
			{
				sliderMineral.GetComponent<Slider> ().value = sliderMineral.GetComponent<Slider> ().value - 0.09f;
				sliderBioplastic.GetComponent<Slider> ().value = sliderBioplastic.GetComponent<Slider> ().value - 0.05f;
				newInfra1.gameObject.transform.parent = null;
				newInfra1.GetComponent<Rigidbody> ().useGravity = true;
				newInfra1.GetComponent<Rigidbody> ().isKinematic = false;
				flagInfra4 = true;
			}
		}
	}
}
