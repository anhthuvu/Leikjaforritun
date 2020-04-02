using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour {

	public int gemValue = 50;

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			ScoreManager.instance.ChangeScore(gemValue);
		}
	}
}