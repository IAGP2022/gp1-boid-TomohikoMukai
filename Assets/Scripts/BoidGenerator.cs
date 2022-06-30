using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _boidPrefab; // unity gui からのみアクセス可能
    [SerializeField] GameObject _leader; // 複製時に指定するリーダーオブジェクト

    void Start()
    {
        //GameObject boidInstance = Instantiate(_boidPrefab);
        for (int i = 0; i < 100; ++i)
        {
            Vector3 p = Vector3.zero;
            p.x = Random.Range(-5.0f, 5.0f);
            p.y = Random.Range(-5.0f, 5.0f);
            p.z = Random.Range(-5.0f, 5.0f);
            var boid = Instantiate(_boidPrefab, p, Quaternion.identity); // 位置＋無回転指定で生成
            boid.GetComponent<BoidMotion>().Position = p;
            boid.GetComponent<BoidMotion>()._leader = _leader;
        }
    }

    void Update()
    {
        
    }
}
