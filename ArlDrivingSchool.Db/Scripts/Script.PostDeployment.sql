﻿/*
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


--NOTE: RUN INSERT SCRIPTS USER ONCE ONLY FOR INITIAL ADMIN 
--:r .\Inserts\User\Users.sql