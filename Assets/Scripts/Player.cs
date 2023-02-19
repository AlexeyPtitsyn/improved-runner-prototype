/**
 * Player game world interaction.
 */

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(PlayerSettings))]
public abstract class Player : MonoBehaviour
{
    protected HisShip _hisShip;
    protected GameManager _gameManager;
    protected Rigidbody _rigidbody;
    protected PlayerSettings _settings;

    protected int _lives = 9;
    protected readonly float _maxSpeed = 10;
    protected bool _inAir = false;

    protected virtual void Start()
    {
        _settings = GetComponent<PlayerSettings>();

        _hisShip = _settings.HisShip.GetComponent<HisShip>();
        _rigidbody = GetComponent<Rigidbody>();
        _gameManager = _settings.MainObject.GetComponent<GameManager>();
        _gameManager.UpdateLives(_lives);

        StartCoroutine(Forward());
    }

    private void OnCollisionEnter(Collision collision)
    {
        // For some reason, even *disabled* child class allows Unity to use
        // this class methods. This check ensures that the class
        // is inherited, to fire such events.
        if (!_gameManager) return;

        if(collision.gameObject.CompareTag("Floor"))
        {
            if(_inAir)
            {
                _inAir = false;
                _hisShip.TurnNormal();
            }
        }
    }

    private void SlowDown()
    {
        _settings.ForwardSpeed -= .5f;
        if (_settings.ForwardSpeed < 1.5)
        {
            _lives = 0;
            _gameManager.UpdateLives(_lives);
            _gameManager.EndGame("Player was slow down and left there forever...");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_gameManager) return; // See above.

        if (other.gameObject.CompareTag("Slowdown"))
        {
            _gameManager.LossScore();
            SlowDown();
        }

        if(other.gameObject.CompareTag("Obstacle"))
        {
            _lives--;
            _gameManager.UpdateLives(_lives);
            if(_lives <= 0)
            {
                _lives = 0; // What if I hit two cubes at once?
                _gameManager.EndGame("Player become squished with a cube...");
            }

            SlowDown();
        }
        if (other.gameObject.name == "Abyss")
        {
            _lives = 0;
            _gameManager.UpdateLives(_lives);
            _gameManager.EndGame("Player was unlucky enough to fall down...");
        }

        if(other.gameObject.name == "EndTile")
        {
            _gameManager.UpdateScore();
            _gameManager.OnEndTile();
            if(_settings.ForwardSpeed < _maxSpeed)
            {
                _settings.ForwardSpeed += .3f;
            }
        }
    }

    IEnumerator Forward()
    {
        while(true)
        {
            /** Transform variant: */
            //transform.position += transform.forward * _settings.ForwardSpeed * Time.deltaTime;
            //yield return new WaitForEndOfFrame();

            /** Physics variant: */
            Vector3 vel = _rigidbody.velocity;
            vel.z = _settings.ForwardSpeed * 50 * Time.fixedDeltaTime;
            _rigidbody.velocity = vel;

            yield return new WaitForFixedUpdate();
        }
    }

    protected void Move(int direction)
    {
        /** Transform variant: */
        //float dir = direction * Time.deltaTime;
        //transform.position += _settings.MoveSpeed * dir * transform.right;

        /** Physics: **/
        Vector3 _newForce = Vector3.right * direction * _settings.MoveSpeed * 4;
        _rigidbody.AddForce(_newForce, ForceMode.Acceleration);

        // Limit speed by 3:
        Vector3 _currentVelocity = _rigidbody.velocity;
        if(Mathf.Abs(_currentVelocity.x) > 3f)
        {
            _currentVelocity.x = 3f * direction;
            _rigidbody.velocity = _currentVelocity;
        }
    }

    protected void Jump()
    {
        // Lift up...
        _hisShip.TurnOver();

        /** Physics version: **/
        _rigidbody.AddForce(Vector3.up * _settings.JumpForce, ForceMode.Acceleration);

        /** Animated version: **/
        //_rigidbody.useGravity = false;
        //float countdown = .5f;
        //while(countdown > 0)
        //{
        //    countdown -= Time.deltaTime;
        //    var pos = transform.position;
        //    pos.y += Time.deltaTime * 3;
        //    transform.position = pos;

        //    yield return new WaitForEndOfFrame();
        //}

        //// Hang there for some time...
        //countdown = 1f;
        //while(countdown > 0)
        //{
        //    countdown -= Time.deltaTime;
        //    yield return new WaitForEndOfFrame();
        //}

        //// Fall down...
        //_rigidbody.useGravity = true;
    }
}
