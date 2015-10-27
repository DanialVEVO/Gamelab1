/* 7S_CWAB_001
 * Cowboy Ability Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class CowboyAbilityScript : MonoBehaviour {

	public GameObject bullet;
//	public GameObject shootPartikel;
//	public AudioClip shootSound;
//	public Animation shootAnim;

	public GameObject bomb;
//	public AudioClip throwSound;
//	public Animation throwAnim;

	void Update() {
		if (Input.GetButtonDown("Hit")) {
			Shoot();
		}

		if (Input.GetButtonDown("Skill")) {
			Throw();
		}
	}

	public void Shoot() {
	//	shootAnim.Play();
	//	Instantiate(shootPartikel, transform.position, Quaternion.identity);
		Instantiate(bullet, transform.position, transform.rotation);
	//	GetComponent<AudioSource>().PlayOneShot(shootSound);
	}

	public void Throw() {
	//	throwAnim.Play();
		Instantiate(bomb, transform.position, transform.rotation);
	//	GetComponent<AudioSource>().PlayOneShot(throwSound);
	}

}
