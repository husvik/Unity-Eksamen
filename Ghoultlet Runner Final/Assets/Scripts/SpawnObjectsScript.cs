using UnityEngine;
public class SpawnObjectsScript : MonoBehaviour {
    //Spawns the standard items
    public GameObject ObstaclePrefab;
    public GameObject PowerupPrefab;
    public float SpawnCycle = 0.5f;
    private float _timeElapsed;
    private bool _spawnPowerup = true;
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed > SpawnCycle) {
            GameObject objectSpawned;
            if (_spawnPowerup) {
                objectSpawned = Instantiate(PowerupPrefab);
            } else {
                objectSpawned = Instantiate(ObstaclePrefab);
            }
            Vector3 pos = objectSpawned.transform.position;
            objectSpawned.transform.position = new Vector3(Random.Range(-4, 4), pos.y, pos.z);
            _timeElapsed -= SpawnCycle;
            _spawnPowerup = !_spawnPowerup;
        }
    }
}