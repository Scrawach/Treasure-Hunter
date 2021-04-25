using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WallFinder : MonoBehaviour
{
    [SerializeField] 
    private float _checkDistance;
    
    [SerializeField] 
    private LayerMask _wallLayerMask;

    public bool Check(Vector3 origin, Vector3 direction)
    {
        var ray = new Ray(origin, direction);
        var hit = Physics.Raycast(ray, _checkDistance, _wallLayerMask);
        return hit;
    }
}
