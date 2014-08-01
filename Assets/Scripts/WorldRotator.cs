using UnityEngine;
using System.Collections;

public class WorldRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(Mathf.Sin(Time.time * 0.2f) * 8, transform.localPosition.y, Mathf.Cos(Time.time * 0.3f) * 8);
	}
}
