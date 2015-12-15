/* 7S_AIHP_001
 * AI HP Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class AiHpScript : MonoBehaviour {

	public int maxHP;
	int curHp;
	public GameObject deathParticle;
	public float destroyTime;
	public AudioClip dyingSound;
	public GameObject soundManager;
	public Animator anim;

	void Start() {
		curHp = maxHP;
	}

	public void GetDmg(int dmg) {
		if (curHp - dmg <= 0) {
			Die();
		} else {
			curHp -= dmg;
		}
	}

	public void Die() {
		Instantiate(deathParticle, transform.position, Quaternion.identity);
		anim.SetBool("IsDead", true);
		soundManager.GetComponent<AudioSource>().PlayOneShot(dyingSound);
		Destroy(gameObject, destroyTime);
    }

}
