using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {
    public float StrafeSpeed = 4f;
    private GameControlScript _gameControlScript;
    private Animator _animator;
    private bool _jumping;
    private bool _crouching;

    void Start() {
        _gameControlScript = FindObjectOfType<GameControlScript>();
        _animator = GetComponent<Animator>();
    }
    void Update() {
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * StrafeSpeed;
        transform.Translate(xMove, 0f, 0f);
        if (transform.position.x > 4) {
            transform.Translate(4f - transform.position.x, 0, 0);
        } else if (transform.position.x < -4) {
            transform.Translate(-4f - transform.position.x, 0, 0);
        }
        //Input
        if (Input.GetButtonDown("Jump")) {
            _animator.SetTrigger("Jump");
        }
        if (Input.GetButtonDown("Crouch")) {
            _animator.SetTrigger("Crouch");
        }
        //Animations
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Run")) {
            _jumping = false;
            _crouching = false;
        } else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")) {
            _jumping = true;
            _crouching = false;
        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Crouch")) {
            _jumping = false;
            _crouching = true;
        }
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "ClockObject(Clone)") {
            _gameControlScript.PowerupCollected();
        } else if (other.gameObject.name == "Gravestone(Clone)" && !_jumping) {
            _gameControlScript.SlowWorldDown();
        } else if (other.gameObject.name == "Zombie(Clone)") {
            _gameControlScript.DieCollide();   
        } else if (other.gameObject.name == "Shield(Clone)") {
            _gameControlScript.ShieldCollide();
        } else if (other.gameObject.name == "Gas(Clone)" && !_crouching) {
            _gameControlScript.DieCollide();
        }
        Destroy(other.gameObject);
    }
}