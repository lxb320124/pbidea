rem 创建密钥,使用openssl工具生成一个RSA私钥
openssl genrsa -des3 -out server.key 2048

rem 生成CSR（证书签名请求）,需要依次输入国家，地区，城市，组织，组织单位，Common Name和Email。其中Common Name，可以写自己的名字或者域名，如果要支持https，Common Name应该与域名保持一致，否则会引起浏览器警告。
openssl req -new -key server.key -out server.csr

rem 删除密钥中的密码
openssl rsa -in server.key -out server.key

rem 生成自签名证书,内部或者测试使用，只要忽略证书提醒就可以了。
openssl x509 -req -days 365 -in server.csr -signkey server.key -out server.crt

rem 生成pem格式的公钥,有些服务，需要有pem格式的证书才能正常加载
openssl x509 -in server.crt -out server.pem -outform PEM
