#pragma strict

//var fireRate : float = 0.5;
private var nextFire : float = 0.0;
var duration : float= 1.0;
function Update() 
{
    // argument for cosine
   // var phi : float = Time.time / duration * 2 * Mathf.PI;
    var phi : float = Time.time / duration * 2 * Mathf.PI;
    // get cosine and transform from -1..1 to 0..1 range
    var amplitude : float = Mathf.Cos( phi ) * 0.1 + 0.9;
    // set light color
    GetComponent.<Light>().intensity = amplitude;
	
	 if (Time.time > nextFire)
	{
		duration = Random.Range(0.5,3);
		nextFire = Time.time + duration;
	}
	
	
}