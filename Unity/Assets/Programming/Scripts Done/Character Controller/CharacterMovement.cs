/* 7S_CHC_001
 * Player HP Script
 * Scripted by Robert & Danial
 */
using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour{
	
	private RaycastHit		theHit;
	public float            forwardDis = 0.6f;
	public float            rayDis = 1f;
	private Rigidbody       rb;
	public PlayerStats		playerStats;
	public bool				jumpAllow = true;
	public float 			downDis;
	
	
	public void Start (){
		rb = gameObject.GetComponent<Rigidbody>();
		playerStats = new PlayerStats();
	}
	
	public void Update (){  
		print (playerStats.jumpCount);
		Movement();
	}
	
	public void MovementReset(){
		playerStats = new PlayerStats();
		gameObject.GetComponent<Rigidbody>().drag = 0f;
	}
	
	public void Movement(){
		
		if(Input.GetAxis("Vertical")> 0){
			Debug.DrawRay(transform.position, transform.forward, Color.green);
			if(Physics.Raycast(transform.position , transform.forward , forwardDis)){      
				Debug.Log("Hit Front");
			}
			else{
				transform.Translate(Vector3.forward * playerStats.moveSpeed * Time.deltaTime);
			}
		}
		
		if(Input.GetAxis("Vertical")< 0){
			if(Physics.Raycast(transform.position , -transform.forward , forwardDis)){
				Debug.Log("Hit Back");
			}
			else{
				transform.Translate(-Vector3.forward * playerStats.moveSpeed * Time.deltaTime);
			}
		}
		
		if(Input.GetAxis("Horizontal")> 0){
			if(Physics.Raycast(transform.position , transform.right , forwardDis)){
				Debug.Log("Hit Right");
			}
			else{
				transform.Translate(Vector3.right * playerStats.moveSpeed * Time.deltaTime);
			}
		}
		
		if(Input.GetAxis("Horizontal")< 0){
			if(Physics.Raycast(transform.position , -transform.right , forwardDis)){
				Debug.Log("Hit Left");
			}
			else{
				transform.Translate(-Vector3.right * playerStats.moveSpeed * Time.deltaTime);
			}
		}

		if(playerStats.jumpCount > 0){
			if(Physics.Raycast(transform.position , -transform.up , downDis)){
				playerStats.jumpCount = 0;
			}
		}

		if(Input.GetButtonDown("Jump")){
			if( playerStats.jumpCount < playerStats.maxJump){
				rb.velocity = new Vector3(0,playerStats.jumpBoost,0);
				playerStats.jumpCount ++;
			}
		}
	}
}
