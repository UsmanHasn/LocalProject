alter table [PaymentRequest]
add RequestUrl nvarchar(max);

ALTER TABLE [PaymentRequest]
ALTER COLUMN RequestId Nvarchar(25);