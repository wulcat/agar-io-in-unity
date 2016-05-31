using UnityEngine;
using System.Collections;

public class TimerTag : MonoBehaviour {
    
    [SerializeField][Range (0.001f , 0.2f)]
    private float time = 0.1f;
    
    public GameObject[] Pixels ;
    public GameObject[] previousPixels ;
    
    void Awake() 
    {
        Pixels = GameObject.FindGameObjectsWithTag("Pixel");
        for(int i = 0 ; i < Pixels.Length ; i++)
        {
            Physics2D.IgnoreCollision(Pixels[i].GetComponent<PolygonCollider2D>() , GetComponent<CircleCollider2D>() );
        }
    }   
    
    void Start()
    {
        Invoke("_TimerTag" , time) ;
        
    }
	
    void Update()
    {
        Pixels = GameObject.FindGameObjectsWithTag("Pixel");
        
        if (previousPixels != Pixels)
        {
            for(int i = 0 ; i < Pixels.Length ; i++)
            {
                Physics2D.IgnoreCollision(Pixels[i].GetComponent<PolygonCollider2D>() , GetComponent<CircleCollider2D>() );
            }
        }
        previousPixels = Pixels ;
    }
    
    void _TimerTag()
    {
        gameObject.tag = "EjectedMass" ;
    }
}
