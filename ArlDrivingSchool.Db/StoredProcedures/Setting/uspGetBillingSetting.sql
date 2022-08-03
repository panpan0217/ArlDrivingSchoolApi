CREATE PROCEDURE [setting].[uspGetBillingSetting]
AS
	SELECT TOP(1)  BillingId 
		    ,TDCOnline
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
			,PDCPackage
	FROM [setting].[Billing]
GO

