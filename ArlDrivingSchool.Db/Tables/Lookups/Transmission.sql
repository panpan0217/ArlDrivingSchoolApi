CREATE TABLE [lookups].[Transmission]
(
	[TransmissionId]	INT				NOT NULL IDENTITY(1,1),
	[TransmissionName]	NVARCHAR(255)	NOT NULL,
	CONSTRAINT [PK_ATransmission] PRIMARY KEY CLUSTERED ([TransmissionId] ASC)

)
