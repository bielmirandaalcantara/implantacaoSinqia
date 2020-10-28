create database testesinqia;

use testesinqia;

create table tb_usuar (
	usuar_cod numeric primary key 
	, usuar_name  varchar(60)
);

create table tb_depusr(	
	emp_cod	numeric not null
	, depend_cod numeric not null
	, usuar_cod	numeric not null
	, constraint cp_depusr primary key (emp_cod, depend_cod, usuar_cod)
	, constraint cf_depusr_01 foreign key (usuar_cod) REFERENCES tb_usuar(usuar_cod)
);


create table tb_depusrSINCRO(	
	emp_cod	numeric not null
	, depend_cod numeric not null
	, usuar_cod	numeric not null
    , SCHAVEINTEGRACAO varchar(50) null
    , SMETODO varchar(10) not null
    , SQTDETENTATIVA numeric not null
	, SSTATUSINTEGRACAO varchar(10) not null
	, SDATAINTEGRACAO datetime not null
);

DELIMITER $

create trigger tg_tb_depusr_ins_sincro after insert on tb_depusr
for each row
begin
	insert into tb_depusrSINCRO (emp_cod,depend_cod,usuar_cod, SCHAVEINTEGRACAO, SMETODO, SQTDETENTATIVA, SSTATUSINTEGRACAO, SDATAINTEGRACAO) 
    values (new.emp_cod, new.depend_cod, new.usuar_cod, null,'INSERT',0, 'NEW' ,now());
end$

create trigger tg_tb_depusr_del_sincro after delete on tb_depusr
for each row
begin
	insert into tb_depusrSINCRO (emp_cod,depend_cod,usuar_cod, SCHAVEINTEGRACAO, SMETODO, SQTDETENTATIVA, SSTATUSINTEGRACAO, SDATAINTEGRACAO) 
    values (old.emp_cod, old.depend_cod, old.usuar_cod, null,'DELETE', 0,'NEW' ,now());	
end$

DELIMITER ;

use testesinqia;

insert into tb_usuar (usuar_cod, usuar_name) values (1, 'Gabrielm');
insert into tb_usuar (usuar_cod, usuar_name) values (2, 'Juliana');
insert into tb_depusr(emp_cod, depend_cod, usuar_cod)values(1,1,1);