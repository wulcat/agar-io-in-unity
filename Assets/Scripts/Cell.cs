using UnityEngine;
using System.Collections;


public class Cell : MonoBehaviour {
	
	public Camera ourCamera ;
	
	private Vector3 mouselocation ;

	[Range(0.0001f , 0.01f)]
	public float speed ; 
	
	private Vector3 direction ;

	private PlayerController RefPlayerController;



	
	void Start () 
	{
		// if ourCamera is null then set the Main Camera to the variable ourCamera
		if (!ourCamera)
		{
			ourCamera = Camera.main ;
		}

		if (RefPlayerController == null) {
			RefPlayerController = GetComponent<PlayerController> ();
		}

	}

	void Update () 
	{
//		DrawRay ();
		mouselocation = Input.mousePosition ;
		mouselocation.z = 10 ;
		
		direction = ourCamera.ScreenToWorldPoint( mouselocation ) ;
		transform.position = Vector3.MoveTowards(transform.position , direction , speed * Time.deltaTime * RefPlayerController.MassProperty   ) ;
	}



	
}
