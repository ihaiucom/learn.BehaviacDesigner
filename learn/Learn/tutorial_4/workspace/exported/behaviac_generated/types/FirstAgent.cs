﻿// -------------------------------------------------------------------------------
// THIS FILE IS ORIGINALLY GENERATED BY THE DESIGNER.
// YOU ARE ONLY ALLOWED TO MODIFY CODE BETWEEN '///<<< BEGIN' AND '///<<< END'.
// PLEASE MODIFY AND REGENERETE IT IN THE DESIGNER FOR CLASS/MEMBERS/METHODS, ETC.
// -------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

///<<< BEGIN WRITING YOUR CODE FILE_INIT

///<<< END WRITING YOUR CODE

public class FirstAgent : behaviac.Agent
///<<< BEGIN WRITING YOUR CODE FirstAgent
///<<< END WRITING YOUR CODE
{
	public int p1 = 0;

	public void Say(string txt)
	{
///<<< BEGIN WRITING YOUR CODE Say

        Loger.LogFormat("FirstAgent Say: {0},  p1={1}", txt, p1);

///<<< END WRITING YOUR CODE
	}

	public void SayHello()
	{
///<<< BEGIN WRITING YOUR CODE SayHello
        Loger.LogFormat("FirstAgent SayHello p1={0}", p1);
///<<< END WRITING YOUR CODE
	}

///<<< BEGIN WRITING YOUR CODE CLASS_PART

///<<< END WRITING YOUR CODE

}

///<<< BEGIN WRITING YOUR CODE FILE_UNINIT

///<<< END WRITING YOUR CODE

