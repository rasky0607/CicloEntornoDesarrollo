delimiter #

drop procedure if exists selectDVD#
create procedure selectDVD(codi smallint, out resul int)
comment 'PA para pruebas desde .NET. Resul devuelve el número de filas afectadas.'

begin
	set @orden = 'select codigo, titulo, artista, pais, compania, precio, anio from dvd';
	
	if (codi is not null) then
		set @orden = concat(@orden, ' where codigo = ', codi);
	end if;
	
	PREPARE sentencia FROM @orden;
	EXECUTE sentencia;
	select FOUND_ROWS() into resul;
	DEALLOCATE PREPARE sentencia;	
end#

delimiter ;