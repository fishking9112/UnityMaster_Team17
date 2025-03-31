using System.Collections;
using TMPro;
using UnityEngine;

public class ChatManager : MonoSingleton<ChatManager>
{
    public ChatData chatData;
    private string[] _chat;

    public TextMeshProUGUI _chatText;

    public float typingSpeed;
    public float clearSpeed;

    protected override void Awake()
    {
        base.Awake();

        // UIManager에서 _chatText 연결해주기
    }

    private void Start()
    {
        _chatText.text = string.Empty;
    }

    /// <summary>
    /// id를 받아와서 출력할 chat을 초기화
    /// </summary>
    /// <param name="id"> 출력할 chat의 id </param>
    public void UpdateChatText(int id)
    {
        ChatInfo chatInfo = chatData.chatInfoList.Find(info => info.id == id);
        _chat = chatInfo.content.Split("@");

        StartCoroutine(DisplayChat());
    }


    /// <summary>
    /// 대화 내용을 화면에 출력. speeker = 말하는 사람
    /// </summary>
    IEnumerator DisplayChat()
    {
        char speeker = _chat[0][_chat[0].Length - 1];

        for (int i = 0; i < _chat.Length - 1; i++)
        {
            if (_chat[i][_chat[i].Length - 1] != speeker)
            {
                speeker = _chat[i][_chat[i].Length - 1];

                yield return new WaitForSeconds(clearSpeed);
                _chatText.text = string.Empty;
            }
            yield return StartCoroutine(TypingText(_chat[i]));
        }

        yield return new WaitForSeconds(clearSpeed);
        _chatText.text = string.Empty;
    }

    /// <summary>
    /// 대화 내용을 한글자 씩 출력
    /// </summary>
    /// <param name="str"> 출력할 대화 문장 </param>
    IEnumerator TypingText(string str)
    {
        for (int i = 0; i < str.Length - 1; i++)
        {
            _chatText.text += str[i];
            yield return new WaitForSeconds(typingSpeed);
        }
        _chatText.text += "\n";
    }
}
