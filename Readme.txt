测试步骤：
1、（可跳过这一步）调用应用API：GET https://localhost:44363/identity 响应 401。

2、请求认证API：POST https://localhost:44343/connect/token 获得 Access Token。
	Request Header:
Content-Type:application/x-www-form-urlencoded
	Request Body:
grant_type:client_credentials
client_id:client
client_secret:secret
scope:scope1 scope2

3、将 Access Token 的值放到请求头，再次调用应用API https://localhost:44363/identity 。
	Request Header:
Authorization:Bearer <token>