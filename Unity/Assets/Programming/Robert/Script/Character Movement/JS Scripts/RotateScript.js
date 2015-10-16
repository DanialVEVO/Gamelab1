#pragma strict

var gain : float;

function Start () {

}

function Update () {

	Rotate();
	
}

function Rotate () {

	gameObject.transform.rotation.z +=gain * Time.deltaTime;
	
}
