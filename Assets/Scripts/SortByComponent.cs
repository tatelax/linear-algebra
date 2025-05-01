using System.Collections.Generic;
using UnityEngine;

public class SortByComponent : MonoBehaviour
{
  public List<Car> cars;
  
  private void Start()
  {
    cars.Sort(SortByHorsePower);
  }
  
  private int SortByHorsePower(Car a, Car b)
  {
    return b.isFast.CompareTo(a.isFast);
  }
}
