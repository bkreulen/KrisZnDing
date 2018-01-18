using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class Status : NetworkBehaviour {

	private float movementMod = 1;
	public float movSpeed = 5;


	public const int maxHealth = 100;

	[SyncVar(hook = "OnChangeHealth")]
	public int health = maxHealth;

	public RectTransform healthBar;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<NavMeshAgent> ().speed = movSpeed * movementMod;
		
	}

	public void SetMovementMod(float mod, float duration) {
		StartCoroutine (WaitForTime(mod, duration));
	}

	IEnumerator WaitForTime(float mod, float sec) {
		movementMod = mod;
		yield return new WaitForSeconds (sec);
		movementMod = 1;
	}

	public void TakeDamage(int amount) {
		if (!isServer) {
			return;
		}

		health = health - amount;
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}
		
	void OnChangeHealth (int health) {
		healthBar.sizeDelta = new Vector2 (health, healthBar.sizeDelta.y);
	}
}
