/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\Inserts\Lookups\InsertStudentStatus.sql
:r .\Inserts\Lookups\InsertTDCStatus.sql
:r .\Inserts\Lookups\InsertACESStatus.sql
:r .\Inserts\Lookups\InsertUserType.sql
:r .\Inserts\Lookups\InsertRestriction.sql
:r .\Inserts\Lookups\InsertTransmission.sql
:r .\Inserts\Lookups\InsertBranch.sql
:r .\Inserts\Lookups\InsertDriveSafeStatus.sql
:r .\Inserts\Lookups\InsertActivityLog.sql
:r .\Inserts\Lookups\InsertEnrollmentMode.sql
:r .\Inserts\Lookups\InsertOffice.sql
:r .\Inserts\Lookups\InsertPaymentMode.sql
:r .\Inserts\Lookups\InsertTransaction.sql
:r .\Inserts\Lookups\InsertCourse.sql

:r Inserts\InitialData\01_Insert_Billing_Setting.sql


--NOTE: RUN INSERT SCRIPTS USER ONCE ONLY FOR INITIAL ADMIN 
--:r .\Inserts\User\Users.sql