using UnityEngine;

public class Chat : MonoBehaviour
{
    public int chatId;

    private bool isCheck = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isCheck)
        {
            isCheck = true;
            ChatManager.Instance.UpdateChatText(chatId);
        }
    }
}
