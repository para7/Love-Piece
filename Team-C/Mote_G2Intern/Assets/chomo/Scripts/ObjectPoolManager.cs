using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPoolManager : SingletonMonoBehaviour<ObjectPoolManager>
{
    [SerializeField]
    private PoolAbleObject m_poolAblePrefab;

    private GameObjectPool m_gameObjectPool; //追加

    [SerializeField]private Canvas m_canvas;


    void Start()
    {
        m_gameObjectPool = new GameObjectPool(this.transform, m_poolAblePrefab, m_canvas);

        this.OnDestroyAsObservable().Subscribe(_ => m_gameObjectPool.Dispose());
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnGetScorePlayer(new Vector3(0, 0, 0), 100);
        }

    }

    public void OnGetScorePlayer(Vector3 objectPosition, int score)
    {
        var gameObj = m_gameObjectPool.Rent();

        gameObj.ShowScore(objectPosition, score)
            .Subscribe(__ =>
            {
                m_gameObjectPool.Return(gameObj);
            });
    }
}
