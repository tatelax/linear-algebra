using System;
using UnityEngine;

public class SomeType : MonoBehaviour, IComparable
{
  public int value;
  
  public int CompareTo(object obj)
  {
    var other = obj as SomeType;
    return other != null ? value.CompareTo(other.value) : 1;
  }
  
}