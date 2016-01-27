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
	public float swordLength = 1f;
	public RaycastHit hit;

	void Update () {
		if(Input.GetButtonDown("Fire1")){
			anim.SetBool("Attack1", true);
			GetComponent<AudioSource>().PlayOneShot(attackSound);
			CheckDmg();
		} else if (Input.GetButtonUp("Fire1")){
			anim.SetBool("Attack1", false);
		}
	}

	public void CheckDmg(){
		Debug.DrawRay(transform.position, transform.forward, Color.green);
		if(Physics.Raycast(transform.position, transform.forward, out hit, swordLength)){
			if (hit.transform.tag == "Enemy"){
				GiveDmg(hit.transform.gameObject);
				KnockBack(hit.transform.GetComponent<Collider>());
			}
		}
	}

	public void GiveDmg(GameObject enemy) {
		enemy.GetComponent<AiHpScript>().GetDmg(dmg);
		GetComponent<AudioSource>().PlayOneShot(attackSound);
	}
}
