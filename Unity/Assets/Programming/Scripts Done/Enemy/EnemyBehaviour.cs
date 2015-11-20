/* 7S_AI_001
 * AI Functionality Script
 * Scripted by Danial
 */

using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float agroRange;
	public float attackRange;
	public int damageValue;

	public Transform target;

	//connect animations to these values in mecanim
	public bool attacking;
	public bool damaged;

	void Start () {
	
	}
	

	void Update () {
		Agro();
	}

	void Agro() {
		// distance calculation between enemy and target
		float distance = Vector3.Distance(transform.position, target.position);

		// enemy focus on target
		if (distance < agroRange) {
			transform.LookAt(target);
			print("targeted");
			attacking = false;
			// range of attack
			if (distance < attackRange) {
				/*play animation
				attacking = true;*/
				if (attacking == true) {
					print("attacking");
					DoDamage();
					attacking = false;
				}
			}
		}
	}


	// Functions that influence damage and health
	void DoDamage() {
		target.GetComponent<AiHpScript>().GetDmg(damageValue);
	}
}