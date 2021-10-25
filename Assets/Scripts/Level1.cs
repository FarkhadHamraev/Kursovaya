using UnityEngine;
public class Level1 : MonoBehaviour
{
    [SerializeField] private MobDescriptions _mobDescriptions;

    private Factory _factory;

    private void Start()
    {
        _factory = new Factory();
        _factory.Init(_mobDescriptions);
        _factory.CreateMobModel("savage", 0);
        _factory.CreateMobModel("savage", 1);
    }
}
