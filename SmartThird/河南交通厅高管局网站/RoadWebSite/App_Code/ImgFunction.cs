using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

/// <summary>
/// 上传图片生成缩略图及水印
/// </summary>
public class ImgFunction
{

    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式</param>    
    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(System.Drawing.Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }
    /// <summary>
    /// 在图片上增加文字水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_sy">生成的带文字水印的图片路径</param>
    public static void AddWater(string Path, string Path_sy)
    {
        string addText = "51aspx.com";
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(image, 0, 0, image.Width, image.Height);
        System.Drawing.Font f = new System.Drawing.Font("Verdana", 60);
        System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);

        g.DrawString(addText, f, b, 35, 35);
        g.Dispose();

        image.Save(Path_sy);
        image.Dispose();
    }
    /// <summary>
    /// 在图片上生成图片水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_syp">生成的带图片水印的图片路径</param>
    /// <param name="Path_sypf">水印图片路径</param>
    public static void AddWaterPic(string Path, string Path_syp, string Path_sypf)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
        g.Dispose();
        image.Save(Path_syp);
        image.Dispose();
    }
    ///<summary>    
    /// 删除图片    
    /// </summary>   
    /// <param name="path">当前文件的路径</param>    
    /// <returns>是否删除成功</returns>    
    public static bool FilePicDelete(string path)
    {
        bool ret = false;
        System.IO.FileInfo file = new System.IO.FileInfo(path);
        if (file.Exists)
        {
            file.Delete();
            ret = true;
        }
        return ret;
    }
    /// <summary>
    /// 返回缩略图的路径
    /// </summary>
    /// <param name="fileUpload">FileUpload控件</param>
    /// <param name="pathroot">根路径</param>
    /// <param name="width">宽</param>
    /// <param name="height">高</param>
    /// <param name="model">生成模式</param>
    /// <returns>生成缩略图的路径</returns>
    public static string GetUpLoadImgPath(FileUpload fileUpload,string pathroot, int width, int height, string model)
    {
        string webfilePath_True = "";
        //上传并预览
        if (fileUpload.HasFile)
        {
            string fileContentType = fileUpload.PostedFile.ContentType;
            if ((fileContentType == "image/bmp" || fileContentType == "image/gif" || fileContentType == "image/pjpeg" || fileContentType == "image/png") && fileUpload.PostedFile.ContentLength <= 3000000)//文件大于3M不能过滤
            {
                Random ran = new Random();
                string strran = ran.Next(1, 999).ToString();//随机数转字符型
                string name = fileUpload.PostedFile.FileName;//客户端文件路径
                FileInfo file = new FileInfo(name);
                string path = ConfigurationManager.AppSettings["imagePath"].ToString();
                #region 名称
                string fileName = DateTime.Now.ToString("yyyyMMddHHmm") + strran + file.Extension;//文件名称，使用FileInfo,Extension得到后缀
                string fileName_True = "sTrue_" + fileName;//实际存储的图片
                #endregion

                #region 物理路径
                string filePath = pathroot + fileName;
                string filePath_True = pathroot + fileName_True;
                #endregion

                #region 存储路径
                string webFilePath = path + fileName;
                webfilePath_True = path + fileName_True;
                #endregion

                if (!File.Exists(filePath))
                {
                    try
                    {
                        fileUpload.SaveAs(filePath);
                        MakeThumbnail(filePath, filePath_True, width, height, model);//生成缩略图
                        //修改url，显示图片
                        if (ImgFunction.FilePicDelete(filePath))//删除源文件
                        {
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }                
            }            
        }
        return webfilePath_True;
    }
}
//public class ModelForImg
//{
//    public enum ImgMadeModel
//    {
//        ControlWidthAndHeightZoom = "HW",//指定高宽缩放（可能变形）
//        ControlWidthZoom = "W",//指定宽，高按比例     
//        ControlHeightZoom = "H",//指定高，宽按比例
//        CutModel = "Cut"//指定高宽裁减（不变形）
//    }
//}


