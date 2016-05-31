using UnityEngine;
using System.Collections;

[RequireComponent ( typeof (BoxCollider2D) ) ]
public class _RandomSpawn : MonoBehaviour {
	
	public Rigidbody2D[] _food ;
	private Rigidbody2D currentFood ;
			
	private BoxCollider2D _boxCollider2d ;
	private Bounds modifiedBound ;
	
	private Vector3 spawnPos ;
	private float spawnX ;
	private float spawnY ;
	
	void Start()
	{
		_boxCollider2d = GetComponent<BoxCollider2D>();
		InvokeRepeating("SpawnPosition" , 5f , 3.0f) ;
		
	}
	
	
	
	void SpawnPos()
	{
		Random.seed += 1 ;
		modifiedBound = _boxCollider2d.bounds ;
		spawnX = Random.Range(modifiedBound.min.x , modifiedBound.max.x) ;
		spawnY = Random.Range(modifiedBound.min.y , modifiedBound.max.y) ;
		spawnPos = new Vector3(spawnX , spawnY , 0) ;
		if (_food.Length > 0)
		{
			currentFood = Instantiate(_food[Random.Range(0 ,_food.Length - 1)] , spawnPos ,transform.rotation ) as Rigidbody2D ;
		}
		
	}
    
    
    public float maxX ;
    public float minX ;
    public float maxY ;
    public float minY ;
    
    public Vector3 pos ;
    public Rigidbody2D currentFoodis ;
    void SpawnPosition() {
        pos = new Vector3 (Random.Range(minX , maxX) , Random.Range(minY , maxY) ) ;
        
        
        currentFoodis = Instantiate(_food[Random.Range(0 ,_food.Length - 1)] , pos ,transform.rotation ) as Rigidbody2D ;
		
    }
    

	}
