using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public int PlayerIndex;

	public float speed = 0;
	public float maxVelocityBonus = 0;

    // Use this for initialization
    void Start()
    {
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsWebPlayer || Application.platform == RuntimePlatform.WindowsEditor)
		{
			print ("Running on Windows");
		}
		if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXWebPlayer || Application.platform == RuntimePlatform.OSXEditor)
		{
			print ("Running on MacOS");
		}
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (gameObject.rigidbody2D.velocity.y < 6 && Input.GetButton("Player" + PlayerIndex + "_Throttle"))
        {
            gameObject.rigidbody2D.AddForce(new Vector2(0.0f, (550.0f + speed)));
        }

        if (!Input.GetButton("Player" + PlayerIndex + "_Throttle"))
            gameObject.rigidbody2D.AddForce(new Vector2(0.0f, 10.0f));

        gameObject.rigidbody2D.AddForce(new Vector2(Input.GetAxis("Player" + PlayerIndex + "_Axis") * (340.0f + speed), 0));

		gameObject.rigidbody2D.velocity = new Vector2(Mathf.Clamp(gameObject.rigidbody2D.velocity.x * 0.93f, (-7-maxVelocityBonus), (7+maxVelocityBonus)), Mathf.Clamp(gameObject.rigidbody2D.velocity.y, (-4-maxVelocityBonus), (maxVelocityBonus+10)));

        if (Input.GetButtonUp("Player" + PlayerIndex + "_Detach"))
        {
			if(transform.FindChild("Trigger").gameObject.GetComponent<RopeTrigger>().attachedObject)
				transform.FindChild("Trigger").gameObject.GetComponent<RopeTrigger>().attachedObject.GetComponent<Block>().CountDown();
            transform.FindChild("Trigger").gameObject.GetComponent<RopeTrigger>().ReleaseBox();
        }
    }

    void Update()
    {
        Vector3 vel = new Vector3(rigidbody2D.velocity.x, Mathf.Max(rigidbody2D.velocity.y, 0.0f), 0.0f);
        audio.pitch = 0.9f + vel.magnitude / 8.0f + (float)(PlayerIndex-1) * 0.4f;
        audio.volume = vel.magnitude / 60.0f;
    }

}