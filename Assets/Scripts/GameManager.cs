using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Hero;

	// Use this for initialization
	void Start () {
		Vector3 StarP = new Vector3 (1, 1, 0.0f);
		Instantiate (Hero, StarP, Quaternion.identity);
	}
}
