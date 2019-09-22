using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Master
{
   public  enum  Stype
    {
        TalkRoom= 1,
        Auth= 2,

        GameSystem= 3, // 系统服务, 个人和系统，不会存在多个玩家进行交互;
        GameFight= 4, // 五子棋的休闲模式游戏服务
    }
}
