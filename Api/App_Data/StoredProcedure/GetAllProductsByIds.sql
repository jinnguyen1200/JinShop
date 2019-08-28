CREATE procedure [dbo].[GetAllProductByIds]
@Ids nvarchar(100)
as
begin
	Select * from product
	where id in (@Ids)
end