using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStackable
{
    int Count { get; }
    void Add(int count);
    void Remove(int count);
}
