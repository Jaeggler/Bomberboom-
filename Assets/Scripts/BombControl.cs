using UnityEngine;
using System.Collections.Generic;

public class BombControl : MonoBehaviour {

	public BoardManager _bm;
	public GameObject FireTile;
	public int FirePower;
	//private float timer;

	// Update is called once per frame
	void OnEnable (){
		BombDetonation ();
	}

	void BombDetonation (){
		Destroy (gameObject, 2.0f);
	}

	void OnDestroy (){
		FirePath (transform.position);
	}

	void FirePath (Vector3 bombPos){
		List <Vector3> FirePathlist = new List <Vector3> ();

		FirePathlist.Add (bombPos);
		//GameObject fireNucleos = Instantiate (FireTile, bombPos, Quaternion.identity) as GameObject;

		for (float i = 1; i <= FirePower; i++) {
			if (!_bm.SolidTile.Contains (new Vector3 ((bombPos.x + i), bombPos.y, 0.0f))) {
				FirePathlist.Add (new Vector3 ((bombPos.x + i), bombPos.y, 0.0f));
			} else {
				return;
			}
		}

		for (float i = 1; i <= FirePower; i++) {
			if (!_bm.SolidTile.Contains (new Vector3 ((bombPos.x + (i*-1)) , bombPos.y ,0.0f))) {
				FirePathlist.Add (new Vector3 ((bombPos.x + (i*-1)) , bombPos.y ,0.0f));
			} else {
				return;
			}
			//GameObject firePathHorMinus = Instantiate (FireTile, new Vector3(((bombPos.x + i)*-1) , bombPos.y ,0.0f), Quaternion.identity) as GameObject;

		}
		for (float j = 1; j <= FirePower; j++) {

			FirePathlist.Add (new Vector3 (bombPos.x , (bombPos.y + j) , 0.0f));
			//GameObject firePathHorPlus = Instantiate (FireTile, new Vector3(bombPos.x ,(bombPos.y + j) , 0.0f), Quaternion.identity) as GameObject;

			FirePathlist.Add (new Vector3 (bombPos.x , (bombPos.y + (j * -1)), 0.0f));
			//GameObject firePathHorMinus = Instantiate (FireTile, new Vector3(bombPos.x , ((bombPos.y + j) * -1), 0.0f), Quaternion.identity) as GameObject;
		}
		foreach (Vector3 point in FirePathlist) {
			GameObject FirePathInstance = Instantiate (FireTile, point, Quaternion.identity) as GameObject;
			Destroy (FirePathInstance, 2.0f);
		}
	}
}
