/* 7S_CWAB_001
 * Cowboy Ability Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class CowboyAbilityScript : MonoBehaviour {

	public GameObject bullet;
	public GameObject shootPartikel;
	public AudioClip shootSound;
	public Animator anim;
	public GameObject bomb;
	public Transform gunSpawnShot;
	public Transform throwTntSpot;
//	public AudioClip throwSound;

	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			Shoot();
		} else if (Input.GetButtonUp("Fire1")){
			anim.SetBool("Shoot", false);
		}

		if (Input.GetButtonDown("Skill")) {
			Throw();
		} else if (Input.GetButtonUp("Skill")){
			anim.SetBool("Throw", false);
		}
	}

	public void Shoot() {
		anim.SetBool("Shoot", true);
		Instantiate(shootPartikel, gunSpawnShot.position, Quaternion.identity);
		Instantiate(bullet, gunSpawnShot.position, transform.rotation);
		GetComponent<AudioSource>().PlayOneShot(shootSound);
	}

	public void Throw() {
		anim.SetBool("Throw", true);
		Instantiate(bomb, throwTntSpot.position, transform.rotation);
	//	GetComponent<AudioSource>().PlayOneShot(throwSound);
	}

}
