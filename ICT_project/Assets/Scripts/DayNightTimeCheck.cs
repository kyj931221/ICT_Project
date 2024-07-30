using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DayNightTimeCheck : MonoBehaviour
{
    [Header("스카이 박스3개, Light 넣기")]
    [SerializeField] Material skybox1;
    [SerializeField] Material skybox2;
    [SerializeField] Material skybox3;
    [SerializeField] GameObject Fireworks;
    //[SerializeField] GameObject Lamp;

    [SerializeField] GameObject directionalLight;   //아침엔 True
    int hours;  //시간 
    // Start is called before the first frame update
    void Start()
    {
        hours = DateTime.Now.Hour;
        StartCoroutine("HourCheck");
    }

    IEnumerator HourCheck()
    {
        //현재 분 뺀 후 함수 실행시키려고 변수 2개 선언함 
        bool first = true;
        int minus_Time = 60 - DateTime.Now.Minute;
        while (true)
        {
            //현재 시각 받아옴
            hours = DateTime.Now.Hour+10;
            Check_Environment();
            if (first)
            {
                //만약 현재 시각 30분이면 1800초 후 이 함수를 다시 실행 
                yield return new WaitForSeconds(minus_Time * 60);
                first = false;
            }
            yield return new WaitForSeconds(3600f);
        }
    }


    // 아침,새벽 해지기 전, 밤 
    void Check_Environment()
    {
        //18~4시까지 가로등 ON / 불꽃놀이 ON
        if (hours >= 18 || hours <= 4)
        {
            Fireworks.SetActive(true);
            //Lamp.SetActive(true);
        }
        else
        {
            Fireworks.SetActive(false);
           //Lamp.SetActive(false);
        }

        //아침
        if (hours >= 6 && hours <= 18)
        {
            directionalLight.SetActive(true);
            RenderSettings.skybox = skybox1;
        }
        //새벽, 해지기 전 
        else if ((hours >= 18 && hours <= 21) || (hours >= 4 && hours <= 6))
        {
            directionalLight.SetActive(false);
            RenderSettings.skybox = skybox2;
        }
        //밤 
        else if (hours >= 21 || hours <= 4)
        {
            directionalLight.SetActive(false);
            RenderSettings.skybox = skybox3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
