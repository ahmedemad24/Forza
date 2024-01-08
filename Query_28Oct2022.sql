Create table tbl_region (
    RegionId int PRIMARY KEY IDENTITY(1,1),
    RegionName NVARCHAR(100),
    ServiceAmount decimal (18,2),
    CreatedBy int
)
INSERT Into tbl_region (RegionName,ServiceAmount) VALUES('TEST1',10)

GO
ALTER TABLE [dbo].[Tbl_customer]
    ADD [RegionId] int NULL DEFAULT 1 FOREIGN key REFERENCES tbl_region(regionId)

GO

update tbl_Customer set RegionId=1 where RegionId is null

alter table tbl_invoiceHeader
add IsGifted bit not null default 0

GO
alter table Tbl_customer
alter COLUMN RegionId INT NOT NULL 

alter table tbl_invoiceHeader
add DeliveryFees DECIMAL (3,2)