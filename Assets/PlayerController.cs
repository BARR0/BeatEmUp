using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public const float DEFAULT_SPEED = 2;

	public GameObject prefab;
	public Animator anim;
	public Transform sprite;
    public string inputAxis;
	public int life;

	private float speed;
	private float speedMultiplier; //if we use a speedBoost item
    private int level;

	private float oldAtk;
	private float oldAtk2;
	private float oldAtk3;

	void Awake(){
		GameController.addPlayer (this);
	}

    // Use this for initialization
    void Start() {
        this.oldAtk = 0;
        this.oldAtk2 = 0;
        this.oldAtk3 = 0;
        this.speedMultiplier = 1;
        this.speed = DEFAULT_SPEED;
        this.level = 1;
		//this.inputAxis = GameController.controllers [this.prefab];
		//print(this.prefab.name);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.life <= 0) {
			GameController.removePlayer (this);
			Destroy (this.gameObject);
		}

		float h = Input.GetAxis ("Horizontal"+inputAxis);
		float v = Input.GetAxis ("Vertical" + inputAxis);
		float atk = Input.GetAxis ("Fire1" + inputAxis);
		float atk2 = Input.GetAxis ("Fire2" + inputAxis);
		float atk3 = Input.GetAxis ("Fire3" + inputAxis);
		//Debug.Log (this.gameObject.name + ": " + atk + atk2 + atk3 + "");

		AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo (0);

		if ( currentState.IsName("player_atk") || currentState.IsName("player_atk2") || currentState.IsName("player_atk3") || currentState.IsName("player_hurt")) {
			oldAtk = 1;
			oldAtk2 = 1;
			oldAtk3 = 1;
			speed = 0;
		} else {
			speed = DEFAULT_SPEED * speedMultiplier;
			if (h > 0) {
				sprite.transform.rotation = Quaternion.Euler (0, 180, 0);
			}
			if (h < 0) {
				sprite.transform.rotation = Quaternion.Euler (0, 0, 0);
			}
		}

		if (atk == 1 && oldAtk == 0) {
			anim.SetTrigger ("atk");
			Debug.Log ("Attack");
		}


		if (atk2 == 1 && oldAtk2 == 0) {
			anim.SetTrigger ("atk2");
			Debug.Log ("Attack");
		}

		if (atk3== 1 && oldAtk3 == 0 && level >= 3) {
			anim.SetTrigger ("atk3");
			Debug.Log ("Attack");
		}

		anim.SetFloat ("walk", Mathf.Abs(h) + Mathf.Abs(v));
		Vector3 v3 = new Vector3 (h, 0, v);
		transform.Translate (v3.normalized * speed * Time.deltaTime);

		oldAtk  = atk;
		oldAtk2 = atk2;
		oldAtk3 = atk3;
	}

	void OnTriggerEnter (Collider c) {
		if (life > 0 && c.gameObject.layer == 11) {
			life--;
			anim.SetTrigger ("hurt");
		}
		if (life <= 0) {
			//CapsuleCollider playerCol = this.GetComponent<CapsuleCollider> ();
			//playerCol.enabled = false;
			anim.SetTrigger ("dead");
		}
	}

    public int Level{
        get { return this.level; }
    }
	public void gainLevel(){
		this.level++;
	}
}
