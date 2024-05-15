Before starting, it is recommended to take a moment to read this instruction

    This library is specially developed for PowerBuilder applications. After testing, it is applicable to PB versions 8 – 2019.
1、JSON
    The user-friendly json for PB is seamlessly connected with datawindow/datasore. It can dynamically create dw/ds to import data, or match and import existing dw/ds by column.
Real time import and export of json is fast and efficient.
uo_ There are mainly four json function functions, namely:
1. Parse: Convert string to JSON object
2. ToString: convert JSON object to string
3. Set: set JSON object or array value
4. Get: Get JSON object or array value
In the case of multi-level nesting, concatenated strings can be used to directly take values. for example    
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
To get the dj under the first line array "Dish 3", you can write the key string as follows:
deciaml ld_ dj
json. Get("/0/sub/2/dj",ref ld_dj)
In the "/0/sub/2/dj" string, the first 0 represents the data in the first row of the large array, and the sub represents the data in the first row is JSON. The sub value is a JSON array. The following 2 represents the data in the third line of the sub array. The key is dj and the value type is decimal.
***Note that the lower limit of the JSON array starts from 0 and ends at n-1, which is different from the lower limit of the PB array.

2、HttpClient
After developing PBJson, I suddenly feel that HttpClient has become an inevitable need. This is the HttpClient. Because I didn't use HttpClient much before, I didn't have enough experience, and my shortcomings are inevitable. Excuse me!
HttpClient uses WinHttp API internally:
1. It is simple to use. There is only one parameter, Request, to complete the request. For parameter description, see uo_ Statement in httpclient Local External Functions
2. With the help of pbjson, it can work perfectly with json and datawindow.
3.uo_ Httpclient has a built-in variable uo_ Response response is used to record various response results and data.
4. Learn about the request category first
//Static variable, the first parameter nHttpType of the require function
constant int HttpGet      = 1
    constant int HttpPost     = 2
    constant int HttpPut      = 3

5. It is necessary to know in advance what will be returned after the httpclient sends the request.
String header//Save the response header of the httpclient
String headerlist []//Save the response header keyword of httpclient
Blob data//Save the result of the httpclient, which is not limited to text, but may also be other binary data. In the case of text only, you can take the text value
Int errcode//The returned value is incorrect
string errtext//The returned value error text
Int httpcode//200 normal, 404 501
string verb //POST ，PUT ，GET 。。。
Long timeout=5000//The default timeout is 5 seconds
String charset//Language code utf-8 gbk, etc
String ContentType//text/html application/json, etc
String Server//Server type
String text//Text, converted from data. Automatically convert various types of utf8, GBK, UNICODE to the current text code. In most cases, this text is available. However, it does not rule out that the response result is non text, such as binary data such as pictures and sounds. You must read the data to obtain the correct result.
uo_ Json json//When Content Type: application/json is returned, this json object will be generated
    3、Encryption, decryption and encoding
It provides RSA, AES, DES, signature, base64, CRC, urlencode, etc.

4、 In the future, other functions will be added to the library to facilitate PB application. Stay tuned.

5、About being reported as anti-virus software by 360
Some DLLs developed by myself are often reported as viruses or trojans by 360. Here, I solemnly guarantee that I will never write malicious code in DLL! To solve the 360 virus, you can compress the DLL into a zip file and submit it to the https://open.soft.360.cn/report.php testing. After passing the test, 360 will no longer report the virus.

6、Special instructions
1) The copyright is mine, which is certain.
2) DLL is free of charge.
3) Individual modules need development authorization. But it is not absolute. Even if there is no development authorization, the most important thing is to pop up a dialog box when testing. After compiling, it will not pop up, but only pop up the development environment.

                    大自在(QQ:781770213 group：624409252) 
                                                       2020/03/06


![Uploading image.png…]()
