using UnityEngine;
using System.Collections;

public class MouseLookAt : MonoBehaviour {

	public enum SpiritRotation
	{
		Up = -90 ,
		Right = 0 ,
		Down = 90 ,
		Left = 180 
	}
	
	public Camera currentCamera  ;
	public SpiritRotation initialRotation ; 
	
	public Vector2 _direction ;
	public Vector2 _mousePositon ;
	public Transform _transform ;
	
	public Vector3 mousePosition ;
	
	public float _angle ;
	
	void Start () 
	{
		_transform = transform ;
		currentCamera = Camera.main ;
			
		
	}
	
	void Update () 
	{
		mousePosition = Input.mousePosition ;
		mousePosition.z = 10 ;
		_mousePositon = currentCamera.ScreenToWorldPoint ( mousePosition ) ;
		_direction = ( _mousePositon - (Vector2)transform.position ).normalized ;
		
		_angle = Mathf.Atan2(_direction.y , _direction.x ) * Mathf.Rad2Deg + (int)initialRotation ;
		_transform.rotation  = Quaternion.AngleAxis(_angle , Vector3.forward) ;

		
	}
}
