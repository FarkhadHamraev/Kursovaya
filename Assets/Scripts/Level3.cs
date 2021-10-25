using UnityEngine;
public class Level3 : MonoBehaviour
{
    [SerializeField] private MobDescriptions _mobDescriptions;

    private Factory _factory;

    private void Start()
    {
        _factory = new Factory();
        _factory.Init(_mobDescriptions);
        _factory.CreateMobModel("ogre", 0);
    }
}