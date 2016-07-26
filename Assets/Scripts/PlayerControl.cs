using UnityEngine;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {


	public float speed;
	public GameObject bomb;
	[HideInInspector]
	public int SetBomb;
	public int FirePower = 1;

	private int BombLimit;
	private Rigidbody2D _rb;

    void OnEnable () {
		FirePower = 3;
		BombLimit = 1;
		SetBomb = 0;

		_rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerMovement ();
		LeaveBomb ();
	}

	Vector3 PositionComparison(float X, float Y){
		float PosX = Mathf.Round(X);
		float PosY = Mathf.Round(Y);
		Vector3 PosAsInt = new Vector3 (PosX, PosY, 0.0f);
		return PosAsInt;
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
			Vector3 BombPos = PositionComparison (transform.position.x, transform.position.y);
			GameObject BombInstance = Instantiate (bomb, BombPos, Quaternion.identity) as GameObject;
			BombInstance.GetComponent<BombControl> ().FirePower = FirePower;
		}
	}
}

