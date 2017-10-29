using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour {
	private static string _fireaxis;
	private Rigidbody2D _rb;
    private const float FireCooldown = 1f;
    private float _lastfire;
    public static int p2Score;
    public static BulletManager2 Bullets;
    private Text p2ScoreText;

	// Use this for initialization
    void Start () {
		_rb = GetComponent<Rigidbody2D>();
        p2Score = 0;
		_fireaxis = Platform.GetFireAxis();
        _fireaxis += "2";
        Debug.Log(_fireaxis);
        Bullets = new BulletManager2(GameObject.Find("Bullets").transform);
        GameObject canvasObject = GameObject.FindGameObjectWithTag("Canvas");
        Transform textTr = canvasObject.transform.Find("Player2ScoreText");
        p2ScoreText = textTr.GetComponent<Text>();
    }
	
    // ReSharper disable once UnusedMember.Global
    internal void Update () {
        HandleInput();
        p2ScoreText.text = "p2 score: " + p2Score.ToString();
    }

    /// <summary>
    /// Check the controller for player inputs and respond accordingly.
    /// </summary>
    private void HandleInput () {
        // TODO fill me in
        Turn(Input.GetAxis("Horizontal2"));
        Thrust(Input.GetAxis("Vertical2"));
        if (Input.GetAxis(_fireaxis) == 1)
        {
            Fire();
        }
    }

    private void Turn (float direction) {
        if (Mathf.Abs(direction) < 0.02f) { return; }
        _rb.AddTorque(direction * -0.05f);
    }

    private void Thrust (float intensity) {
        if (Mathf.Abs(intensity) < 0.02f) { return; }
        _rb.AddRelativeForce(Vector2.up * intensity);
    }

    internal void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<Bullet>() != null)
        {
            if (other.gameObject.name == "BulletPrefab(Clone)")
            {
                Debug.Log("P1 HIT P2");
                Player.p1Score += 2;
            }
            if (other.gameObject.name == "BulletPrefab2(Clone")
            {
                Debug.Log("P2 HIT P2");
                p2Score -= 1;
            }
        }
    }

    private void Fire () {
        float time = Time.time;
        if (time < _lastfire + FireCooldown) { return; }
        _lastfire = time;
        Bullets.ForceSpawn(
            transform.position + transform.up * 1.1f,
            transform.rotation,
            transform.up * 4f,
            time + Bullet.Lifetime);
    }

}
