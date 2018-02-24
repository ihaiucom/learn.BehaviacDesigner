using System;
using System.Diagnostics;

namespace tutorial_2
{
	class MainClass
	{
		static FirstAgent firstAgent;

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

			Console.WriteLine("\nInput 1: LoopBT,   2: SequenceBT,   3: SelectBT,  Other Number: Exit \n");

			for (int key = Console.Read(); key > (int)'0' && key < (int)'4';)
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
				}

				if (init)
				{

					UpdateLoop();

					CleanPlayer();
				}


                Console.Read(); // '\r'
				Console.Read(); // '\n'

				Console.WriteLine("\nInput 1: LoopBT,   2: SequenceBT,   3: SelectBT,  Other Number: Exit \n");
				key = Console.Read();
			}


			CleanupBehaviac();

			Console.Read();
		}
	}
}
