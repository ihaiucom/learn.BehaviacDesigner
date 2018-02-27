using System;
using System.Collections.Generic;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      2/26/2018 7:12:34 PM
*  @Description:    
* ==============================================================================
*/

public struct HeroStruct
{
    public int uid;
    public int age;

    public override string ToString()
    {
        return string.Format("HeroStruct  uid={0}, age={1}", uid, age);
    }
}