/* 7S_SH_001
 * DMG Script for Range Weapons/Attacks
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class AmmoDmgScript : KnockBackScript {
	
	public int dmg;
	public float ammoSpeed;
	public float projectileLifeTime;

	void Update () {
		GetComponent<Rigidbody>().velocity = transform.forward * ammoSpeed * Time.deltaTime;
		Destroy(gameObject, projectileLifeTime);
	}

	public void GiveDmg(GameObject enemy) {
		enemy.GetComponent<AiHpScript>().GetDmg(dmg);
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Enemy") {
			GiveDmg(coll.gameObject);
			KnockBack(coll);
		}
		Destroy(gameObject);
	}
}
