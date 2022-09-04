CREATE PROCEDURE [dbo].[Thriller_CRUD]
      @Action VARCHAR(10)
      ,@BookId INT = NULL
      ,@Title VARCHAR(100) = NULL
      ,@Author VARCHAR(100) = NULL
	  ,@Image VARCHAR(100) = NULL
AS
BEGIN
      SET NOCOUNT ON;
 
      --SELECT
    IF @Action = 'SELECT'
      BEGIN
            SELECT *
            FROM BS_Thriller
      END
 
      --INSERT
    IF @Action = 'INSERT'
      BEGIN
            INSERT INTO BS_Thriller(BS_ID, BS_Image, BS_Title, BS_Author)
            VALUES (@BookId, @Image, @Title, @Author)
      END
 
      --UPDATE
    IF @Action = 'UPDATE'
      BEGIN
            UPDATE BS_Thriller
            SET BS_Image = @Image, BS_Title = @Title, BS_Author = @Author
            WHERE BS_ID = @BookId
      END

	   --DELETE
    IF @Action = 'DELETE'
      BEGIN
            DELETE FROM BS_Thriller
            WHERE BS_ID = @BookId
      END
 
END
