using UnityEngine;
using UniRx.Toolkit;
using System.Collections;
using System.Collections.Generic;

public class GameObjectPool : ObjectPool<PoolAbleObject>
{
    private readonly PoolAbleObject m_poolAbleObject;

    private readonly Transform m_transform;

    public GameObjectPool(Transform transform, PoolAbleObject prefab)
    {
        m_poolAbleObject = prefab;
        m_transform = transform;
    }

    //追加で生成されるときに実行
    protected override PoolAbleObject CreateInstance()
    {
        var obj = GameObject.Instantiate(m_poolAbleObject);

        //ヒエラルキーが散らからないように一箇所にまとめる
        obj.transform.SetParent(m_transform);

        return obj;
    }
}