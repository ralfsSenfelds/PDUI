using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursorsUzAttela : MonoBehaviour {
	public AudioSource kurAtskanot;
	public AudioClip koAtskanot;

	public void UzAttela(){
		kurAtskanot.PlayOneShot (koAtskanot);
	}

	public void NoAttela(){
		kurAtskanot.Stop ();
	}
}
