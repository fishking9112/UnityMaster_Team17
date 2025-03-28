using UnityEngine;

/// <summary>
/// Singleton 을 쉽게 만들기 위한 Utill
/// Singleton 으로 만들고 싶은 클래스에서 MonoBehaviour 대신 MonoSingleton 을 상속 받으면
/// 싱글톤이 완성 됩니다.
/// 
/// 주의 : MonoSingleton 에 있는 함수(메서드) 는 , override 해서 사용 해야 합니다 ( ex : Awake )
/// 
/// 추가 수정이 필요하실 경우 말씀해주세요.
/// </summary>

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _instance = null;

    //public static T Instance => _instance;
    public static T Instance //{ get { return _instance; } }
    {
        get
        {
            if (_instance == null)
            {
                string ObjName = typeof(T).Name;
                _instance = new GameObject(ObjName).AddComponent<T>();
                Debug.Log($"Singleton {ObjName} 싱글톤 생성 !.");
            }
            return _instance;
        }
    }

    [SerializeField] 
    protected bool isDontDestroyOnLoad = false;

    protected virtual void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Debug.LogWarning($"Singleton {this.name} 은 중복 생성시도 되었습니다.");
            Destroy(this.gameObject);

            return;
        }
        else
        {
            _instance = this.gameObject.GetComponent<T>();

            if (isDontDestroyOnLoad)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
    protected virtual void OnDestroy()
    {
        if (_instance != null) 
        {
            _instance = null; 
        }
    }
}
