
namespace Qtz.Q6.PoolUtil
{
    /**
     * Copyright (c) 2015,广州擎天柱网络科技有限公司

     * All rights reserved.
     *
     * 文件名称：IAutoRestoreObject.cs
     * 简    述：能被自动回收的对象接口
     * 创建标识：Zon 2015/12/15

     * 修改描述：XXX
     * 修改标识：Zon 2015/12/15	
     */
    public interface IAutoRestoreObject<T>
    {

        /// <summary>
        /// 是否能被回收的接口
        /// </summary>
        IAutoRestoreChecker Restore { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Get();
    }
}
