/* 7S_DMG_001
 * DMG Script for Melee
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class FistAttackScript : KnockBackScript {
	public int dmg = 1;
	public Animator anim;
	public RandomParticleSelector randomParticle;
	public AudioClip[] punchSound;
	public float punchRange = 0.5f;
	public RaycastHit hit;
	
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			anim.SetBool("Attack1", true);
			randomParticle.ParticleRandomizer();
			GetComponent<AudioSource>().PlayOneShot(punchSound[randomParticle.selectedInt]);
			CheckDmg();
		} else if (Input.GetButtonUp("Fire1")){
			anim.SetBool("Attack1", false);
		}
	}
	
	public void CheckDmg(){
		Debug.DrawRay(transform.position, transform.forward, Color.green);
		if(Physics.Raycast(transform.position, transform.forward, out hit, punchRange)){
			if (hit.transform.tag == "Enemy"){
				GiveDmg(hit.transform.gameObject);
				KnockBack(hit.transform.GetComponent<Collider>());
			}
		}
	}
	
	public void GiveDmg(GameObject enemy) {
		enemy.GetComponent<AiHpScript>().GetDmg(dmg);
	}
}
