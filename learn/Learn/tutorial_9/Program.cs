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

        //behaviac.Config.IsLogging = true;
        //behaviac.Config.IsLoggingFlush = true;
        //behaviac.Config.IsSocketBlocking = true;

        behaviac.Workspace.Instance.FilePath = "../../workspace/exported";
        behaviac.Workspace.Instance.FileFormat = behaviac.Workspace.EFileFormat.EFF_xml;

    }

    static bool InitPlayer()
    {
        string btname = "StructBT";
        Loger.Log("InitPlayer");

        firstAgent = new FirstAgent();
        bool ret = firstAgent.btload(btname);
        Debug.Assert(ret);

        firstAgent.btsetcurrent(btname);


        return ret;
    }


    static void UpdateLoop()
    {
        Loger.Log("UpdateLoop");

        int frames = 0;
        behaviac.EBTStatus status = behaviac.EBTStatus.BT_RUNNING;
        while (status == behaviac.EBTStatus.BT_RUNNING)
        {
            Loger.LogFormat("frame: {0}", ++frames);

            //behaviac.Workspace.Instance.DebugUpdate();
            status = firstAgent.btexec();
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
            UpdateLoop();

            CleanPlayer();
        }

        CleanupBehaviac();

        Console.Read();
    }
}
