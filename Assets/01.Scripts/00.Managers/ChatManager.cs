using System;
using System.Collections;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoSingleton<ChatManager>
{
    public ChatData chatData;
    private string[] _chat;

    private TextMeshProUGUI _chatText;
    private Image _chatPannel;

    public float typingSpeed;
    public float clearSpeed;

    private bool _isChatting;

    private IEnumerator displayCoroutine; 

    protected override void Awake()
    {
        base.Awake();

        _chatText = GameObject.Find("Text_Chat").GetComponent<TextMeshProUGUI>();
        _isChatting = false;

        _chatPannel = GameObject.Find("ChatPannel").GetComponent<Image>();
    }

    private void Start()
    {
        _chatPannel.enabled = false;
        _chatText.text = string.Empty;
    }

    /// <summary>
    /// id를 받아와서 출력할 chat을 초기화하고 출력
    /// </summary>
    /// <param name="id"> 출력할 chat의 id </param>
    public void UpdateChatText(int id)
    {
        if (_isChatting)
        {
            StopAllCoroutines();
            _chatText.text = string.Empty;

            _chatPannel.enabled = false;
            _chatText.gameObject.SetActive(false);
        }

        ChatInfo chatInfo = chatData.chatInfoList.Find(info => info.id == id);
        _chat = chatInfo.content.Split("@");

        _chatPannel.enabled = true;
        _chatText.gameObject.SetActive(true);

        displayCoroutine = DisplayChat();
        StartCoroutine(displayCoroutine);
    }


    /// <summary>
    /// 대화 내용을 화면에 출력. speeker = 말하는 사람(문장의 맨뒤 chat타입 글자로 판단)
    /// </summary>
    IEnumerator DisplayChat()
    {
        _chatPannel.enabled = true;
        _chatText.gameObject.SetActive(true);

        _isChatting = true;


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

        _isChatting = false;

        _chatPannel.enabled = false;

        _chatText.gameObject.SetActive(false);
    }

    /// <summary>
    /// 대화 내용을 한 글자씩 출력
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
