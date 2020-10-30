use testeSinqia

create table tb_usuar (
	usuar_cod numeric identity
	, usuar_name  varchar(60)
  , primary key(usuar_cod)
)
go
create table tb_depusr(	
	emp_cod	numeric not null
	, depend_cod numeric not null
	, usuar_cod	numeric not null
	,constraint cp_depusr primary key (emp_cod, depend_cod, usuar_cod)
	,constraint cf_depusr_01 foreign key (usuar_cod) REFERENCES tb_usuar(usuar_cod)
)
go
create table tb_depusrSINCRO(	
	emp_cod	numeric not null
	, depend_cod numeric not null
	, usuar_cod	numeric not null
    , SCHAVEINTEGRACAO varchar(50) null
    , SMETODO varchar(10) not null
    , SQTDETENTATIVA int not null
	, SSTATUSINTEGRACAO varchar(10) not null
	, SDATAINTEGRACAO datetime not null
)

go
create trigger tg_tb_depusr_ins_sincro on tb_depusr for insert as 
--insert command
begin
    insert into tb_depusrSINCRO (emp_cod,depend_cod,usuar_cod, SCHAVEINTEGRACAO, SMETODO, SQTDETENTATIVA, SSTATUSINTEGRACAO, SDATAINTEGRACAO)
    select emp_cod,depend_cod,usuar_cod, null,'INSERT',0, 'NEW' ,GETDATE() from inserted
end

create trigger tg_tb_depusr_del_sincro on tb_depusr for delete as 
--delete command
begin
    insert into tb_depusrSINCRO (emp_cod,depend_cod,usuar_cod, SCHAVEINTEGRACAO, SMETODO, SQTDETENTATIVA, SSTATUSINTEGRACAO, SDATAINTEGRACAO)
    select emp_cod,depend_cod,usuar_cod, null,'DELETE',0, 'NEW' ,GETDATE() from deleted
end
