using UnityEngine;

/// <summary>
/// 상호작용 가능한 오브젝트가 상속받을 인터페이스
/// 아이템, 상자 등 상호작용 가능한 오브젝트가 상속받아서 
/// </summary>
public abstract class InteractableObject : MonoBehaviour
{
    /// <summary>
    /// 상호작용 가능한 오브젝트의 이름을 반환하는 함수(UI에 띄울 때 사용)
    /// </summary>
    /// <returns> 아이템의 이름 </returns>
    public abstract string GetNameText();

    /// <summary>
    /// 상호작용 가능한 오브젝트의 설명을 반환하는 함수(UI에 띄울 때 사용)
    /// </summary>
    /// <returns></returns>
    public abstract string GetDescriptionText();

    /// <summary>
    /// 상호작용 가능한 오브젝트와 상호작용했을 때 호출
    /// </summary>
    public abstract void OnInteract();
}
