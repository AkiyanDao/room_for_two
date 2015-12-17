using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	} 
}
