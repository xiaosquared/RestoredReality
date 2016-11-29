#pragma strict

var animator : Animator;

var d : float;

var target : Transform;

function Start () {

	animator = GetComponent (Animator) ;

}

function Update () {

	d =  Vector3.Distance(target.position, transform.position);

}

function FixedUpdate () {

	animator.SetFloat("DistanceToDoor", d);

}
