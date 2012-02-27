using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SmartSpider{
    partial class FrmMain{
        /// <summary>
        /// 初始化主窗体为默认UI
        /// </summary>
        private void SetDefaultUI() {
            #region 工具栏
            this.tolStartTask.Enabled = false;  //开始任务
            this.tolStopTask.Enabled = false;   //停止任务
            this.tolPauseTask.Enabled = false;  //暂停/继续任务

            this.tolAddTask.Enabled = true; //新建任务
            this.tolEditTask.Enabled = false;   //编辑任务
            this.tolDeleteTask.Enabled = false; //删除任务

            this.tolExportTo.Enabled = false;   //导出结果

            this.tolAllTaskSuccessShutdown.Enabled = false; //所有任务完成后关机
            this.TolDisableAllTimingAcquisitionTask.Enabled = false;    //禁用定时采集
            this.tolOption.Enabled = true;  //选项

            this.TolOnLineHelp.Enabled = true;  //在线帮助
            this.TolAboutUS.Enabled = true; //关于我们
            this.TolExit.Enabled = true;   //退出
            #endregion

            #region 菜单栏
            #region 文件菜单
            this.FileItemPublishResultErrorClear.Enabled = false;   //发布结果
            this.FileItemSaveAsTo.Enabled = false;  //将结果另存为
            this.FileItemViewResult.Enabled = false;    //查看结果
            this.FileItemClearResult.Enabled = false;   //清空结果
            this.FileItemPublishResultRepeat.Enabled = false;   //发布时重复行
            this.FileItemPublishResultError.Enabled = false;    //发布时出错行
            this.FileItemHistory.Enabled = false;   //历史记录
            this.FileItemTaskLog.Enabled = false;   //任务日志
            this.FileItemExit.Enabled = true;   //退出
            #endregion

            #region 查看菜单
            this.ViewItemShowToolBar.Enabled = true;    //工具栏
            this.ViewItemShowFloatFrom.Enabled = true;  //浮动窗
            #endregion

            #region 文件夹菜单
            this.FolderItemAdd.Enabled = true;  //新建
            this.FolderItemRename.Enabled = false;  //重命名
            this.FolderItemDelete.Enabled = false;  //删除
            this.FolderItemRefresh.Enabled = false; //刷新
            this.FolderItemExport.Enabled = false;  //导出
            #endregion

            #region 任务菜单
            this.TaskItemShowInfo.Enabled = false;  //显示运行信息
            this.TaskItemStart.Enabled = false; //开始
            this.TaskItemSpace.Enabled = false; //暂停
            this.TaskItemStop.Enabled = false;  //停止

            this.TaskItemAdd.Enabled = true;   //新建
            this.TaskItemEdit.Enabled = false;  //编辑
            this.TaskItemCopy.Enabled = false;  //复制
            this.TaskItemDelete.Enabled = false;    //删除
            this.TaskItemExport.Enabled = false;    //导出
            this.TaskItemImport.Enabled = true; //导入
            this.TaskItemSelectAll.Enabled = false; //全选
            #endregion

            #region 设置菜单
            #endregion

            #region 工具菜单
            #endregion

            #region 帮助菜单
            #endregion
            #endregion
        }
    }
}