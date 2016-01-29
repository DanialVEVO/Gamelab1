/* 7S_DMG_001
 * DMG Script for Melee Weapons
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class MeleeDmgScript : KnockBackScript {

	public RandomParticleSelector randomParticle;
	public GameObject cowboyAbility;
	public GameObject heroAbility;
	public GameObject astroAbility;
	public int dmg = 1;
	public Animator anim;
	public AudioClip attackSound;
	public AudioClip saberSound;
	public AudioClip[] punchSound;
	public float hitRange = 2f;
	public RaycastHit hit;
	public Vector3 rayOffset = new Vector3(0, 1f, 0);

	void Update () {

		//code not very clean due last minute fix
		if(Input.GetButtonDown("Fire1")){
			if (cowboyAbility.activeInHierarchy == false){
				anim.SetBool("Attack1", true);
				if (heroAbility.activeInHierarchy == false){
					if (astroAbility.activeInHierarchy == false){
						GetComponent<AudioSource>().PlayOneShot(attackSound);
						CheckDmg();
					} else {
						GetComponent<AudioSource>().PlayOneShot(saberSound);
						CheckDmg();
					}
				} else {
					randomParticle.ParticleRandomizer();
					GetComponent<AudioSource>().PlayOneShot(punchSound[randomParticle.selectedInt]);
					CheckDmg();
				}
			}
		} else if (Input.GetButtonUp("Fire1")){
			anim.SetBool("Attack1", false);
		}
	}

	public void CheckDmg(){
		Debug.DrawRay(transform.position + rayOffset, transform.forward, Color.green, hitRange);
		if(Physics.Raycast(transform.position + rayOffset, transform.forward, out hit, hitRange)){
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
