using UnityEngine;
using System.Collections;

public class GhostStun : MonoBehaviour {

	bool lightCheck;
	Flashlight flash;

	public GameObject ghost;

	// Use this for initialization
	void Start () {
		flash = gameObject.GetComponentInChildren<Light>().GetComponentInChildren<Flashlight>();
		flash.setLightOn();
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter (Collider other) {
		if(other.gameObject.name == "Ghost" && flash == true) {
			other.GetComponent<GhostAI>().moveSpeed = 0f;
			StartCoroutine(Wait(5));
		}
	}

	IEnumerator Wait (float time) {
		yield return new WaitForSeconds(time);
		ghost.GetComponent<GhostAI>().moveSpeed = 5f;
	}
}
