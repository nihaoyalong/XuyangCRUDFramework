using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XuyangCRUDFramework.Sun.Xuyang.Entity;

namespace XuyangCRUDFramework.Sun.Xuyang.CRUD
{
    public interface IXuyangCRUD
    {
        /// <summary>
        /// 新增一个实体
        /// </summary>
        /// <param name="entityC">实体信息</param>
        /// <param name="bag">背包信息</param>
        /// <returns>实体信息</returns>
        XuyangEntity XYCRUDCreate(XuyangEntity entityC, XuyangSchoolbag bag);

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="entityR">查询条件</param>
        /// <param name="bag">背包信息</param>
        /// <returns>实体列表</returns>
        List<XuyangEntity> XYCRUDRetrieve(XuyangEntity entityR, XuyangSchoolbag bag);

        /// <summary>
        /// 更新实体信息
        /// </summary>
        /// <param name="entityU">实体信息</param>
        /// <param name="bag">背包信息</param>
        /// <returns>实体信息</returns>
        XuyangEntity XYCRUDUpdate(XuyangEntity entityU, XuyangSchoolbag bag);

        /// <summary>
        /// 删除实体信息
        /// </summary>
        /// <param name="entityD">实体信息</param>
        /// <param name="bag">背包信息</param>
        /// <returns>实体信息</returns>
        XuyangEntity XYCRUDDelete(XuyangEntity entityD, XuyangSchoolbag bag);

    }
}
