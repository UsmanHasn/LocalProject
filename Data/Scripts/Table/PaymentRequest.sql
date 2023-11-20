USE [SJCESP_DEV]
GO

/****** Object:  Table [dbo].[PaymentRequest]    Script Date: 11/20/2023 5:52:01 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PaymentRequest]') AND type in (N'U'))
DROP TABLE [dbo].[PaymentRequest]
GO

/****** Object:  Table [dbo].[PaymentRequest]    Script Date: 11/20/2023 5:52:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PaymentRequest](
	[PaymentRequestId] [bigint] IDENTITY(1,1) NOT NULL,
	[RequestId] [bigint] NOT NULL,
	[RequestNo] [varchar](255) NULL,
	[merchantid] [bigint] NULL,
	[currency] [varchar](4) NULL,
	[redirect_url] [varchar](255) NULL,
	[cancel_url] [varchar](255) NULL,
	[language] [varchar](10) NULL,
	[order_id] [varchar](50) NULL,
	[UserId] [varchar](50) NULL,
	[RequestFromUrl] [varchar](250) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


