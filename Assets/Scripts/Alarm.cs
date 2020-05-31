using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
  public event UnityAction ColorChange;
  public event UnityAction VolumeChange;
  
  
  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.TryGetComponent<Enemy>(out Enemy enemy))
    {
      ColorChange?.Invoke();
      VolumeChange?.Invoke();
    }
  }
}
