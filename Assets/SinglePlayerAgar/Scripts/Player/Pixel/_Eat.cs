using UnityEngine;
using System.Collections;


public class _Eat : MonoBehaviour {

	public int score ;
	
	[SerializeField]
	private int currentMass ;
	public int mass   
				{
					get
					{
						return currentMass ;	
					}
				}
	
	private float _massParamter ;
	public float massParameter   
	{
		get
		{
			return _massParamter ;
		}
	}
	
	
	private int minMass ;	
	private int maxMass ;
	
	private _Cell _cell ;
   
	void Start()
	{
		minMass = 100 ;
		maxMass = 100000 ; 
		_cell = GetComponent<_Cell>(); 
	}
	
	void Update()
	{
		
		currentMass = Mathf.Clamp(currentMass , minMass , maxMass ) ;
		_massParamter = Mathf.InverseLerp ( minMass - minMass , maxMass , currentMass ) ;
		
		if(score < currentMass)
			score = currentMass ;
			
		if(currentMass > 200 && Input.GetKeyDown(KeyCode.M) && _cell.canEject )
		{
			currentMass -= 10 ;
		}
			
	}
		
	void OnTriggerStay2D(Collider2D other) 
	{
		//When player collides with Object tagged UnitMass
		if (other.tag == "UnitMass")
		{
 			//Destroy(other.gameObject);
			currentMass++ ;
		}
		//When player colliders with Object tagged ejectedMass
		if (other.tag == "EjectedMass")
		{
        //    Debug.Log("Triggered") ;
		    Destroy(other.gameObject) ;
            currentMass += 10 ;
		
		}	
    }
	
	
		
	void DrawLine(Vector3 origin , Vector3 end , Color color) 
	{
		Debug.DrawLine(origin , end , color) ;
	}
	void DrawRay(Vector3 origin , Vector3 dir , Color color)
	{
		Debug.DrawRay(origin , dir , color) ;
	}

}
	
	