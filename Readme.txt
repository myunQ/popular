���Բ��裺
1������������һ��������Ӧ��API��GET https://localhost:44363/identity ��Ӧ 401��

2��������֤API��POST https://localhost:44343/connect/token ��� Access Token��
	Request Header:
Content-Type:application/x-www-form-urlencoded
	Request Body:
grant_type:client_credentials
client_id:client
client_secret:secret
scope:scope1 scope2

3���� Access Token ��ֵ�ŵ�����ͷ���ٴε���Ӧ��API https://localhost:44363/identity ��
	Request Header:
Authorization:Bearer <token>