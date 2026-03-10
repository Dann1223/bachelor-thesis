using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum E_State
{
    Move, //移动
    Idle  //待机
}

//沿着路径移动功能
public class MovePath : MonoBehaviour
{
    //寻路组件
    public NavMeshAgent m_NavAgent;

    public Animator m_Animator;

    //路径根节点
    public Transform m_PathRoot;

    //路径列表 
    public List<Transform> m_PathList = new List<Transform>();

    //路径索引
    public int m_PathIndex; 

    //是否反向
    private bool m_IsFan ;

    public E_State m_CurState;

    private float m_CurTime;

    public float m_WaitTime;
     
    void Start()
    {
        m_CurState = E_State.Move;

        m_NavAgent = GetComponent<NavMeshAgent>();

        m_Animator = GetComponent<Animator>();

        //收集路径
        m_PathList.Clear();
        for (int i = 0; i < m_PathRoot.childCount;i++)
        {
            m_PathList.Add(m_PathRoot.GetChild(i));
        }
    }

   
    void Update()
    {
        switch(m_CurState)
        {
            case E_State.Idle:

                m_Animator.SetBool("Run", false);
                m_CurTime += Time.deltaTime;
                if(m_CurTime >= m_WaitTime)
                {
                    m_CurTime = 0;
                    m_CurState = E_State.Move;
                    m_NavAgent.isStopped = false;
                }

                break;
            case E_State.Move:
                m_Animator.SetBool("Run", true);
                if (IsRech(1, m_PathList[m_PathIndex]))
                {
                    //有一定几率待机
                    int idlechance = Random.Range(0, 100);
                    if(idlechance>=0 && idlechance<=30)
                    {
                        m_CurState = E_State.Idle;
                        m_NavAgent.isStopped = true;
                    }

                    if (!m_IsFan)
                    {
                        m_PathIndex++;
                        if (m_PathIndex >= m_PathList.Count)
                        {
                            m_PathIndex = m_PathList.Count - 1;
                            m_IsFan = true;
                        }
                    }
                    else
                    {
                        m_PathIndex--;
                        if (m_PathIndex < 0)
                        {
                            m_PathIndex = 0;
                            m_IsFan = false;
                        }
                    }
                }

                if (m_NavAgent != null && m_PathList.Count > 0)
                { 
                    //设置位置
                    m_NavAgent.SetDestination(m_PathList[m_PathIndex].position);
                }
                break;
        } 
    } 

    //是否
    public bool IsRech(float _dis , Transform _target)
    {
        if (_target == null)
            return false;
        float dis = Vector3.Distance(transform.position, _target.transform.position);
        Debug.Log("dis:" + dis);
        if (dis < _dis)
        {
            return true;
        }

        return false;
    }
}
