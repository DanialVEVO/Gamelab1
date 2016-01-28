/* [no code]
 * Random Particle Selector Script
 * Scripted by Danial
 */


using UnityEngine;
using System.Collections;

public class RandomParticleSelector : MonoBehaviour {

	public ParticleSystem[] comicParticle = new ParticleSystem[3];
	public int selectedInt;
	
	public void ParticleRandomizer (){
		selectedInt = Random.Range(0,3);
		print (selectedInt);
		Instantiate(comicParticle[selectedInt]);
	}

}
