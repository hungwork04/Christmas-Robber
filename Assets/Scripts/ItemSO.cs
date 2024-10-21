using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new item" , menuName ="Item")]
public class ItemSO : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int value;
    public int MaxQuan;
}
