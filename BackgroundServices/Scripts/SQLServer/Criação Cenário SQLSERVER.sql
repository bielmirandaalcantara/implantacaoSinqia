create table tb_usuar (
	usuar_cod numeric primary key identity
	, usuar_name  varchar(60)
)

create table tb_depusr(	
	emp_cod	numeric not null
	, depend_cod numeric not null
	, usuar_cod	numeric not null
	, constraint cp_depusr primary key (emp_cod, depend_cod, usuar_cod)
	, constraint cf_depusr_01 foreign key (usuar_cod) REFERENCES dbo.tb_usuar(usuar_cod)
)

create table tb_depusrSINCRO(	
	emp_cod	numeric not null
	, depend_cod numeric not null
	, usuar_cod	numeric not null
    , SCHAVEINTEGRACAO varchar(50) null
    , SMETODO varchar(10) not null
    , SQTDETENTATIVA numeric not null
	, SSTATUSINTEGRACAO varchar(10) not null
	, SDATAINTEGRACAO datetime not null
)