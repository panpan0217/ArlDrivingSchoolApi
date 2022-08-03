CREATE PROCEDURE [setting].[uspUpdateBillingSetting]
	@BillingId				INT,
	@TDCOnline				INT,
	@TDCClassroom			INT,
	@DEPOnline				INT,
	@DEPClassroom			INT,
	@PDCCarManual			INT,
	@PDCCarMatic			INT,
	@PDCCarCombination		INT,
	@PDCMotorManual			INT,
	@PDCMotorMatic			INT,
	@PDCMotorCombination	INT,
	@PDCTricycleManual		INT,
	@PDCTricycleMatic		INT,
	@PDCTricycleCombination	INT,
	@PDCPackage	INT
AS
BEGIN
	
	UPDATE [setting].Billing
	SET
	 TDCOnline = @TDCOnline
	,TDCClassroom = @TDCClassroom
	,DEPOnline = @DEPOnline
	,DEPClassroom = @DEPClassroom
	,PDCCarManual = @PDCCarManual
	,PDCCarMatic = @PDCCarMatic
	,PDCCarCombination = @PDCCarCombination
	,PDCMotorManual = @PDCMotorManual
	,PDCMotorMatic = @PDCMotorMatic
	,PDCMotorCombination = @PDCMotorCombination
	,PDCTricycleManual = @PDCTricycleManual
	,PDCTricycleMatic = @PDCTricycleMatic
	,PDCTricycleCombination = @PDCTricycleCombination
	,PDCPackage = @PDCPackage
	WHERE BillingId = @BillingId
END
GO;