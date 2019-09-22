using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Master
{
    public class ProcedureFight : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }
    
        protected override void OnInit(ProcedureOwner procedureOwner)
        {
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
        }

   

        protected  override void OnDestroy(ProcedureOwner procedureOwner)
        {
            base.OnDestroy(procedureOwner);
        }
       


        protected override void OnLeave(ProcedureOwner procedureOwner,bool isShutdown)
        {
         
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

           
           
            
        }


    }
}
