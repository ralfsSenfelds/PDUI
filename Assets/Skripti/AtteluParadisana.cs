using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtteluParadisana : MonoBehaviour {
    public GameObject bins;
    public GameObject lacitis;
    public GameObject tante;
    public GameObject masina;
    public GameObject paKreisi;
    public GameObject paLabi;
	public GameObject kurRadit;
	public Sprite[] koRadit;
	public GameObject slaideris1;
	public GameObject slaideris2;

    public void binaAttelosana(bool vertiba)
    {
        bins.SetActive(vertiba);
        paKreisi.GetComponent<Toggle>().interactable = vertiba;
        paLabi.GetComponent<Toggle>().interactable = vertiba;
    }

    public void lacaAttelosana(bool vertiba)
    {
        lacitis.SetActive(vertiba);
    }

    public void tantesAttelosana(bool vertiba)
    {
        tante.SetActive(vertiba);
    }

    public void masinasAttelosana(bool vertiba)
    {
        masina.SetActive(vertiba);
    }

    public void PaKreisiBins()
    {
        bins.transform.localScale = new Vector2(1, 1);
    }

    public void PaLabiBins()
    {
        bins.transform.localScale = new Vector2(-1, 1);
    }

	public void izkritosais(int indekss){
		if (indekss == 0)
			kurRadit.GetComponent<Image> ().sprite = koRadit [0];

		else if(indekss == 1)
			kurRadit.GetComponent<Image> ().sprite = koRadit [1];

		else if(indekss == 2)
			kurRadit.GetComponent<Image> ().sprite = koRadit [2];
	}


	public void mainitLielumu(){
		float pasreizejaVertiba = slaideris1.GetComponent<Slider> ().value;
		kurRadit.transform.localScale = 
			new Vector2 (1f*pasreizejaVertiba, 1f*pasreizejaVertiba);
	}

	public void mainitRotaciju(){
		float pasreizejaVertiba = slaideris2.GetComponent<Slider> ().value;
		kurRadit.transform.localRotation =
			Quaternion.Euler (0, 0, pasreizejaVertiba * 360);
	}
}
