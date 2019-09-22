//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using System;
using UnityEngine;

namespace Master
{
    [Serializable]
    public  class RoleData : TargetableObjectData
    {
        [SerializeField]
        private string m_Name = null;
        [SerializeField]
        private int m_Attack = 0;
        [SerializeField]
        private int m_MaxHP = 0;
        public RoleData(int entityId, int typeId, CampType camp,int attack,int hp)
            : base(entityId, typeId,camp)
        {
            HP = m_MaxHP = hp;
            m_Attack = attack;
            
        }
        /// <summary>
        /// 角色名称。
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public override int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        public int Attack
        {
            get
            {
                return m_Attack;
            }
        }
       


      
    }
}
