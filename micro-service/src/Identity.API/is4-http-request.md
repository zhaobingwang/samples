# IdentityServer4 Http请求信息

## 客户端授权模式获取token（app_test）
```
POST /connect/token HTTP/1.1
Host: localhost:5000
Content-Type: multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW

----WebKitFormBoundary7MA4YWxkTrZu0gW
Content-Disposition: form-data; name="client_id"

app_test
----WebKitFormBoundary7MA4YWxkTrZu0gW
Content-Disposition: form-data; name="client_secret"

123456
----WebKitFormBoundary7MA4YWxkTrZu0gW
Content-Disposition: form-data; name="grant_type"

client_credentials
----WebKitFormBoundary7MA4YWxkTrZu0gW

```