using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField]
    private PoolAbleObject m_poolAblePrefab;

    private GameObjectPool m_gameObjectPool; //追加

    void Start()
    {
        m_gameObjectPool = new GameObjectPool(this.transform, m_poolAblePrefab);

        this.OnDestroyAsObservable().Subscribe(_ => m_gameObjectPool.Dispose());
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) { OnGetScorePlayer(this.transform.position); }
    }
    private void OnGetScorePlayer(Vector3 objectPosition)
    {
        var gameObj = m_gameObjectPool.Rent();

        gameObj.ShowScore(objectPosition)
            .Subscribe(__ =>
            {
                Debug.Log("Return");
                m_gameObjectPool.Return(gameObj);
            }).AddTo(this);
    }
}
