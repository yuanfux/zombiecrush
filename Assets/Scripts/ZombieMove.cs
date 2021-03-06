﻿using UnityEngine;
using System.Collections;

public class ZombieMove : MonoBehaviour
{
	public static GameObject plane;// = GameObject.Find("Plane");
	private ObjectPool objectPool;
	public float speed = 2f;
	public bool collided;
	private float topY = 1.5f;
	// Use this for initialization
	void Start ()
	{
		objectPool = GameObject.Find("MainCamera").GetComponent<ObjectPool>(); 

		plane = GameObject.Find ("Plane");
		collided = false;
	}

	void OnEnable(){
		this.rigidbody.constraints =  RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		transform.rotation = Quaternion.Euler(0, 180, 0);
		collided = false;
	}

	
	// Update is called once per frame
	void Update ()
	{
		if (!collided) {
						Vector3 pos = transform.position;
						pos.z -= speed * Time.deltaTime;
						transform.position = pos;

						if (transform.position.z < -ZombieFactory.start) {
				objectPool.putIn (this.gameObject);
								ScoreBoard.goBeyondBound ();
						}
			if (this.gameObject.transform.position.y > topY) {
				this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, topY, this.gameObject.transform.position.z);
			}	

				} 


	}

	public void afterCollide() {
		if (!collided) {
						collided = true;
						rigidbody.constraints = RigidbodyConstraints.None;
				}
	}

	public bool getCollided(){
		return collided;

	}

}
