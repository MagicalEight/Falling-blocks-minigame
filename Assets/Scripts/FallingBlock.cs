using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;

    float visibleHeightThreshold;
    
    

    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());

        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y; // 屏幕底边 - block 本地 y 轴高度
        
    }
void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime); // 默认是以本地坐标系，当自己旋转的时候坐标系也旋转了，如果还想让方块垂直下落，在后面规定 Space.World 即可

        if (transform.position.y < visibleHeightThreshold)
        {
            Destroy(gameObject);
        }
    }
}
