using UnityEngine;
using System.Collections;

public class PlayerHandler : MonoBehaviour {

    public Camera playerCamera ;
    
    public Component[] _cell ;
    
    void Awake()
    {
        if (!playerCamera)
        {
            playerCamera = gameObject.GetComponentInChildren<Camera>() ;
        }
    }
   
    void Update()
    {
        if (!playerCamera)
        {
            playerCamera = gameObject.GetComponentInChildren<Camera>() ;
            return ;
        }
        
        _cell = gameObject.GetComponentsInChildren<_Cell>() ;
        
        if(_cell.Length == 0)
        {
            Debug.Log("No Pixels") ;
            Spectate() ;
        }
        else
        {
            SwitchToPlayer() ;
        }
        
        
    }
    
     //If player starts playing the game !
    void SwitchToPlayer()
    {
        Camera.main.GetComponent<AudioListener>().enabled = false ;
        playerCamera.enabled = true ;
    }
    
    //Offcourse for watching over view :P
    void Spectate()
    {
        playerCamera.enabled = false ;
    }
}
