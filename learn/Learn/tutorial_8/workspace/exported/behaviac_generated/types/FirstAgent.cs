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
	public FirstStruct firstStruct = new FirstStruct();

	public HeroStruct heroStruct = new HeroStruct();

	public void Say(string txt)
	{
///<<< BEGIN WRITING YOUR CODE Say

        Loger.LogFormat("FirstAgent Say: {0},  firstStruct={1},  heroStruct={2}", txt, firstStruct, heroStruct);

///<<< END WRITING YOUR CODE
	}

	public void SayHello()
	{
///<<< BEGIN WRITING YOUR CODE SayHello
        Loger.LogFormat("FirstAgent SayHello firstStruct={0}, heroStruct={1}", firstStruct, heroStruct);
///<<< END WRITING YOUR CODE
	}

///<<< BEGIN WRITING YOUR CODE CLASS_PART

///<<< END WRITING YOUR CODE

}

///<<< BEGIN WRITING YOUR CODE FILE_UNINIT

///<<< END WRITING YOUR CODE

