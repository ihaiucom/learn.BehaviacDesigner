using System;
using System.Diagnostics;

namespace tutorial_3
{
	class MainClass
	{
		static FirstAgent firstAgent;
		static SecondAgent secondAgent;
		static SecondAgent thirdAgent;


		static bool InitBehavic()
		{
			Loger.Log("InitBehavic");

			behaviac.Workspace.Instance.FilePath = "../../workspace/exported";
			behaviac.Workspace.Instance.FileFormat = behaviac.Workspace.EFileFormat.EFF_cs;

			return true;
		}

		static bool InitPlayer(string btname)
		{
			Loger.LogFormat("InitPlayer : {0}", btname);

			// 创建firstAgent，并加载行为树“InstanceBT”
			firstAgent = new FirstAgent();
			bool ret = firstAgent.btload(btname);
			Debug.Assert(ret);
			firstAgent.btsetcurrent(btname);

			// 创建secondAgent，并将该实例赋给firstAgent的成员pInstance
			secondAgent = new SecondAgent();
			firstAgent._set_pInstance(secondAgent);

			// 创建thirdAgent，并将"SecondAgentInstance"绑定给该实例
			thirdAgent = new SecondAgent();
			behaviac.Agent.BindInstance(thirdAgent, "SecondAgentInstance");


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
			secondAgent = null;
			thirdAgent = null;
		}

		static void CleanupBehaviac()
		{
			Loger.Log("CleanupBehaviac");
			behaviac.Workspace.Instance.Cleanup();
		}

		public static void Main(string[] args)
		{
			InitBehavic();

			Console.WriteLine("\nInput 1: LoopBT,   2: SequenceBT,   3: SelectBT,  4: InstanceBT,  Other Number: Exit \n");

			for (int key = Console.Read(); key > (int)'0' && key < (int)'5';)
			{
				bool init = false;

				switch (key)
				{
					case '1':
						init = InitPlayer("LoopBT");
						break;
					case '2':
						init = InitPlayer("SequenceBT");
						break;
					case '3':
						init = InitPlayer("SelectBT");
						break;
					case '4':
						init = InitPlayer("InstanceBT");
						break;
				}

				if (init)
				{

					UpdateLoop();

					CleanPlayer();
				}


                Console.Read(); // '\r'
				Console.Read(); // '\n'

				Console.WriteLine("\nInput 1: LoopBT,   2: SequenceBT,   3: SelectBT,  4: InstanceBT,  Other Number: Exit \n");
				key = Console.Read();
			}


			CleanupBehaviac();

			Console.Read();
		}
	}
}
