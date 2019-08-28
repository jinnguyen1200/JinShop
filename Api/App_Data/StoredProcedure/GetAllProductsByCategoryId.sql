create procedure [dbo].[GetAllProductByCategoryId] (
@CategoryId int
)
as
begin
	SELECT p.* from product as p
	inner join Category as c on c.Id = p.CategoryID
	where c.id = @CategoryId
end