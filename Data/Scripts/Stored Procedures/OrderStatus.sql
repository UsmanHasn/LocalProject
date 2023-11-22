USE [SJCESP_DEV]
GO

/****** Object:  Table [dbo].[OrderStatus]    Script Date: 11/21/2023 5:55:14 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderStatus]') AND type in (N'U'))
DROP TABLE [dbo].[OrderStatus]
GO

/****** Object:  Table [dbo].[OrderStatus]    Script Date: 11/21/2023 5:55:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderStatus](
	[orderStatusId] [int] IDENTITY(1,1) NOT NULL,
	[OrderStatus] [varchar](255) Not NULL,
	[OrderStatusDescription] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[orderStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



INSERT INTO OrderStatus (OrderStatus, OrderStatusDescription)
VALUES 
    ('Invalid', 'Invalid Transaction request invalidated at SmartPay Application.'),
    ('Initiated', 'Initiated Transaction initiation request received from Merchant.'),
    ('Aborted', 'Aborted Transaction cancelled by the customer on SmartPay.'),
    ('Awaited', 'Awaited Transaction sent to PG connector and awaiting response.'),
    ('Successful', 'Successful Transaction successful and should be captured pending.'),
    ('Confirmed', 'Confirmed Transaction captured by the application.'),
    ('Cancelled', 'Cancelled Transaction cancelled/voided by the merchant'),
    ('Refunded', 'Refund request received against the transaction.'),
    ('Unsuccessful', 'Unsuccessful Transaction processing failed.'),
    ('Timeout', 'Request timed out and merchant should trigger transaction inquiry');

