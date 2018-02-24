using System;
using System.Diagnostics;

namespace tutorial_1
{
	class MainClass
	{
		static FirstAgent firstAgent;

		static bool InitBehavic()
		{
			Loger.Log("InitBehavic");

			behaviac.Workspace.Instance.FilePath = "../../workspace/exported";
			behaviac.Workspace.Instance.FileFormat = behaviac.Workspace.EFileFormat.EFF_xml;

			return true;
		}

		static bool InitPlayer()
		{
			Loger.Log("InitPlayer");

			firstAgent = new FirstAgent();
			bool ret = firstAgent.btload("FirstBT");
			Debug.Assert(ret);

			firstAgent.btsetcurrent("FirstBT");

			return ret;
		}

		static void UpdateLoop()
		{
			Loger.Log("UpdateLoop");

			int frames = 0;
			behaviac.EBTStatus status = behaviac.EBTStatus.BT_RUNNING;

			while (status == behaviac.EBTStatus.BT_RUNNING)
			{
				Loger.LogFormat("frame{0}", ++frames);
				status = firstAgent.btexec();
			}
		}

		static void CleanPlayer()
		{
			Loger.Log("CleanupPlayer");

			firstAgent = null;
		}

		static void CleanupBehaviac()
		{
			Loger.Log("CleanupBehaviac");
			behaviac.Workspace.Instance.Cleanup();
		}

		public static void Main(string[] args)
		{
			InitBehavic();

			InitPlayer();

			UpdateLoop();

			CleanPlayer();

			CleanupBehaviac();

			Console.Read();
		}
	}
}
