using UnityEngine;
using System.Collections;

public class TnText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.parent.position + new Vector3(-0.5f, 2, 0);
		transform.rotation = Quaternion.identity;
	}
}
