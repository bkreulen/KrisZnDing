using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pan : MonoBehaviour {

	public int boundary = 50;
	public int speed = 5;

	private int screenWidth;
	private int screenHeight;

	// Use this for initialization
	void Start () {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.mousePosition.x > screenWidth - boundary) {
			transform.position = new Vector3 (transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
		}

		if (Input.mousePosition.x < boundary) {
			transform.position = new Vector3 (transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
		}

		if (Input.mousePosition.y > screenHeight - boundary) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
		}

		if (Input.mousePosition.y < boundary) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
		}
	}
}
