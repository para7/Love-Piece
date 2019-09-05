using UnityEngine;
using UniRx.Toolkit;
using System.Collections;
using System.Collections.Generic;

public class GameObjectPool : ObjectPool<PoolAbleObject>
{
    private readonly PoolAbleObject m_poolAbleObject;

    private readonly Transform m_transform;

    private readonly Canvas m_canvas;
    public GameObjectPool(Transform transform, PoolAbleObject prefab, Canvas canvas)
    {
        m_poolAbleObject = prefab;
        m_transform = transform;
        m_canvas = canvas;
    }

    //追加で生成されるときに実行
    protected override PoolAbleObject CreateInstance()
    {
        var obj = GameObject.Instantiate(m_poolAbleObject);

        obj.Init(m_canvas);
        //ヒエラルキーが散らからないように一箇所にまとめる
        obj.transform.SetParent(m_transform);

        return obj;
    }
}