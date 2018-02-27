using BeardedManStudios.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      2/26/2018 2:40:07 PM
*  @Description:    
* ==============================================================================
*/

public class Program
{
    static FirstAgent firstAgent;

    static void InitBehaviac()
    {
        Loger.Log("InitBehaviac");
        behaviac.Workspace.Instance.FilePath = "../../workspace/exported";
        behaviac.Workspace.Instance.FileFormat = behaviac.Workspace.EFileFormat.EFF_xml;
    }

    static bool InitPlayer()
    {
        string btname = "maintree_task";
        Loger.Log("InitPlayer");

        firstAgent = new FirstAgent();
        bool ret = firstAgent.btload(btname);
        Debug.Assert(ret);

        firstAgent.btsetcurrent(btname);


        return ret;
    }

    static behaviac.EBTStatus status = behaviac.EBTStatus.BT_RUNNING;

    static void UpdateLoop()
    {
        Loger.Log("UpdateLoop");

        int frames = 0;

        while(status == behaviac.EBTStatus.BT_RUNNING)
        {
            Loger.LogFormat("frame: {0}", ++frames);
            status = firstAgent.btexec();
            Thread.Sleep(3000);
        }
    }

    static void CleanPlayer()
    {
        Loger.Log("CleanPlayer");

        firstAgent = null;
    }

    static void CleanupBehaviac()
    {
        Loger.Log("CleanPlayer");

        behaviac.Workspace.Instance.Cleanup();

    }

    public static void Main(string[] args)
    {
        InitBehaviac();

        bool bint = InitPlayer();

        if(bint)
        {
            Task.Queue(() =>
            {
                UpdateLoop();
            }, 10);

            while(status == behaviac.EBTStatus.BT_RUNNING)
            {
                int key = Console.Read();
                if(key == (int)'2')
                {
                    Loger.Log("FireEvent event_task");
                    firstAgent.FireEvent("event_task", 2);
                }
            }

            CleanPlayer();
        }

        CleanupBehaviac();

        Console.Read();
        Console.Read();
    }
}
