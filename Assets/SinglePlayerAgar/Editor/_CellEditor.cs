using UnityEngine;
using System.Collections;
using UnityEditor ;

[CustomEditor (typeof ( _Cell ) )]
public class _CellEditor : Editor 
{
/*	private  _Cell  c;
	
	void OnSceneGUI()
	{
		c = this.target as _Cell ;
		Handles.color = Color.red ;
		Handles.DrawWireDisc(c.transform.position , Vector3.forward , c.radius ) ;
	}
*/
}
