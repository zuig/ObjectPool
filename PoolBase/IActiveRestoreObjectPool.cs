namespace Qtz.Q6.PoolUtil
{
    /**
     * Copyright (c) 2015,广州擎天柱网络科技有限公司

     * All rights reserved.
     *
     * 文件名称：IActiveRestoreObjectPool.cs
     * 简    述：一个能主动回收的对象池接口
     * 创建标识：Zon 2015/12/15

     * 修改描述：XXX
     * 修改标识：Zon 2015/12/15	
     */

    public interface IActiveRestoreObjectPool<T> : IObjectPool<IAutoRestoreObject<T>>
    {
        /// <summary>
        /// 此方法必须能识别哪些对象可以回收，而且回收到池中
        /// </summary>
        void CheckRestore();
    }
}
