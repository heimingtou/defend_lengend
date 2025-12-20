using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHeroData", menuName = "Game/Hero Data")]
public class HeroData : ScriptableObject
{
    public Sprite heroIcon;
    public float MaxHp;
    public float Damage;
    public float Range;
    public int Level;
    public float cost;
}
