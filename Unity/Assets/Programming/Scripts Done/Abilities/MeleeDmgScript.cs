/* 7S_DMG_001
 * DMG Script for Melee Weapons
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class MeleeDmgScript : KnockBackScript {
	
	public int dmg;
	public Animator anim;
	public AudioClip attackSound;
	public GameObject attackParticle;
	public float swordLength = 5f;
	public RaycastHit hit;

	void Update () {
		if(Input.GetButtonDown("Fire1")){
			anim.SetBool("Attack1", true);
			CheckDmg();
		} else if (Input.GetButtonUp("Fire1")){
			anim.SetBool("Attack1", false);
		}
	}

	public void CheckDmg(){
		//Debug.DrawRay(transform.position, transform.forward, Color.green);
		///if(Physics.Raycast(transform.position, transform.forward, out hit, swordLength)){
		//	if (hit.gameObject.tag == "Enemy"){
		//		GiveDmg(hit.gameObject);
		//		KnockBack(coll);
		//	}
		//}
	}

	public void GiveDmg(GameObject enemy) {
		enemy.GetComponent<AiHpScript>().GetDmg(dmg);
		GetComponent<AudioSource>().PlayOneShot(attackSound);
		Instantiate(attackParticle, transform.position, Quaternion.identity);
	}

//	void OnCollisionEnter(Collision coll) {
//		if (coll.gameObject.tag == "Enemy") {
//			GiveDmg(coll.gameObject);
//			KnockBack(coll);
//		}
//	}
}
