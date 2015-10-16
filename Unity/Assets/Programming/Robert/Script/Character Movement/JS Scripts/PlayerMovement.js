#pragma strict

var moveSpeed : float = 5f;
var jumpStrength : float = 5f;
var jumpAllow : int = 5;
var jumpReset : int = 3;
var jumpCost : int = 1;

var raycastLength : float = 1f;
var testbool : boolean;

function Start () {

}

function Update () {
	Movement();
	Look();
}

function Movement () {

//Jump & Floor Collision
	if (Physics.Raycast(transform.position, -transform.up, raycastLength)){
		GetComponent.<Rigidbody>().useGravity = false;
		GetComponent.<Rigidbody>().velocity.y = 0;
		jumpAllow = jumpReset;
	} else {
		GetComponent.<Rigidbody>().useGravity = true;
	}

	if (Input.GetButtonDown("Jump") && jumpAllow >= 1){
		GetComponent.<Rigidbody>().velocity = Vector3(0,jumpStrength,0);
		jumpAllow -= jumpCost;
	}
//Vertical Movement & Collision
	if (Input.GetAxis("Vertical") > 0){
		if (Physics.Raycast(transform.position, transform.forward, raycastLength)){
			print("Raycast forward");
		} else {
//			print("Nothing found");
			transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
		}	
	}
	
	if (Input.GetAxis("Vertical") < 0){
		if (Physics.Raycast(transform.position, -transform.forward, raycastLength)){
			print("Raycast back");
		} else {
//			print("Nothing found");
			transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
		}	
	}
//Horizontal Movement & Collision
	if (Input.GetAxis("Horizontal") > 0){
		if (Physics.Raycast(transform.position, transform.right, raycastLength)){
			print("Raycast right");
		} else {
//			print("Nothing found");
			transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
		}	
	}
	
	if (Input.GetAxis("Horizontal") < 0){
		if (Physics.Raycast(transform.position, -transform.right, raycastLength)){
			print("Raycast left");
		} else {
//			print("Nothing found");
			transform.Translate(Vector3.left* Time.deltaTime * moveSpeed);
		}	
	}
}

function Look(){
//Mouse look
	transform.Rotate(Vector3(0, Input.GetAxis("Mouse X"), 0));
}