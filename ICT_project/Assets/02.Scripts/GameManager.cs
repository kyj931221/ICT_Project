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
    public int curSceneIdx { get; set; } // 다음에 로드할 씬
    public Transform curTransform { get; set;} // 다음 씬 로드 시 이동할 위치
    public int curStoryIdx { get; set; } // 재생 중인 스토리 인덱스
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
