# Document
* [English](./docs/en/README.md)
* [简体中文](./docs/cn/README.md)
  
开始之前，建议先花点时间，阅读一下本说明。

这是一个基于JSON及webapi 接口的强大PowerBuilder接口扩展库。支持版本 pb8 - pb2019.
一、JSON部分
好用的 json for PB ,与 datawindow/datasore 无缝对接，能动态创建 dw/ds实现数据导入，也可以在现有dw/ds上按列匹配导入。
实时导入导出 json，速度快，效率高。
uo_json功能函数主要有4个，即:
1、Parse：将字符串转为JSON对象
2、ToString：将JSON对象转为字符串
3、Set：设置JSON对象或数组值
4、Get：获取JSON对象或数组值
在有多层嵌套的情况下，可以使用级联字符串直接取值。例如
[
{
"__rowid__":1,
"id":1.0,
"sj":"2020-02-17",
"sub":
[
{"__rowid__":1,"id":1.0,"mch":"菜1","dj":9.0,"je":7.0},
{"__rowid__":2,"id":1.0,"mch":"菜2","dj":1.0,"je":3.0},
{"__rowid__":3,"id":1.0,"mch":"菜3","dj":7.0,"je":1.0},
{"__rowid__":4,"id":1.0,"mch":"菜4","dj":5.0,"je":9.0}
]
}
]
要取得第一行数组"菜3"下面的dj,可以这样写key字符串:
deciaml ld_dj
json.Get("/0/sub/2/dj",ref ld_dj)
"/0/sub/2/dj"这个串里，第一个0表示是大数组的第1行数据，sub表示第一行数据是JSON，取其sub的值，sub的值是一个JSON数组。然后跟着的2表示取子数组的第3行数据，key为dj,取值类型为 decimal。
***这里注意，与PB的数组下限从1开始到n结束不同，这里JSON数组下限是0从开始，n-1结束。

二、HttpClient部分
开发了PBJson，然后突然就感到HttpClient也成了必然需要。由此写了这么个HttpClient。因为以前用HttpClient不多，经验不够，不足之处，在所难免。见谅！

HttpClient内部使用了 WinHttp API：
1.使用简单，主要只有一个参数Request，完成请求。参数说明，请参看 uo_httpclient Local External Functions 里的声明
2.借助 pbjson，可完美与 json,datawindow 结合工作。
3.uo_httpclient 内置了一个变量 uo_response response，用于记录各种响应结果和数据。

4.先了解一下请求类别
//静态变量，require 函数的第一个参数 nHttpType 
constant int HttpGet      = 1
constant int HttpPost     = 2
constant int HttpPut      = 3

5.很有必要事先了解一下，httpclient 发送 request 后，会返回哪些内容。
string header          //保存 httpclient 的response header
string headerlist[]    //保存 httpclient 的response header 关键字
blob   data            //保存 httpclient 的结果，不仅限于文本，也可能是其他二进制数据。在只是文本的情况下，可以取 text 值
int    errcode         //返回值错误值 
string errtext         //返回值错误文本
int    httpcode        //200 正常 , 404 501
string verb            //POST ，PUT ，GET 。。。
long   timeout = 5000  //默认5秒超时
string charset         //语言编码 utf-8 gbk 等
string ContentType     //text/html application/json等
string Server          //服务器类型
string text            //文本，由data转换而来。对utf8,GBK,UNICODE各种类型做了自动转换为当前文字编码。在多数情况下，此文本是可用的。但不排除响应结果是非文本情况，例如图片、声音等二进制数据，那

就必须读取 data才能获取正确结果。
uo_json json           //当返回Content-Type: application/json时，会生成此 json 对象

三、加密解密、编码部分
提供 RSA、AES、DES、签名、base64、CRC、urlencode ......等实现功能。

有任何BUG或者建议，可以我联系。

            大自在(QQ:781770213 群：624409252) 
                        2020/03/06
![image](https://user-images.githubusercontent.com/89757391/131769153-7e3ca4f2-32d3-4698-8775-aa601984ad56.png)
![image](https://user-images.githubusercontent.com/89757391/131769204-a56fe102-3954-4079-af7c-a08735023bd4.png)
![image](https://user-images.githubusercontent.com/89757391/131769228-04f14668-5b42-4be4-8b07-96f67c89e472.png)
![image](https://user-images.githubusercontent.com/89757391/131769285-742bbfdd-c45a-4a80-b1e3-375285a345fa.png)
![image](https://user-images.githubusercontent.com/89757391/131769313-495bcacb-e504-4628-b149-b7a50f6906cc.png)
![image](https://user-images.githubusercontent.com/89757391/131769331-d8080d93-49e3-4158-82f8-6419097a01bf.png)
![image](https://user-images.githubusercontent.com/89757391/131769351-0eb68140-5851-415c-b784-0432b45b047e.png)
![image](https://user-images.githubusercontent.com/89757391/131769407-a01eac7a-94bf-4ee1-bce8-08619c9c1220.png)
![image](https://user-images.githubusercontent.com/89757391/131769444-c5608c52-5da3-405a-b6ec-c85f70ac5528.png)
![image](https://user-images.githubusercontent.com/89757391/131769495-01436487-ee8a-43d9-84ea-9b4a30d75af2.png)
![image](https://user-images.githubusercontent.com/89757391/131769531-e5ad576f-9167-44d5-ae86-ba9bcb8df45c.png)
redis client:
![image](https://user-images.githubusercontent.com/89757391/131769551-14245b82-014e-4e81-9f47-3a6c4d3e520e.png)
![image](https://user-images.githubusercontent.com/89757391/131769602-e59deca4-2f1e-4b63-9930-ea93cce2b1e1.png)
![image](https://user-images.githubusercontent.com/89757391/131769612-1fa2580e-9ddd-4da1-8816-df3ddc1a712c.png)

![image](https://user-images.githubusercontent.com/89757391/131769524-5580bf2e-dfd4-4aa2-9433-46f82c464f72.png)
