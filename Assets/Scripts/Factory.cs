using System.Collections.Generic;
using System;
//using UnityEngine;

public class Factory //: MonoBehaviour
{
    private Dictionary<string, Func<int, MobModel>> mobFactory;

    //private MobDescription _description;
    //public MobDescription Description => _description;

    public void Init(MobDescriptions descriptions)
    {
        mobFactory = new Dictionary<string, Func<int, MobModel>>()
        {
            {"savage", (level) => new MobModel(descriptions.ListSavage[level])},
            //{"mummy", (level) => new MobModel(descriptions.ListMummy[level])},
            {"ogre", (level) => new MobModel(descriptions.ListOgre[level])}
        };

    }

    public MobModel CreateMobModel(string nameMob, int level)
    {
        return mobFactory[nameMob](level);
        //Instantiate(_description.Pref, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
