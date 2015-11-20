#pragma strict

function Start () {

}

function Update () {

	transform.Rotate(Vector3(-Input.GetAxis("Mouse Y"), 0, 0));

}