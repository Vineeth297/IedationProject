using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camouflage : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Player")) return;
		
		print("Undetectable");
		other.tag = "Hidden";
	}
	
	private void OnTriggerExit(Collider other)
	{
		if (!other.CompareTag("Hidden")) return;
		
		print("Detectable");
		other.tag = "Player";
	}
}
