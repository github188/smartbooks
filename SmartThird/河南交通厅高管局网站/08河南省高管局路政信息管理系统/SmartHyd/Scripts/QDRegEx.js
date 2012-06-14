// JavaScript Document
var QDRegEx = new Object();
//清除字符串左右两端空格
QDRegEx.Trim = function (str) {
    var reg = /^\s+|\s+$/g;
    return str.replace(reg, "");
}
//用户名由5-20个以字母开头、可带数字、下划线的字符串组成
QDRegEx.CheckRegisterUserName=function(str){
    var reg = /^[a-zA-Z]\w{4,19}$/;
    return (reg.test(str));
}
//身份证验证
QDRegEx.CheckIDCard = function (str) {
    //身份证正则表达式(15位) 
    isIDCard1 = /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/;
    //身份证正则表达式(18位) 
    isIDCard2 = /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{4}$/;
    //验证身份证，返回结果  
    return (isIDCard1.test(str) || isIDCard2.test(str));
}
//Email地址有效性验证函数
QDRegEx.CheckEmail = function (str) {
    isEmail1 = /^\w+([\.\-]\w+)*\@\w+([\.\-]\w+)*\.\w+$/;
    isEmail2 = /^.*@[^_]*$/;
    return (isEmail1.test(str) && isEmail2.test(str));
}
//年龄有效性验证
QDRegEx.CheckAge = function (str) {
    var isAge = /^[1-9]\d*$/;
    if (!isAge.test(str))
        return false;
    if (parseInt(str) > 100)
        return false;
    return true;
}
//正整数有效性验证
QDRegEx.CheckPositiveInteger = function (str) {
    var reg = /^[1-9]\d*$/;
    return (reg.test(str));
}
//非负整数有效性验证(0和正整数)
QDRegEx.CheckNichtnegativInterger = function (str) {
    var reg = /^\d+$/;
    return (reg.test(str));
}
//整数有效性验证
QDRegEx.CheckInterger = function (str) {
    var reg = /^-?\d+$/;
    return (reg.test(str));
}
//非负数有效性验证(小数部分最多两位)
QDRegEx.CheckNonnegativeNumber = function (str) {
    var reg1 = /^0$/;
    var reg2 = /^[1-9]\d*$/;
    var reg3 = /^0\.\d{1,2}$/;
    var reg4 = /^[1-9]{1,}\d*\.\d{1,2}$/;
    return (reg1.test(str) || reg2.test(str) || reg3.test(str) || reg4.test(str));
}
//邮编有效性验证
QDRegEx.CheckPostCode = function (str) {
    var reg = /\d{6}/;
    return (reg.test(str));
}
//手机号码有效性验证(联通、移动、电信)
QDRegEx.CheckMobileNumber = function (str) {
    var reg = /^(130|131|132|155|156|185|186|134|135|136|137|138|139|147|150|151|152|157|158|159|182|187|188|133|153|189|180)\d{8}$/
    return (reg.test(str));
}
//国内(大陆)电话号码有效性验证(格式xxxx-xxxxxxxx)
QDRegEx.CheckTelephoneNumber = function (str) {
    var reg = /^0\d{2,3}-\d{7,8}$/;
    return (reg.test(str));
}
//日期有效性验证 限制日期格式 2007-1-1 或2007-01-01为有效格式 此方法限定只能输入1900年至2100年之间的日期(不包含2100年)
QDRegEx.CheckDate = function (str) {
    var reg = /^(19|20)\d{2}-(1[0-2]|0?[1-9])-([1-2][0-9]|3[0-1]|0?[1-9])$/;
    return (reg.test(str));
}