INSERT INTO [users].[User]
(
	 FirstName
	,LastName
	,Username
	,Email
	,CreatedAt
	,UpdatedAt
	,UserTypeId
)
VALUES

('Arl'	,'Gonzales'	  ,'admin'	,'arlvenzgonzales@mail.com' ,GETDATE(), GETDATE(), '1')

 
INSERT INTO [users].[Access]
(
	 UserId
	,Auth
	,ExpirationDate
	,IsTempAuthActive
	,CreatedAt
	,UpdatedAt
	,Salt
)
SELECT UserId
	,'gZgut2OcrokZyV0rPR3tD6PX0YShu1G8zsePVre0h5Y='
	,'2120-03-18T09:28:38.322Z'
	,'0'
	,GETDATE()
	,GETDATE()
	,'+NOJDf1h5zWjS5mZxET74w=='
FROM [users].[User]

