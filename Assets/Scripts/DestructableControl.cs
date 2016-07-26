using UnityEngine;
using System.Collections;

public class DestructableControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DesDestroy (){
		Destroy (gameObject);
	}
}
