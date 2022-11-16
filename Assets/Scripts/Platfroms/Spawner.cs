using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformPrefab;
    [SerializeField] private GameObject[] _modifierPrefab;
    [SerializeField] private PigControl _pigControl;
    [SerializeField] private CameraViewWidth _cameraViewWidth;

    private float _height = 1f;

    private float xMin = -2f;
    private float xMax = 2f;
    private void Start()
    {
        _pigControl.HeightChanged += OnHeightChangedGeneratePlatform;
        GeneratePlatforms(12, _platformPrefab[0]);
    }
    private void OnHeightChangedGeneratePlatform()
    {
        GeneratePlatforms(1, _platformPrefab[0]);

        if(_pigControl.MaxHeight % 50 == 1)
            GeneratePlatforms(10, _platformPrefab[2]);
    }
    private void GeneratePlatforms(int platformCount, GameObject prefab)
    {
        for (int i = 0; i < platformCount; i++)
        {
            SpawnPlatform(prefab, true);
        }

        if( RandomSelection.RandomGenerate(0.3f) == true)
        {
            SpawnPlatform(_platformPrefab[1], false);
        }
    }
    private void SpawnPlatform(GameObject prefab, bool modifier)
    {
        var spawn = Instantiate(prefab);
        spawn.transform.position = new Vector2(Random.Range(xMin, xMax), _height);

        if (modifier == true)
        {
            if(RandomSelection.RandomGenerate(0.5f) == true)
                ModifierPlatform(_modifierPrefab[0], spawn, 0.1f);
            else ModifierPlatform(_modifierPrefab[1], spawn, 0.01f);

        }

        _height += Random.Range(0.5f, 0.9f);
    }
    private void ModifierPlatform(GameObject modifierPrefab, GameObject platformPrefab, float chanceSuccesful)
    {
        if (RandomSelection.RandomGenerate(chanceSuccesful) == true)
        {
            var spawn = Instantiate(modifierPrefab);
            spawn.transform.position = new Vector2( platformPrefab.transform.position.x, platformPrefab.transform.position.y + 0.48f);
            spawn.transform.SetParent(platformPrefab.transform);
        }
    }
}
