IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'setting' AND  TABLE_NAME = 'Billing')
BEGIN
	IF(NOT EXISTS(SELECT 1 FROM [setting].[Billing]))
	BEGIN
	  INSERT INTO [setting].[Billing]
		(
			 TDCOnline
			,TDCClassroom
			,DEPOnline
			,DEPClassroom
			,PDCCarManual
			,PDCCarMatic
			,PDCCarCombination
			,PDCMotorManual
			,PDCMotorMatic
			,PDCMotorCombination
			,PDCTricycleManual
			,PDCTricycleMatic
			,PDCTricycleCombination
			,CreatedBy
			,CreatedAt

		)
		VALUES(
			 1500
			,1500
			,1500
			,1500
			,1500
			,1500
			,1500
			,1500
			,1500
			,1500
			,1500
			,1500
			,1500
			,'system'
			,GETUTCDATE()
			)
	END;
END