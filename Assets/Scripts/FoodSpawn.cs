using UnityEngine;
using System.Collections;


public class FoodSpawn : MonoBehaviour 
{
	//public GameObject _foodPrefab ;
	public GameObject[] _foodPrefabArray ; 

	public Vector2 Min ;
	public Vector2 Max ;

    
    private Vector3 myFoodPos ;

//	public Rigidbody2D foodClone ;

	void Start() 
	{
		InvokeRepeating ("MyFoodSpawn", 5f, 0.5f);
	}

	void MyFoodSpawn() 
	{
		var i = Random.Range ( 0 ,  _foodPrefabArray.Length);

		myFoodPos = new Vector3 ( Random.Range(Min.x , Max.x )  , Random.Range(Min.y , Max.y) , 0 )  ;
        
		var randomRandomClone = Instantiate (_foodPrefabArray [i], myFoodPos, transform.rotation) as Rigidbody2D;

     //   var foodClone = Instantiate ( _foodPrefab, myFoodPos  , transform.rotation ) as Rigidbody2D ;

	}
}
