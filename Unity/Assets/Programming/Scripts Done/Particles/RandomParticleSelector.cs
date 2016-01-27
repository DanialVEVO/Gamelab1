/* [no code]
 * Random Particle Selector Script
 * Scripted by Danial
 */


using UnityEngine;
using System.Collections;

public class RandomParticleSelector : MonoBehaviour {

	public ParticleSystem[] comicParticle = new ParticleSystem[3];
	public int selectedInt;
	private Vector3 spawnPos;
	public float spawnHeight = 1;
	
	public void ParticleRandomizer (){
		selectedInt = Random.Range(0,3);
		spawnPos = transform.position;
		spawnPos.y += spawnHeight;
		Instantiate(comicParticle[selectedInt], spawnPos, Quaternion.identity);
	}

}
