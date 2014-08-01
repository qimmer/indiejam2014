using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int PlayerIndex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

        if (gameObject.rigidbody2D.velocity.y < 6 && Input.GetButton("Player" + PlayerIndex + "_Throttle"))
        {
            gameObject.rigidbody2D.AddForce(new Vector2(0.0f, 600.0f));
        }

        if (!Input.GetButton("Player" + PlayerIndex + "_Throttle"))
            gameObject.rigidbody2D.AddForce(new Vector2(0.0f, 200.0f));

        gameObject.rigidbody2D.AddForce(new Vector2(Input.GetAxis("Player" + PlayerIndex + "_Axis") * 140.0f, 0));

        gameObject.rigidbody2D.velocity = new Vector2(Mathf.Clamp(gameObject.rigidbody2D.velocity.x * 0.93f, -25, 25), Mathf.Clamp(gameObject.rigidbody2D.velocity.y, -4, 12));

        if( Input.GetButton("Player" + PlayerIndex + "_Detach") )
        {
            transform.FindChild("Trigger").gameObject.GetComponent<RopeTrigger>().ReleaseBox();
        }
	}

}
