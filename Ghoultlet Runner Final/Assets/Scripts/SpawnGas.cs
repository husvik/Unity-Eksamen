using UnityEngine;
public class SpawnGas : MonoBehaviour {
    //Spawns gas clouds
    public GameObject GasPrefab;
    public float SpawnCycle = 12.3f;
    private float _timeElapsed;

    void Update() {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed > SpawnCycle) {
            GameObject objectSpawned;
                objectSpawned = Instantiate(GasPrefab);
            
            Vector3 pos = objectSpawned.transform.position;
            objectSpawned.transform.position = new Vector3(Random.Range(0, 0), pos.y, pos.z);
            _timeElapsed -= SpawnCycle;
        }
    }
}