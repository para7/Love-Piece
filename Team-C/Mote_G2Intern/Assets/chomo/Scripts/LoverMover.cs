using UnityEngine;

public class LoverMover
{
    private readonly Rigidbody2D rigidbody2D;
    // _loverMover = new LoverMover(GetComponent<Rigidbody>());
    //moveSpeed 等のパラメータ　　　　　　　　　　　Loverに追加

    public LoverMover(Rigidbody2D _rigidbody2D)
    {
        this.rigidbody2D = _rigidbody2D;
    }

    public void Move(Vector2 moveDirection)
    {
        rigidbody2D.velocity = Time.deltaTime * moveDirection;
    }
}
