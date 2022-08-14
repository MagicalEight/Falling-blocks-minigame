using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 7;
    public event System.Action OnplayerDeath;

    private float screenHalfWidthInWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth; // 这里的 size 相当于屏幕长度的一半
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
        
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D triggerCollider) // 会被 2D 物理引擎直接调用，所以名字必须要这么写
    {
        if (triggerCollider.tag == "Falling Block")
        {
            if (OnplayerDeath != null)
            {
                OnplayerDeath();
            }
            //FindObjectOfType<GameOver>().OnGameOver();
            Destroy(gameObject);
        }
    }
}
