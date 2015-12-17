namespace Qtz.Q6.PoolUtil
{
    /**
     * Copyright (c) 2015,广州擎天柱网络科技有限公司

     * All rights reserved.
     *
     * 文件名称：IObjectPool.cs
     * 简    述：一个对象池接口  
     * 创建标识：Zon 2015/12/15

     * 修改描述：XXX
     * 修改标识：Zon 2015/12/15	
     */
    /// <summary>
    /// 一个对象池接口  
    /// </summary>
    /// <typeparam name="T">该对象池中存放的对象类型</typeparam>
    public interface IObjectPool<T>
    {
        /// <summary>
        /// 从对象池中取对象
        /// </summary>
        /// <returns></returns>
        T Take();

        /// <summary>
        /// 把对象存回对象池
        /// </summary>
        /// <param name="t"></param>
        void Restore(T t);

        /// <summary>
        /// 对象池增加对象
        /// </summary>
        void AddObject();

        /// <summary>
        /// 对象池中空闲(可用)对象的数目
        /// </summary>
        /// <returns></returns>
        int IdleNum();

        /// <summary>
        /// 对象池中空闲(可用)对象的数目
        /// </summary>
        /// <returns></returns>
        int ActiveNum();

        /// <summary>
        /// 清除对象池中所有对象
        /// </summary>
        void Clear();
    }
}
