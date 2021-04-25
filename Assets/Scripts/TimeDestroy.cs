using System;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
  [SerializeField] 
  private float _time;

  private void Awake()
  { 
    Destroy(gameObject, _time);
  }
}