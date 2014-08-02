using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    float DamageMultiplier = 0.1f;
    GameObject owner = null;

    public float Health;
    public float Armor;
    public float Weight;
	public bool isTNT = false;
	public float fuseTime = 0;
	public float fuseLength = 10;

	public GameObject explosion;
	GameObject explosionHolder;
	float TnTick;

	// Use this for initialization
	void Awake () 
	{
		TnTick = fuseLength;
		fuseTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(fuseTime != 0)
		{
			if (fuseTime + fuseLength > Time.time)
			{
				int fuseCurrent = Mathf.Abs(Mathf.RoundToInt(Time.time- fuseTime - fuseLength));

				if (fuseCurrent != TnTick)
				{
					print (Mathf.RoundToInt(Time.time- fuseTime - fuseLength));
					TnTick = fuseCurrent;
					audio.Play();
				}

				transform.FindChild("TnText").GetComponent<TextMesh>().text = "" + fuseCurrent;

				if(fuseCurrent <= 0)
				   transform.FindChild("TnText").GetComponent<TextMesh>().text = "";

			}

			if (fuseTime + fuseLength < Time.time)
			{
				if (isTNT)
				{
					isTNT = false;
					GameObject.Find("GameManager").GetComponent<GameManager>().CreateExplosion(transform.position, 1);
					//explosionHolder = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
					//Destroy(explosionHolder, 1);
				}
				gameObject.tag = "Explosion";
				if(GetComponent<CircleCollider2D>().radius < 4)
				{
					GetComponent<CircleCollider2D>().radius = GetComponent<CircleCollider2D>().radius + 0.5f;
				}
				else
				{
					print("BOOM!");
					fuseTime = 0;

					Destroy (gameObject);
				}

			}
		}
	}

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
		if(col.gameObject.tag == "Explosion")
			Damage ();
        //Health -= (col.relativeVelocity.magnitude * DamageMultiplier) / Armor;
    }

	public void CountDown()
	{
		//print ("Countdown");
		if(isTNT)
			fuseTime = Time.time;
	}

	public void Damage()
	{
		print ("Smash!");
		Health--;
		if(Health <= 1 && isTNT)
		{
			fuseTime = Time.time;
			fuseLength = 1;
			return;
		}
		if(Health <= 0)
		{
			//if (owner)
			//	owner.transform.FindChild("Trigger").gameObject.GetComponent<RopeTrigger>().ReleaseBox();
			explosionHolder = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy (explosionHolder, 0.7f);
			Destroy (gameObject);
			print ("Crash!");

		}
	}

    public GameObject Owner
    {
        get
        {
            return this.owner;
        }
        set
        {
            this.owner = value;
        }
        
    }
}
