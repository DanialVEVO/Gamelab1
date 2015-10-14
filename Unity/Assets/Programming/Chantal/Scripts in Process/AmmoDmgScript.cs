/* 7S_SH_001
 * DMG Script for Range Weapons/Attacks
 * Scripted by Chantal
 */

using UnityEngine;
using System.Collections;

public class AmmoDmgScript : MonoBehaviour {

	public AiHpScript aiHPScr;
	public int dmg;
	public float ammoSpeed;
	public float projectileLifeTime;


	void Update () {
		GetComponent<Rigidbody>().velocity = transform.forward * ammoSpeed * Time.deltaTime;
		Destroy(gameObject, projectileLifeTime);
	}

	public void GiveDmg() {
	//	aiHPScr.GetDmg(dmg);	
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Enemy") {
			GiveDmg();
		}
		Destroy(gameObject);
	}
}
