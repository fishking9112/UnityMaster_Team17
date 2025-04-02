using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Player player;

    protected override void Awake()
    {
        base.Awake();

        // Find
        player = GameObject.Find("Player").GetComponent<Player>();
    }
}
