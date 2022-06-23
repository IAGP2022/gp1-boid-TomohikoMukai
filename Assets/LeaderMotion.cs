using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderMotion : MonoBehaviour
{
    public float radius; // 円周運動の半径
    public float speed; // 移動速度
    
    public Vector3 Position
    {
        get { return transform.position; }
    }

    void Start()
    {
    }

    void Update()
    {
        // 円周運動
        Vector3 pos = Vector3.zero;
        pos.x = radius * Mathf.Sin(speed * Time.time);
        pos.z = radius * Mathf.Cos(speed * Time.time);
        transform.position = pos;
    }
}
