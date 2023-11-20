USE [SJCESP_DEV]
GO

ALTER TABLE [dbo].[PaymentResponse] DROP CONSTRAINT [FK_PaymentRequest_PaymentResponse]
GO

/****** Object:  Table [dbo].[PaymentResponse]    Script Date: 11/20/2023 5:52:14 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PaymentResponse]') AND type in (N'U'))
DROP TABLE [dbo].[PaymentResponse]
GO

/****** Object:  Table [dbo].[PaymentResponse]    Script Date: 11/20/2023 5:52:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PaymentResponse](
	[PaymentResponseId] [bigint] IDENTITY(1,1) NOT NULL,
	[PaymentRequestId] [bigint] NOT NULL,
	[order_id] [varchar](50) NULL,
	[tracking_id] [varchar](50) NULL,
	[bank_ref_no] [varchar](50) NULL,
	[order_status] [varchar](50) NULL,
	[failure_message] [text] NULL,
	[payment_mode] [varchar](50) NULL,
	[card_name] [varchar](50) NULL,
	[status_code] [varchar](50) NULL,
	[status_message] [text] NULL,
	[currency] [varchar](10) NULL,
	[amount] [decimal](10, 3) NULL,
	[billing_name] [varchar](100) NULL,
	[billing_address] [text] NULL,
	[billing_city] [varchar](50) NULL,
	[billing_state] [varchar](50) NULL,
	[billing_zip] [varchar](20) NULL,
	[billing_country] [varchar](50) NULL,
	[billing_tel] [varchar](20) NULL,
	[billing_email] [varchar](100) NULL,
	[merchant_param1] [varchar](100) NULL,
	[merchant_param2] [varchar](100) NULL,
	[merchant_param3] [varchar](100) NULL,
	[merchant_param4] [varchar](100) NULL,
	[merchant_param5] [varchar](100) NULL,
	[discount_value] [decimal](10, 2) NULL,
	[mer_amount] [decimal](10, 3) NULL,
	[retry] [varchar](10) NULL,
	[response_code] [varchar](50) NULL,
	[trans_date] [datetime] NULL,
	[bin_country] [varchar](50) NULL,
	[card_type] [varchar](50) NULL,
	[saveCard] [char](1) NULL,
	[order_date_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentResponseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[PaymentResponse]  WITH CHECK ADD  CONSTRAINT [FK_PaymentRequest_PaymentResponse] FOREIGN KEY([PaymentRequestId])
REFERENCES [dbo].[PaymentRequest] ([PaymentRequestId])
GO

ALTER TABLE [dbo].[PaymentResponse] CHECK CONSTRAINT [FK_PaymentRequest_PaymentResponse]
GO


