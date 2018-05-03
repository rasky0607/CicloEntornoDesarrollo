delimiter #
drop procedure if exists selectDVD#
create procedure selectDVD(codi smallint,out resul smallint)
comment'PA para pruebas desde .NET'
begin	
	set @orden = 'select codigo, titulo, artista, pais, compania, precio , anio from dvd';
	if (codi is not null) then
		set @orden = concat(@orden,' where codigo = ',codi);
	end if;
	
	prepare sentencia from @orden;
	execute sentencia;
	select FOUND_ROWS() into resul;
	deallocate prepare sentencia;
	
	
end#
delimiter ;