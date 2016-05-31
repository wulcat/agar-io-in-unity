using UnityEngine;
using System.Collections;

public class Tri : MonoBehaviour {
	
	//public float speed ;
	//public GameObject gameObject ;
	
	public Transform pivot ;
	public Transform target ;
	public float radius ;
	
	public Vector3 vPos ;
	public float angle ;
	
	void Start() 
	{
		transform.parent = pivot ;
	}
	
	void Update () 
	{
		vPos = Camera.main.ScreenToWorldPoint(target.position) ;
		vPos = Input.mousePosition - vPos ;
		angle = Mathf.Atan2(vPos.y , vPos.x) * Mathf.Rad2Deg ;
		
		pivot.position = target.position  ;
		pivot.rotation = Quaternion.AngleAxis(angle , Vector3.forward) ;
		//transform.RotateAround(gameObject.transform.position , Vector3.back , speed * Time.deltaTime  ) ;
		transform.position = transform.position ;
	}
}
