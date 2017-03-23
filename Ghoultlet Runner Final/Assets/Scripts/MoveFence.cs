using UnityEngine;
public class MoveFence : MonoBehaviour {

    private GameControlScript _gameControlScript;

    void Start()
    {

        _gameControlScript = FindObjectOfType<GameControlScript>();
    }
    void Update()
    {

        float offset = _gameControlScript.ScrollSpeed * Time.deltaTime;
        transform.Translate(0, 0, -offset);

        if(transform.position.z<=-20) {
            transform.Translate(0f, 0f, 81.2f);
        }

    }
}