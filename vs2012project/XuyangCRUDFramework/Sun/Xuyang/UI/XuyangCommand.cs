using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XuyangCRUDFramework.Sun.Xuyang.CRUD;
using XuyangCRUDFramework.Sun.Xuyang.Entity;

namespace XuyangCRUDFramework.Sun.Xuyang.UI
{
    abstract public class XuyangCommand
    {
        # region 私有属性

        private XuyangForm xYForm;

        private IXuyangCRUD xYCRUD;

        private int status = XuyangStatus.Normal;

        # endregion

        # region 构造函数

        public XuyangCommand(XuyangForm form, IXuyangCRUD crud)
        {
            xYForm = form;
            xYCRUD = crud;
        }

        # endregion

        # region CRUD操作（对外接口）

        /// <summary>
        /// 保存新建的实体对象
        /// </summary>
        /// <param name="entityC">实体对象</param>
        /// <param name="bag">背包信息</param>
        /// <returns>实体对象</returns>
        public XuyangEntity Create(XuyangEntity entityC, XuyangSchoolbag bag)
        {
            try
            {
                if (this.status != XuyangStatus.Creating)
                {
                    bool ignore = this.NotifyUserNotCreating(entityC, bag);
                    if (!ignore) return null;
                }

                if (!this.XYRequiredFullfilled()) return null;

                XuyangEntity entityCreated = xYCRUD.XYCRUDCreate(entityC, bag);

                this.status = XuyangStatus.Normal;
                this.SetFormLock(true);
                return entityCreated;
            }
            catch (Exception ex)
            {
                throw new Exception("XuyangCommand异常", ex);
            }
        }

        /// <summary>
        /// 获取实体对象列表
        /// </summary>
        /// <param name="entityR">查询条件</param>
        /// <param name="bag">背包信息</param>
        /// <returns>实体对象列表</returns>
        public List<XuyangEntity> Retrieve(XuyangEntity entityR, XuyangSchoolbag bag)
        {
            try
            {
                if (this.status != XuyangStatus.Normal)
                {
                    bool ignore = this.NotifyUserNotNormal(entityR, bag);
                    if (!ignore) return null;
                }

                List<XuyangEntity> entities = xYCRUD.XYCRUDRetrieve(entityR, bag);

                this.status = XuyangStatus.Normal;
                this.SetFormLock(true);
                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception("XuyangCommand异常", ex);
            }
        }

        /// <summary>
        /// 保存修改后的实体对象
        /// </summary>
        /// <param name="entityU">实体对象</param>
        /// <param name="bag">背包信息</param>
        /// <returns>实体对象</returns>
        public XuyangEntity Update(XuyangEntity entityU, XuyangSchoolbag bag)
        {
            try
            {
                if (this.status != XuyangStatus.Editing)
                {
                    bool ignore = this.NotifyUserNotEditing(entityU, bag);
                    if (!ignore) return null;
                }

                if (!this.XYRequiredFullfilled()) return null;

                XuyangEntity entity = xYCRUD.XYCRUDUpdate(entityU, bag);

                this.status = XuyangStatus.Normal;
                this.SetFormLock(true);
                this.SetFormCurrentRow(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("XuyangCommand异常", ex);
            }
        }

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="entityD">实体对象</param>
        /// <param name="bag">背包信息</param>
        /// <returns>实体对象</returns>
        public XuyangEntity Delete(XuyangEntity entityD, XuyangSchoolbag bag)
        {
            try
            {
                if (this.status != XuyangStatus.Normal)
                {
                    bool ignore = this.NotifyUserNotNormal(entityD, bag);
                    if (!ignore) return null;
                }

                xYCRUD.XYCRUDDelete(entityD, bag);

                this.status = XuyangStatus.Normal;
                this.SetFormLock(true);
                return entityD;
            }
            catch (Exception ex)
            {
                throw new Exception("XuyangCommand异常", ex);
            }
        }

        /// <summary>
        /// 开始新建实体
        /// </summary>
        public void StartCreate()
        {
            try
            {
                this.status = XuyangStatus.Creating;
                this.SetFormLock(false);
            }
            catch (Exception ex)
            {
                throw new Exception("XuyangCommand异常", ex);
            }
        }

        /// <summary>
        /// 开始编辑实体
        /// </summary>
        public void StartEdit()
        {
            try
            {
                this.status = XuyangStatus.Editing;
                this.SetFormLock(false);
            }
            catch (Exception ex)
            {
                throw new Exception("XuyangCommand异常", ex);
            }
        }

        /// <summary>
        /// 查看是否正在新建实体
        /// </summary>
        /// <returns>是或者否</returns>
        public bool isCreating()
        {
            try
            {
                if (this.status == XuyangStatus.Creating) return true;
                else return false;
            }
            catch (Exception ex)
            {
                throw new Exception("XuyangCommand异常", ex);
            }
        }

        # endregion

        # region CRUD提示信息

        /// <summary>
        /// 通知用户此窗体未处于[创建中/保存前]状态
        /// </summary>
        /// <param name="entityC">待保存的实体对象</param>
        /// <param name="bag">背包信息</param>
        /// <returns>忽略</returns>
        abstract protected bool NotifyUserNotCreating(XuyangEntity entityC, XuyangSchoolbag bag);

        /// <summary>
        /// 通知用户此窗台未处于[普通/待查询/待删除]状态
        /// </summary>
        /// <param name="entityR">查询条件</param>
        /// <param name="bag">背包信息</param>
        /// <returns>忽略</returns>
        abstract protected bool NotifyUserNotNormal(XuyangEntity entityR, XuyangSchoolbag bag);

        /// <summary>
        /// 通知用户此窗体未处于[编辑中/待更新]状态
        /// </summary>
        /// <param name="entityU">待更新的实体对象</param>
        /// <param name="bag">背包信息</param>
        /// <returns>忽略</returns>
        abstract protected bool NotifyUserNotEditing(XuyangEntity entityU, XuyangSchoolbag bag);

        # endregion

        # region 窗体操作

        private void SetFormLock(bool isLock)
        {
            try
            {
                xYForm.XYSetXuyangLocked(isLock);
            }
            catch (Exception ex)
            {
                throw new Exception("XuyangCommand异常", ex);
            }
        }

        private void SetFormCurrentRow(XuyangEntity entity)
        {
            try
            {
                xYForm.XYSetCurrentRow(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("XuyangCommand异常", ex);
            }
        }

        private bool XYRequiredFullfilled()
        {
            try
            {
                return this.xYForm.XYRequiredFullfilled();
            }
            catch (Exception ex)
            {
                throw new Exception("XuyangCommand异常", ex);
            }
        }

        # endregion
    }
}
