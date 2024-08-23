using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            
            return m_instance;
        }
    }
    public int curSceneIdx { get; set; } // ������ �ε��� ��
    public Transform curTransform { get; set;} // ���� �� �ε� �� �̵��� ��ġ
    public int curStoryIdx { get; set; } // ��� ���� ���丮 �ε���
    public bool is1stMiniGameClear { get; set; }
    public bool is2ndtMiniGameClear { get; set; }

    public int[] GameConnectIDX = { 2, 3 };

    GameObject player;


    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(instance != this) { Destroy(gameObject); };

        is1stMiniGameClear = false;
        is2ndtMiniGameClear = false;
        curStoryIdx = 0;
        player = GameObject.Find("OVRCameraRigInteraction");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToStory(int _curIdx, Transform _curTransform)
    {
        if (_curIdx == 3)
        {
            curSceneIdx = ++_curIdx;
            curStoryIdx = 0;
        }
        SceneManager.LoadScene(curSceneIdx);
        curSceneIdx = _curIdx;
        curTransform = _curTransform;
    }

    public void BackToGame()
    {
        SceneManager.LoadScene(curSceneIdx);
        player = GameObject.Find("OVRCameraRigInteraction");
        player.transform.position = curTransform.position;
        player.transform.rotation = curTransform.rotation;
    }
}
