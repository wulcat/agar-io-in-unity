using UnityEngine;
using System.Collections;
using UnityEngine.Networking ;


public class _Cell : MonoBehaviour {
	
	private _Eat _eat ;
	private Camera _camera ;
	//Used for movements
	private Vector3 mouseAxis ;
	private Vector3 moveDir ;
	
	
	[Range(0.1f , 5f)][SerializeField]
	private float moveSpeed ;
	[Range(1f , 100f)][SerializeField]
	private float size = 50 ;
	
	public AnimationCurve rateParameter = new AnimationCurve ( new Keyframe (0f , 0f) , new Keyframe (0.5f ,0.5f) , new Keyframe (1f , 1f) ) ;
    //
	private bool _canEject ;
	
	public bool canEject
	{
		get 
		{
			return _canEject ;
		}
	}
	
	public Vector2 ejectionPoint
	{
		get
		{
			return _raycast.point ;
		}	
	}
    
	void Start () 
	{
		if (!_camera)
		{
			_camera = Camera.main ;
		}
        
		_eat = GetComponent<_Eat>() ;
		_polygonCollider = GetComponent<PolygonCollider2D>() ;
		
		CreateClone();
		EdgeToHollowPoly();
        	
	}
	
	void Update () 
	{
        if(!playerCamera)
            playerCamera = gameObject.GetComponentInParent<PlayerHandler>().playerCamera ;
      
      //  SwitchToPlayer();
         
		Move() ;
		RayFromPlayerToMouse() ;
		if(Input.GetKeyDown(KeyCode.M) && canEject && _eat.mass > 200 )
		{
			Debug.Log("Ejected Mass") ;
			EjectMass() ;
		}	
	}
 
 /*   
    //If player starts playing the game !
    void SwitchToPlayer()
    {
        _camera.GetComponent<AudioListener>().enabled = false ;
        playerCamera.enabled = true ;
    }
    
    //Offcourse for watching over view :P
    void Spectate()
    {
        playerCamera.enabled = false ;
    }
 */   
 //   [SerializeField]
    private Camera playerCamera ;
	
	//Totol Growth and Speed with movement
	void Move()
	{
		//Declaring the total size as per mass
		var _size = rateParameter.Evaluate(_eat.massParameter) * size ;
		var _speed = rateParameter.Evaluate(1 - _eat.massParameter) * moveSpeed ;
		
		mouseAxis = Input.mousePosition ;
		mouseAxis.z = 10 ;
		
		moveDir = playerCamera.ScreenToWorldPoint(mouseAxis) ;
		
		transform.position = Vector3.MoveTowards(transform.position , moveDir , _speed * Time.deltaTime) ;
		transform.localScale = new Vector3(_size , _size , 1) ;
	}
    
   
	//Function to create all types of Clones after starting game first time( This should be only called in Start funtion)
	void CreateClone()
	{
		if(createPlayerClone)
		{
			_playerClone = new GameObject("ClonePlayer");
			_playerClone.transform.parent = gameObject.transform ;
			_playerClone.transform.position = transform.position ;
			_playerClone.AddComponent<EdgeCollider2D>();
			_playerClone.GetComponent<EdgeCollider2D>().isTrigger = true ;
			_playerClone.layer = LayerMask.NameToLayer("Direction") ;
			
		}
	}
	
	// For Creating Clonees
	private GameObject _playerClone ;
	
	public bool createPlayerClone ;
	
	//Function to cast ray from Player origin to Cloned mouse cursor
	void RayFromPlayerToMouse()
	{
		var mouseRay = _camera.ScreenPointToRay(Input.mousePosition) ;
		var Ray = new Ray (transform.position , mouseRay.origin ) ;
		Debug.DrawRay(Ray.origin , Ray.direction * rayDistance , Color.red ) ;
		_playerDirection = Ray.direction ;
        normalizedDirection = _playerDirection.normalized ;
		_raycast = Physics2D.Raycast(Ray.origin , Ray.direction , rayDistance , rayMask) ;
		
		if(_raycast)
		{
		//	Debug.Log("EdgeCollider Detected") ;
		//	Debug.Log(_raycast.point) ;
			_canEject = true ;
			
		}
		else
		{
			_canEject = false ;
		}
	}
	
	//Variables used to Draw Ray from player
	private RaycastHit2D _raycast ;
	[SerializeField]
	private float rayDistance = 50;
	[SerializeField]
	private LayerMask rayMask ;
	
	private Vector2 _playerDirection ;
    private Vector2 normalizedDirection ;
	public Vector2 playerDirection
	{
		get 
		{
			return normalizedDirection ;
		}
	}
	
	//Adds A Edge Outline to the Clone Player
	void EdgeToHollowPoly()
	{
		polygonPointsPos = new Vector2[_polygonCollider.points.Length + 1 ] ;
		
		for (int i = 0 ; i < _polygonCollider.points.Length; i++)
 		{
			polygonPointsPos[i] = _polygonCollider.points[i] ;
		}
		polygonPointsPos[_polygonCollider.points.Length ] = _polygonCollider.points[0] ;
		_playerClone.GetComponent<EdgeCollider2D>().points = polygonPointsPos ;
	}
	
	//Used for Creating Edge Outline to the Clone Player
	private PolygonCollider2D _polygonCollider ;
	private Vector2[] polygonPointsPos ;

	//Ejects the few amout of mass
	void EjectMass()
	{
        
		GameObject ejectedMassClone =  (GameObject)Instantiate (ejectedMassPrefab , ejectionPoint  , transform.rotation )  ;
		ejectedMassClone.GetComponent<Rigidbody2D>().AddForce( normalizedDirection * ejectedMassSpeed  ) ;
	}
	//Requires Rigidbody2D , Collider 
	public GameObject ejectedMassPrefab ;
	[SerializeField][Range (900f , 1100f)]
	private float ejectedMassSpeed = 1000;
	
}