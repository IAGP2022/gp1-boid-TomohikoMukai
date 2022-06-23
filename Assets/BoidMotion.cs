using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidMotion : MonoBehaviour
{
    // TODO: このボイドクラスが持つべきデータ・属性・バリエーション（フィールド）とは？
    // それぞれで異なる可能性がある数値
    private Vector3 _position;  // 位置
    private Vector3 _direction; // 移動方向
    private float _speed;       // 移動速度

    public GameObject _leader; // リーダー
                              // or
                              // Vector3 velocity; // 速度ベクトル？
    GameObject[] _boids; // 全ボイドを格納した配列（Startで設定）

    public Vector3 Position
    {
        get { return _position; }
    }

    // - 色、大きさ
    // - 対人距離、近寄りがたさ etc...

    // TODO: このボイドクラスが持つべき機能（メソッド）は？
    //
    // クラスインスタンスに共通する機能・手続き・処理

    void Awake() //コンストラクタ代わり　＝　全ボイドが出現するときに行われる
    {
        Vector3 p = Vector3.zero;
        p.x = Random.Range(-5.0f, 5.0f);
        p.y = Random.Range(-5.0f, 5.0f);
        p.z = Random.Range(-5.0f, 5.0f);
        _position = p;
        //direction = Vector3.forward;
        _direction.x = Random.Range(-1.0f, 1.0f);
        _direction.y = Random.Range(-1.0f, 1.0f);
        _direction.z = Random.Range(-1.0f, 1.0f);     
        _speed = Random.Range(0.0f, 5.0f); // 5.0は適当な数値
    }

    void Start()
    {
        // 自分自身も含む全てのボイドを探す = Boid というタグが付いている全てのゲームオブジェクトを取得する
        _boids = GameObject.FindGameObjectsWithTag("Boid"); // 見つけたボイドを boids という配列に格納
    }

    void Update()
    {
        // TODO: 力の合成について個性を与える
        // TODO: プレハブを使って多数のボイドを自動生成
        // TODO: C#文法の説明（オブジェクト指向プログラミングの説明）

        // 新しい移動方向（色々な力によって修正されていく）
        Vector3 newDirection = _direction;//とりあえず、行きたい方向を代入しておく

        //  1. リーダーを探す（inspectorで設定済み）
        //  2. リーダーの位置と、自分の位置を調べる
        LeaderMotion leaderMotion = _leader.GetComponent<LeaderMotion>();
        // リーダーがいる方向に向かう力
        Vector3 leaderForce = leaderMotion.Position - this._position;
        // 自分が行きたい方向と、リーダーへ向かう力の足し算＝修正された移動方向
        newDirection = newDirection + leaderForce;

        // 他のボイドの位置を知り、一定距離内にいるものから離れるための力を計算して、移動方向newDirectionを修正
        for (int i = 0; i < _boids.Length; ++i)
        {
            if (_boids[i].name != this.gameObject.name)// 他のボイド？
            {
                BoidMotion boidMotion = _boids[i].GetComponent<BoidMotion>(); //BoidMotionコンポーネント
                //  一定距離の内外をチェック
                //   距離の計算　＝　// TODO: this.position, boidMotion.Position の間の距離を計算
                float distance = Vector3.Distance(this._position, boidMotion.Position);
                //   求まった距離が、ある値未満か、ある値以上かをチェック
                if (distance < 2.0f)
                {
                    Debug.Log("NEAR!");
                    newDirection = newDirection + ???; // 避ける力を計算して移動方向を修正
                }

                // boids[i].transform.position (あえて使わない)
                //Debug.Log(boids[i].name + ", " + this.gameObject.name);
            }
        }

        // いろいろ修正された移動方向を正規化
        _direction = newDirection.normalized; // 長さ1にする
        // 次の位置 = 現在位置と、速度 * 移動方向 * Time.deltaTimeの和
        _position = _position + (Time.deltaTime * _direction * _speed);
        transform.position = _position; // ゲームオブジェクトに反映
    }
}
