using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {


	public float speed;
	public GameObject bomb;

	private int BombLimit;
	private int SetBomb;
	private Rigidbody2D _rb;

	// Use this for initialization
	void Start () {
		BombLimit = 1;
		SetBomb = 0;

		_rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement ();
		LeaveBomb ();
	}

	void PlayerMovement(){
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Vector3 VectorMovement = new Vector2 (h * speed, v * speed) * Time.deltaTime;
		_rb.velocity = VectorMovement;
	}

	void LeaveBomb (){
		if (Input.GetKeyDown (KeyCode.Space) && SetBomb <= BombLimit) {
			SetBomb++; 
			GameObject BombInstance = Instantiate (bomb, transform.position, Quaternion.identity) as GameObject;
			BombDetonation (BombInstance);
		}
	}

	void BombDetonation (GameObject bomb){
		Destroy (bomb, 3.0f);
		SetBomb--;
	}
}
