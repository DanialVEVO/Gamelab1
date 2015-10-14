using UnityEngine;
using System.Collections;
 
public class CharacterMovement : MonoBehaviour{
 
        private RaycastHit theHit;
        public float            forwardDis = 1;
        public float            moveSpeed;
		public float            rayDis = 1;
        private Rigidbody       rb;
        public int				maxJump = 1;
		public int				jumpReset = 1;
        public int				jumpCount = 1;
		public int				jumpCost = 1;
		public float			jumpBoost;
        public void Start (){
			rb = gameObject.GetComponent<Rigidbody>();
        }
 
        public void Update (){       
			Movement();
        }
 
        public void Movement(){
 
                if(Input.GetAxis("Vertical")> 0){
                        Debug.DrawRay(transform.position, transform.forward, Color.green);
                        if(Physics.Raycast(transform.position , transform.forward , forwardDis)){      
                                Debug.Log("Hit Front");
                        }
                                else{
                                        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
 
                                }
 
                }
                if(Input.GetAxis("Vertical")< 0){
                        if(Physics.Raycast(transform.position , -transform.forward , forwardDis)){
                                Debug.Log("Hit Back");
                        }
                                else{
                                        transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
 
                                }
 
                }
                if(Input.GetAxis("Horizontal")> 0){
                        if(Physics.Raycast(transform.position , transform.right , forwardDis)){
                                Debug.Log("Hit Right");
                        }
                                else{
                                        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
 
                                }
 
                }
                if(Input.GetAxis("Horizontal")< 0){
                        if(Physics.Raycast(transform.position , -transform.right , forwardDis)){
                                Debug.Log("Hit Left");
                        }
                                else{
                                        transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
 
                                }
                }

				if(jumpCount <= 0){
					if(Physics.Raycast(transform.position , -transform.up , rayDis)){
						jumpCount = jumpReset;
					}
				}

				if(Input.GetButtonDown("Jump") && jumpCount <= maxJump){
                    		rb.velocity = new Vector3(0,jumpBoost,0);
							jumpCount -= jumpCost;
				}                
		}
}