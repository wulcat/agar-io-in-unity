using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PolygonCollider2D))]
public class Rendering : MonoBehaviour {

	public Vector3[] vertices ;
	
	public PolygonCollider2D _polyCollider ;
	public Mesh _mesh ;
	
//	public int[] inPolygonPoints ;
	
	void Start()
	{
		_polyCollider = GetComponent<PolygonCollider2D>() ;
		vertices = new Vector3[_polyCollider.points.Length] ;	
//		vertices = _polyCollider.points ;
		
//		Debug.Log(_polyCollider.points.Length) ;

		for (int i = 1 ; i < _polyCollider.points.Length ; i++)
		{
			vertices[i].x = _polyCollider.points[i].x ;
			vertices[i].y = _polyCollider.points[i].y ;
			
	// make an array of int and keep adding every polyCollider Point reference to points vector lol made it messy to understand ..!		
		}
		
		//Create new instance of mesh 
		_mesh = new Mesh() ;
		//Give a name to out mesh
		_mesh.name = "SpriteRenderMesh" ;
		_mesh.vertices = vertices ;
		_mesh.uv = _polyCollider.points ;
	//	_mesh.triangles =
	
		for(int i = 0 ; i < _polyCollider.points.Length ; i++)
		{
	//		_mesh.triangles[3 * i + 0] = _polyCollider.points[2] ;
		}
		
		CreateTriangle() ;
		
		_mesh.RecalculateNormals() ;
		GetComponent<MeshFilter>().mesh = _mesh ;
		
		Debug.Log("Total Surfaces : " +_polyCollider.shapeCount) ;
		
	}
	
	
	void CreateTriangle()
	{
		
		int m = 0 ;
		int count = vertices.Length ;
	
		while ((count > 5))
		{
			count =  (count/2) ;
			
			if ((count > 5))
			{
				m++ ;
			}
			
		}
		Debug.Log("Total Polys Inside :"+m) ;
		
		
		
		
		
/*		for(int i = 0 ; inPolygonPoints[i] < 3 ; i++)
		{
	//		inPolygonPoints[] = new int[10] ;
	//		inPolygonPoints[i] = new int[] { new (vertices.Length / 2) } ;
		}
*/	}
	
}
