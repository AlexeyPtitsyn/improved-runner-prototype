/**
 * Main world object.
 */
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player; // Player
    public GameObject Abyss; // Invisible gameover trigger under level.

    public GameObject BlinkerLeft; // Left blinker. Prevents player to move outside of the map.
    public GameObject BlinkerRight;

    public Text TextLives;
    public Text TextScore;
    public Text TextCountdown;
    public Text TextPS;

    private float _lastTileZ = 72;
    private int _tileNumber = 0;

    private int _score = 0;

    [SerializeField]
    private Transform[] _tiles = new Transform[10];

    private float _timeLeft = 55f; // time left seconds.

    void Update()
    {
        // Abyss trigger should be always under player.
        Abyss.transform.position = new Vector3(0, -2, Player.transform.position.z);

        // ...and blinkers always on the sides:
        BlinkerLeft.transform.position = new Vector3(
            BlinkerLeft.transform.position.x,
            BlinkerLeft.transform.position.y,
            Player.transform.position.z);

        BlinkerRight.transform.position = new Vector3(
            BlinkerRight.transform.position.x,
            BlinkerRight.transform.position.y,
            Player.transform.position.z);

        _timeLeft -= Time.deltaTime;

        UpdateTime();

        if(_timeLeft <= 0)
        {
            _timeLeft = 0;
            EndGame("Player went through this test.");
        }
    }

    public void UpdateTime()
    {
        int seconds = (int)Mathf.Floor(_timeLeft);
        if(seconds < 10)
        {
            TextCountdown.text = $"Time left: 00:0{seconds}";
            return;
        }
        TextCountdown.text = $"Time left: 00:{seconds}";
    }

    public void UpdateLives(int num)
    {
        TextLives.text = $"Lives: {num}";
    }

    public void LossScore()
    {
        _score--;
        TextScore.text = $"Score: {_score}";
    }

    public void UpdateScore()
    {
        _score++;
        TextScore.text = $"Score: {_score}";
    }

    /**
     * Fired on game end (due to player's death).
     */
    public void EndGame(string message)
    {
        TextPS.text = message;
        EditorApplication.isPaused = true;
    }

    /**
     * Fired when player requested a new tile.
     */
    public void OnEndTile()
    {
        _lastTileZ += 9;
        var position = _tiles[_tileNumber].position;
        position.z = _lastTileZ;
        _tiles[_tileNumber].position = position;
        _tileNumber++;

        if(_tileNumber >= _tiles.Length)
        {
            _tileNumber = 0;
        }
    }
}
