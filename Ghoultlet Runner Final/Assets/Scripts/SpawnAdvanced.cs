using UnityEngine;
public class SpawnAdvanced : MonoBehaviour {
    //Spaws the "advanced" items
    public GameObject SpecialObstacle;
    public GameObject SpecialPrefab;
    public float SpawnCycle = 5.25f;
    private float _timeElapsed;
    private float _totalTimeElapsed;
    private bool _spawnSpecial = true;
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        _totalTimeElapsed += Time.deltaTime;

        if (_totalTimeElapsed >= 10f) {
            if (_timeElapsed > SpawnCycle) {
                GameObject objectSpawned;
                if (_spawnSpecial) {
                    objectSpawned = Instantiate(SpecialPrefab);
                } else {
                    objectSpawned = Instantiate(SpecialObstacle);
                }
                Vector3 pos = objectSpawned.transform.position;
                objectSpawned.transform.position = new Vector3(Random.Range(-4, 4), pos.y, pos.z);
                _timeElapsed -= SpawnCycle;
                _spawnSpecial = !_spawnSpecial;
            }
        }
    }
}