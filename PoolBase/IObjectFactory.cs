namespace Qtz.Q6.PoolUtil
{
    /**
     * Copyright (c) 2015,广州擎天柱网络科技有限公司

     * All rights reserved.
     *
     * 文件名称：IObjectFactory.cs
     * 简    述：对象工厂接口，用于创建、销毁、激活、反激活对象  
     * 创建标识：Zon 2015/12/15

     * 修改描述：XXX
     * 修改标识：Zon 2015/12/15	
     */
    public interface IObjectFactory<T>
    {
        /// <summary>
        /// 创建一个对象
        /// </summary>
        /// <returns></returns>
        T CreateObject(bool doActive);

        /// <summary>
        /// 销毁对象
        /// </summary>
        /// <param name="t"></param>
        void DestroyObject(T t);

        /// <summary>
        /// 激活对象
        /// </summary>
        /// <param name="t"></param>
        void ActivateObject(T t);

        /// <summary>
        /// 反激活对象
        /// </summary>
        /// <param name="t"></param>
        void UnActivateObject(T t);
    }
}
