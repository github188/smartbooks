

安装说明:
1.附件数据库SmartTeaching.mdf到Sqlserver 2005
2.代开源代码web.config文件，找到 <appSettings> 配置节点更改数据库连接字符串：

示例连接字符串：
Data Source=.;Initial Catalog=SmartTeaching;User Id=sa;Password=ccense;

1.安装net4.0框架
  下载地址:http://download.pchome.net/development/developtools/translater/detail-171222.html
2.安装net3.5 sp1补丁包(在线安装，时间根据网速情况可能比较长)
  下载地址:http://www.microsoft.com/downloads/zh-cn/details.aspx?familyid=ab99342f-5d1a-413d-8319-81da479ab0d7
3.安装iisexpress_1_11_x86_zh-CN.msi
  下载地址:http://download.microsoft.com/download/7/8/B/78B8E3C2-047F-4D22-ACAF-7B97A29DCD89/iisexpress_1_11_x86_zh-CN.msi
4.解压网站源代码到磁盘目录下:如d:\wwwroot\
5.附加数据库到SqlServer2005。
6.更改网站源码web.config数据库连接字符串。
7.启动网站,命令行示例:
  开始-->运行-->cmd--->
  C:\Program Files\IIS Express\iisexpress.exe /path:d:\wwwroot\ /port:8000 /clr:V2.0
8.右击右下角托盘区域网站小图标，选择浏览全部网站，单击网站Url地址即可启动浏览
9.后台管理地址：/admin/login.aspx	用户名:admin	密码:admin