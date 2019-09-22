//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using UnityEngine;

namespace Master
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        public static websocket websocketMgr { private set; get; }

        private void Start()
        {
            InitBuiltinComponents();
            websocketMgr = this.gameObject.AddComponent<websocket>();
        }
    }
}
