using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MobDescriptions", menuName = "MobDescriptions", order = 51)]
public class MobDescriptions : ScriptableObject
{
    [SerializeField] private List<MobDescription> _listSavage;
    [SerializeField] private List<MobDescription> _listOgre;

    public List<MobDescription> ListSavage => _listSavage;
    public List<MobDescription> ListOgre => _listOgre;
}