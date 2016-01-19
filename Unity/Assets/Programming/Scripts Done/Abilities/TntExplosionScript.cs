/* 7S_TNT_001
 * TNT Explosion (Cowboy throw) Script
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class TntExplosionScript : KnockBackScript {
	
	public float explodeTimer;
	public float destroyTime;
	public int dmg;
	public float dmgDistance;
	public GameObject explodeEffect;
	public AudioClip explodeSound;
	
	private GameObject player;
	private GameObject enemy;
	private GameObject destroyable;

	void Update () {
		explodeTimer -= Time.deltaTime;
		if (explodeTimer <= 0){
			ExplodeEffects();
			DoPlayerDmg();
			DoEnemyDmg();
			DestroyDestroyable();
			Destroy(gameObject, destroyTime);
		} 
	}

	void ExplodeEffects () {
		Instantiate(explodeEffect, transform.position, Quaternion.identity);
		//GetComponent<AudioSource>().PlayOneShot(explodeSound);
	}

	void DoPlayerDmg () {
		if (GameObject.FindWithTag("Player") != null) {
			player = GameObject.FindWithTag("Player");	
			if (Vector3.Distance(transform.position, player.transform.position) <= dmgDistance) {
				player.GetComponent<PlayerHpScript>().GetDmg(dmg);
				KnockBack(player.GetComponent<Collider>());
			}
		} 
	}

	void DoEnemyDmg () {
		if (GameObject.FindWithTag("Enemy") != null) {
			enemy = GameObject.FindWithTag("Enemy");		
			if (Vector3.Distance(transform.position, enemy.transform.position) <= dmgDistance) {
				enemy.GetComponent<AiHpScript>().GetDmg(dmg);
				KnockBack(enemy.GetComponent<Collider>());
			}
		} 
	}

	void DestroyDestroyable () {
		if (GameObject.FindWithTag("Destroyable") != null) {
			destroyable = GameObject.FindWithTag("Destroyable");
			if (Vector3.Distance(transform.position, destroyable.transform.position) <= dmgDistance) {
				Destroy(destroyable);
			}
		}
	}
}
