using UnityEngine;
using System.Collections;

public class LightsaberGlowScript : MonoBehaviour {

	public Material mat;
	public float minGlow = 0.1f;
	public float maxGlow = 0.5f;
	public float glowSpeed = 0.005f;

	private bool glowOn;
	private float glowStrength;

	void Start () {
		mat.shader = Shader.Find("MK/MKGlow/Cutout/Diffuse");
	}

	void Update () {
		GlowEffect();
	}

	void GlowEffect () {
		if (mat.GetFloat("_MKGlowPower") >= maxGlow){
			glowOn = false;
		} else if (mat.GetFloat("_MKGlowPower") <= minGlow){
			glowOn = true;
		}

		if (glowOn){
			glowStrength += glowSpeed;
		} else {
			glowStrength -= glowSpeed;
		}

		mat.SetFloat("_MKGlowPower", glowStrength);
	}
}
