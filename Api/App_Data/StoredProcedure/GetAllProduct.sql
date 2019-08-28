CREATE PROCEDURE [dbo].[getAllProduct]
as
begin
select  p.Id, 
		                        p.Name, 
		                        p.Price, 
		                        p.Description, 
		                        p.IsActive, 
		                        p.CategoryID, 
		                        c.Name as CategoryName
                        from Product p
                        left join Category c on p.CategoryID = c.Id;
end;