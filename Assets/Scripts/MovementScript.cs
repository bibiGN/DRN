﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementScript : MonoBehaviour {

	public GameObject enemy;
	public float speedMovement;
	public GameObject motherBase;
	
	private List<GameObject> listUnitsAround = new List<GameObject>();
	
	// Update is called once per frame
	void Update () {
		listUnitsAround = new List<GameObject>();
		
		this.rigidbody.velocity = new Vector3(0.0f, this.rigidbody.velocity.y, 0.0f);
		
		listUnitsAround = motherBase.GetComponent<BaseManagerScript>().GetAlliedAround(this.gameObject, 4.0f);
		
		if(listUnitsAround.Count > 0)
		{
			Vector3 direction;
			
			direction = (listUnitsAround[0].transform.position - this.transform.position);
			
			direction.Normalize();
			
			direction *= speedMovement * 10 * Time.deltaTime;
			
			this.rigidbody.AddRelativeForce(direction);
			
		}
		
		
		enemy = motherBase.GetComponent<BaseManagerScript>().GetClosestEnemy(this.transform.position);
		
		
		if(enemy != null)
		{
			float distance = Vector3.Distance(this.transform.position, enemy.transform.position);

			if(distance > 2f) {
				this.transform.LookAt(new Vector3(enemy.transform.position.x, 0f, enemy.transform.position.z));
				this.rigidbody.AddRelativeForce(0.0f,0.0f,1.0f * speedMovement * 10 * Time.deltaTime );
			}
		}
	}
}
