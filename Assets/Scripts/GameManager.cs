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

    private void OnDrawGizmos()
    {
        Common.ValidateObject<GameObject>(Player, "Player");
        Common.ValidateObject<GameObject>(Abyss, "Abyss");
        Common.ValidateObject<GameObject>(BlinkerLeft, "BlinkerLeft");
        Common.ValidateObject<GameObject>(BlinkerRight, "BlinkerRight");
        Common.ValidateObject<Text>(TextLives, "TextLives");
        Common.ValidateObject<Text>(TextScore, "TextScore");
        Common.ValidateObject<Text>(TextCountdown, "TextCountdown");
        Common.ValidateObject<Text>(TextPS, "TextPS");
    }

    private void Awake()
    {
        Common.ValidateObject<GameObject>(Player, "Player", true);
        Common.ValidateObject<GameObject>(Abyss, "Abyss", true);
        Common.ValidateObject<GameObject>(BlinkerLeft, "BlinkerLeft", true);
        Common.ValidateObject<GameObject>(BlinkerRight, "BlinkerRight", true);
        Common.ValidateObject<Text>(TextLives, "TextLives", true);
        Common.ValidateObject<Text>(TextScore, "TextScore", true);
        Common.ValidateObject<Text>(TextCountdown, "TextCountdown", true);
        Common.ValidateObject<Text>(TextPS, "TextPS", true);
#if LOW_QUALITY
        Logger.Log("Running in low quality mode...");
        // Decrease frame rate for my laptop while development:
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
#else
        Logger.Log("Running in high quality mode...");
#endif
    }

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
            EndGame("Player went through.");
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
        Logger.Log(message);
        TextPS.text = message;
#if UNITY_EDITOR
        EditorApplication.isPaused = true;
#elif !UNITY_EDITOR && UNITY_STANDALONE
        Application.Quit();
#endif
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
