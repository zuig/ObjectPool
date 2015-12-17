using UnityEngine;

namespace Qtz.Q6.PoolUtil.U3D
{
    /**
     * Copyright (c) 2015,广州擎天柱网络科技有限公司

     * All rights reserved.
     *
     * 文件名称：TimeBaseChecker.cs
     * 简    述：基于时间的回收检查器
     * 创建标识：Zon 2015/12/15

     * 修改描述：XXX
     * 修改标识：Zon 2015/12/15	
     */
    public class TimeBaseChecker : MonoBehaviour, IAutoRestoreChecker
    {
        private float time;

        public void Init(float time)
        {
            this.time = time;
        }

        public void Update()
        {
            time -= Time.deltaTime;
        }

        public bool Restore
        {
            get
            {
                if (time <= 0)
                {
                    this.transform.position = Vector3.zero;
                    return true;
                }else
                {
                    return false;
                }
                
            }
        }
    }
}
