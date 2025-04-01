using Unity.VisualScripting;
using UnityEngine;


//플레이어의 바운드 크기를 구해주는 클래스 ( 아직 사용은 못함 )
public class PlayerBoundHandler : MonoBehaviour
{

    public SkinnedMeshRenderer[] bottom2Top;
    Bounds heightBounds = new();

    public Bounds GetHeightBounds()
    {
        foreach (var mesh in bottom2Top)
        {
            heightBounds.Encapsulate(mesh.bounds);
        }
        return heightBounds;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(heightBounds.center, heightBounds.size);
    }
}