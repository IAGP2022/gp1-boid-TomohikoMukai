using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PersonalData
{
    public string name; // 氏名
    public int birthyear; // 生年
    public int birthmonth; // 生まれた月
    public int birthday; // 生まれた日
    public int mynumber; // マイナンバー
    public int age; // 年齢
    // その他いろいろ
}

class MyVector2
{
    public float x;
    public float y;

    // construct(構築)er
    public MyVector2()
    {
        x = 1.0f;
        y = 1.0f;
    }
    
    public MyVector2(float ix, float iy)
    {
        x = ix;
        y = iy;
    }

    public void DebugLog()
    {
        Debug.Log(x + ", " + y);
    }
    public float Magnitude()
    {
        return Mathf.Sqrt(x * x + y * y);
    }
}

// 銀行口座クラス
class BankAcount
{
    // フィールド
    private int balance; // 預金残高

    // コンストラクタ
    public BankAcount(int yen) // 最初の預け入れ指定
    {
        balance = yen;
    }

    // 引き出し
    public void Withdraw(int yen)
    {
        if (balance > yen)
        {
            balance -= yen;
        }
    }

    // 預け入れ
    public void Deposit(int yen)
    {
        if (yen > 0)
        {
            balance += yen;
        }
    }

    // 残高照会メソッド GetBalance
    public int GetBalance()
    {
        return balance;
    }

    public int Balance //()ナシ
    {
        get //()なし
        {
            return balance;
        }
    }
}

public class CameraMotion : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        BankAcount myacount = new BankAcount(1000);
        myacount.Deposit(2000);
        myacount.Withdraw(500);
        myacount.Deposit(100);
        myacount.Deposit(1000);
        myacount.Withdraw(500);
        int zandaka = myacount.Balance;
        Debug.Log(zandaka);

        PersonalData tomo = new PersonalData();
        tomo.name = "Mukai Tomohiko";
        tomo.birthyear = 1978;
        tomo.birthmonth = 11;

        PersonalData mako = new PersonalData();
        mako.name = "Mukai Mako";
        mako.birthyear = 2012;
        mako.birthmonth = 2;

        MyVector2 a = new MyVector2(0.0f, 10.0f);
        a.x = 0.0f;
        a.y = 10.0f;
        //Debug.Log(a.x + ", " + a.y);
        a.DebugLog();
        float la = a.Magnitude(); // aの長さ 

        MyVector2 b = new MyVector2(20.0f, 0.0f);
        //b.x = 20.0f;
        //b.y = 0.0f;
        //Debug.Log(b.x + ", " + b.y);
        b.DebugLog();
        float lb = b.Magnitude();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

