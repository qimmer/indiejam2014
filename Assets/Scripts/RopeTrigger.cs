using UnityEngine;
using System.Collections;

public class RopeTrigger : MonoBehaviour {

    public GameObject attachedObject = null;
    float lastGrabTime = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Block" && attachedObject == null && Time.time > lastGrabTime + 1.0f)
        {
            if (col.gameObject.GetComponent<Block>().Owner != null)
                return;

            col.gameObject.GetComponent<DistanceJoint2D>().enabled = true;
            col.gameObject.GetComponent<DistanceJoint2D>().connectedBody = rigidbody2D;
            col.gameObject.GetComponent<Block>().Owner = gameObject;
            attachedObject = col.gameObject;
            lastGrabTime = Time.time;
        }
    }

    public void ReleaseBox()
    {
        if( attachedObject != null )
        {
            attachedObject.GetComponent<Block>().Owner = null;
            attachedObject.GetComponent<DistanceJoint2D>().connectedBody = null;
            attachedObject.GetComponent<DistanceJoint2D>().enabled = false;
            attachedObject = null;
            lastGrabTime = Time.time;
        }
    }
}
