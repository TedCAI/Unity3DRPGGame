#pragma strict

// generic gamera switcher - http://unitycoder.com/blog/

public var cams:GameObject[];
private var index:int=0;


function Update () 
{
	if (Input.GetMouseButtonDown(0))
	{
		index = Mathf.Repeat(index+1,cams.Length);
		Camera.main.transform.position = cams[index].transform.position;
		Camera.main.transform.rotation = cams[index].transform.rotation;
	}
}